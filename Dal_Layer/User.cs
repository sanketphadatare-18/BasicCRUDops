using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal_Layer
{
    public class User
    {
        
        public int Id { get; set; }

        
        public string FirstName { get; set; }

        
        public string LastName { get;set; }

        
        public int UserId { get; set; }

        
        public string Email { get; set; }

        
        public string Password { get; set; }

        [NotMapped]
        public string RoleName { get; set; }

        public ICollection<UserRole> userRole { get; set; }



    }
}
