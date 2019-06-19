using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiProducts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace ApiProducts.Controllers
{
   

    [Produces("application/json")]
    [Route("api/Products")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductController : Controller
    {
        private readonly ProductContext context;

        public ProductController(ProductContext context)
        {
            this.context = context;
        }
        //Get Products with order by name by default or by likes
        [HttpGet]
        public IEnumerable<Products> Get(string order)
        {
            if (String.IsNullOrEmpty(order))
            {
                return context.Products.OrderBy(s => s.Name).ToList();
            }
            else if (order.Equals("Likes"))
            {
                return context.Products.OrderBy(s => s.likes).ToList();                
            }

            return context.Products.OrderBy(s => s.Name).ToList(); 
        }

        [HttpGet("{id}", Name = "ProductCreated")]
        public IActionResult GetById(long id)
        {
            var Product = context.Products;

            if (Product == null)
            {
                return NotFound();
            }

            return Ok(Product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Products Product)
        {
            if (ModelState.IsValid)
            {
                context.Products.Add(Product);
                context.SaveChanges();
                return new CreatedAtRouteResult("ProductCreated", new { id = Product.Id }, Product);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Products Product, long id)
        {
            decimal OldPrice, NewPrice;

            if (Product.Id != id)
            {
                return BadRequest();
            }

           

            var v = context.Products.Find(id);
            OldPrice = v.price;

            v.price = Product.price;
            v.likes = Product.likes;
            v.Name = Product.Name;
            v.stockquantity = Product.stockquantity;
            

            NewPrice = Product.price;
            //capture the contex for products
            var _contex = context.Entry(v);



            //if the price has change write in the log
            if (OldPrice != NewPrice)
            {
                //user who made the change, old price, new price, action
                Log("user", OldPrice, NewPrice, "PriceChange");
            }

            //Update database            
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var pais = context.Products.FirstOrDefault(x => x.Id == id);

            if (pais == null)
            {
                return NotFound();
            }

            context.Products.Remove(pais);
            context.SaveChanges();
            return Ok(pais);
        }

        public void Log(string user,decimal price, decimal Oldprice,string action)
        {
            ProductLog PtrLog = new ProductLog();
            try
            {                
                PtrLog.User = user;
                PtrLog.action = action;
                PtrLog.price = price;
                PtrLog.Oldprice = Oldprice;
                PtrLog.Date = DateTime.UtcNow;

                context.ProductLog.Add(PtrLog);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
               
            }

        }
    }
}