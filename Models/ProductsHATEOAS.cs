using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProducts.Models
{
    public class ProductsHATEOAS
    {
        public long Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal stockquantity { get; set; }
        public int likes { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal price { get; set; }

        public List<links> links;

    }

    public class links
    {
        public string rel { set; get; }
        public string href { set; get; }
    }

}
