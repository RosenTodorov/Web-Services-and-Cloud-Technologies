namespace StudentSystem.Web.Models
{
  using StudentSystem.Models;
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.Linq.Expressions;
  using System.Linq;

    using StudentSystem.Web.Models;

    public class CourseTemplate
    {
        public static Expression<Func<Course, CourseTemplate>> FromAirCraft
        {
            get
            {
                return a => new CourseTemplate
                {
                    Name = a.Name,
                    Students = a.Students.Select(asd => new StudentTemplate() { FirstName = asd.FirstName, LastName = asd.LastName, Level = asd.Level }).ToList()
                };
            }
        }

        [Required]
        public string Name { get; set; }

        public ICollection<StudentTemplate> Students { get; set; }
    }
}
