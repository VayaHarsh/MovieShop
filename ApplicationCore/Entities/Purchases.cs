using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Purchases
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public DateTime? PurchaseDateTime { get; set; }
        public int PurchaseNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public Movie Movie { get; set; }
        public Genre Users { get; set; }
    }
}