using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
    public class Roles
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }
    }
}