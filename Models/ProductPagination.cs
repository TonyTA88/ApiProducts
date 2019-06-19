using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProducts.Models
{
    public class ProductPagination
    {
        public List<Products> Products;
        public int total { get; set; }       
    }

    public class ProductPaginationParams
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public string order { get; set; }
        public string SearchParam { get; set; }
    }
}