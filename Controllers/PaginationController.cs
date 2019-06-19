using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProducts.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProducts.Controllers
{


    //[Produces("application/json")]
    //[Route("api/Pagination")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //public class PaginationController : Controller
    //{
    //    private readonly ProductContext context;

    //    public ProductController(ProductContext context)
    //    {
    //        this.context = context;
    //    }

    //    [HttpPost]
    //    public IActionResult Post([FromBody] Products Product)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            context.Products.Add(Product);
    //            context.SaveChanges();
    //            return new CreatedAtRouteResult("ProductCreated", new { id = Product.Id }, Product);
    //        }

    //        return BadRequest(ModelState);
    //    }
    //}
}