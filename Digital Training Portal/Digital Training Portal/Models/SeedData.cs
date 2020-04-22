using Digital_Training_Portal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Digital_Training_Portal.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DigitalTrainingPortalContext(serviceProvider.GetRequiredService<DbContextOptions<DigitalTrainingPortalContext>>()))
            {
                //if course table is empty then add some
                if (!context.Course.Any())
                {
                    context.Course.AddRange(new Course
                    {
                        Title = "Introduction to computing",
                        Description = "Basic knowledge of programming and computer realted stuffs",
                        DeliveryMethod = "On-Site"
                    },
                    new Course
                    {
                        Title = "Computer Programming",
                        Description = "Advanced knowledge of programming and computer realted stuffs.",
                        DeliveryMethod = "Off-Site"
                    },
                    new Course
                    {
                        Title = "Data Structures",
                        Description = "Knowledge about data structures",
                        DeliveryMethod = "Instructor-Led"
                    },
                    new Course
                    {
                        Title = "Data mining",
                        Description = "Training machines",
                        DeliveryMethod = "Remote-Online"
                    },
                    new Course
                    {
                        Title = "Data Science",
                        Description = "Advanced Data-Mining",
                        DeliveryMethod = "On-Site"
                    },
                    new Course
                    {
                        Title = "Deep Learning",
                        Description = "Advanced Data Science",
                        DeliveryMethod = "Off-Site"
                    },
                    new Course
                    {
                        Title = "Machine Learning",
                        Description = "Part of Deep Learning",
                        DeliveryMethod = "Instructor-Led"
                    },
                    new Course
                    {
                        Title = "Artificial Intelligence",
                        Description = "Advanced Machine Leraning",
                        DeliveryMethod = "Remote-Online"
                    },
                    new Course
                    {
                        Title = "Web Development",
                        Description = "Hands-On experiance of web development",
                        DeliveryMethod = "Remote-Online"
                    },
                    new Course
                    {
                        Title = "Database",
                        Description = "Knowledge about database",
                        DeliveryMethod = "Remote-Online"
                    });
                }

                //if user table is empty then add some
                if (!context.User.Any())
                {
                    context.User.AddRange(
                    new User
                    {
                        Login = "abid",
                        Password = "qwerty"
                    },

                    new User
                    {
                        Login = "dummy",
                        Password = "dummy"
                    });
                }

                context.SaveChanges();
            }
        }
    }
}