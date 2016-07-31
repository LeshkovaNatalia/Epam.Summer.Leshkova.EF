using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstTutorial
{
    public class User
    {
        public User() { }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string PasswordSalt { get; set; }
        public string Salt { get; set; }

        public int RoleId { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
