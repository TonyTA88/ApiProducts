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
    [Route("api/ProductsPagination")]
    [AllowAnonymous]
    public class PaginationController : Controller
    {
        private readonly ProductContext context;

        public PaginationController (ProductContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductPaginationParams ProductPaginationParam)
        {
            ProductPagination Pagi = new ProductPagination();

            //var Product = context.Products;
            List<Products> Prod = new List<Products>();

            if (String.IsNullOrEmpty(ProductPaginationParam.order))
            {
                Prod = context.Products.OrderByDescending(s => s.Name).ToList();
                if (!String.IsNullOrEmpty(ProductPaginationParam.SearchParam))
                {
                    Prod = context.Products.OrderBy(s => s.Name).ToList().Where(x => x.Name.Contains(ProductPaginationParam.SearchParam)).ToList();
                }
                else
                {
                    Prod = context.Products.OrderBy(s => s.Name).ToList();
                }
            }
            else if (ProductPaginationParam.order.Equals("Likes"))
            {
                Prod = context.Products.OrderByDescending(s => s.likes).ToList();
                if (!String.IsNullOrEmpty(ProductPaginationParam.SearchParam))
                {
                    Prod = context.Products.OrderBy(s => s.likes).ToList().Where(x => x.Name.Contains(ProductPaginationParam.SearchParam)).ToList();
                }
                else
                {
                    Prod = context.Products.OrderBy(s => s.likes).ToList();
                }
            }

            Pagi.total = Prod.Count();
            Pagi.Products = Prod.Skip((ProductPaginationParam.pageNumber - 1) * ProductPaginationParam.pageSize).Take(ProductPaginationParam.pageSize).ToList();

            if (Pagi == null)
            {
                return NotFound();
            }

            return Ok(Pagi);
        }
    }
}