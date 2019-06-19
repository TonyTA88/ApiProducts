using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProducts.Models
{
    public class ProductLog
    {
        public long Id { get; set; }
        public string action { get; set; }
        public DateTime Date { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal price { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Oldprice { get; set; }
        public string User { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal stockquantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Oldstockquantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal AmountPurchased { get; set; }


    }
}
