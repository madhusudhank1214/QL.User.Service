using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Models.Employee
{
    public class Login
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
