using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Training_Portal.Models
{
    public class CourseDeliveryViewModel
    {
        public List<Course> Courses { get; set; }
        public SelectList DeliveryMethod { get; set; }
        public string CourseDMString { get; set; }
        public string SearchString { get; set; }
    }
}
