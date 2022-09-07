using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Reviews
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public decimal? Rating { get; set; }
        public string ReviewText { get; set; }
        public Movie Movie { get; set; }
        public Users Users { get; set; }
    }
}
