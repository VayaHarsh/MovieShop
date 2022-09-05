using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; } = null!;
        public string HashedPassword { get; set; } = null!;
        public string Salt { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public bool? IsLocked { get; set; }
        public string? ProfilePictureUrl { get; set; }

        public ICollection<UserRoles> RolesOfUser { get; set; } = null!;

    }
}