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
    [Produces("application/json")]
    [Route("api/Saels")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SealsController : Controller
    {
        private readonly ProductContext context;

        public SealsController(ProductContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody] SaelsT Sael)
        {
            
            if (ModelState.IsValid)
            {
                Sael.Purchased = DateTime.UtcNow;
                context.SaelsT.Add(Sael);
                context.SaveChanges();
              

                var v = context.Products.Find(Sael.ProductId);

                if(v.stockquantity < Sael.AmountPurchased)
                {
                    return BadRequest(ModelState);
                }

                v.stockquantity = (v.stockquantity - Sael.AmountPurchased);

                //Update database            
                context.SaveChanges();
                

                //user who made the change, old price, new price, action
                Log("user", Sael.ProductId, Sael.AmountPurchased, "Purchased");
                return new CreatedAtRouteResult("ProductCreated", new { id = Sael.Id }, Sael);
            }

            return BadRequest(ModelState);
           
        }
        public void Log(string user, decimal ProductId, decimal qty, string action)
        {
            ProductLog PtrLog = new ProductLog();
            try
            {
                PtrLog.User = user;
                PtrLog.action = action;               
                PtrLog.Date = DateTime.UtcNow;
                PtrLog.AmountPurchased = qty;

                context.ProductLog.Add(PtrLog);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

            }

        }
    }
}