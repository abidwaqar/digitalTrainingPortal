using Digital_Training_Portal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Training_Portal.Data
{
    public class DigitalTrainingPortalContext : DbContext
    {
        public DigitalTrainingPortalContext(DbContextOptions<DigitalTrainingPortalContext> options) : base(options)
        {

        }

        public DbSet<Course> Course { get; set; }
        public DbSet<User> User { get; set; }
    }
}
