using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProducts.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProducts.Controllers
{

    [Produces("application/json")]
    [Route("api/ProductsLikes")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LikeController : Controller
    {
        private readonly ProductContext context;

        public LikeController(ProductContext context)
        {
            this.context = context;
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] ProductsLike Product, long id)
        {

            if (Product.Id != id)
            {
                return BadRequest();
            }

            var v = context.Products.Find(id);
            if (Product.like)
            {
                v.likes += 1;
            }
            
            //Update database            
            context.SaveChanges();
            return Ok();
        }
    }
 }