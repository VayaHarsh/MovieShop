using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class UserRoles
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public Movie Roles { get; set; }
        public Genre Users { get; set; }

    }
}