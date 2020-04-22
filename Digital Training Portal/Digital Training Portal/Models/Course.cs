﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Training_Portal.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }

        [Required]
        public string DeliveryMethod { get; set; }
    }
}
