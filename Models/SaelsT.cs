using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProducts.Models
{
    public class SaelsT
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal AmountPurchased { get; set; }
        public DateTime Purchased { get; set; }
    }
}
