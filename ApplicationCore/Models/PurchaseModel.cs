using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class PurchaseModel
    {
        public int PurchaseNumber { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public DateTime? PurchaseDateTime { get; set; }
        public decimal TotalPrice { get; set; }
        //public Movie Movie { get; set; }
        //public Genre Users { get; set; }
    }
}
