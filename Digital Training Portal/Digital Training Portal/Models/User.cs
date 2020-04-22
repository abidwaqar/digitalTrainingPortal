using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Training_Portal.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}
