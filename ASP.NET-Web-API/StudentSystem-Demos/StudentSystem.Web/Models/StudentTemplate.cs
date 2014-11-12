namespace StudentSystem.Web.Models
{
    using StudentSystem.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    public class StudentTemplate
    {
        public static Expression<Func<Student, StudentTemplate>> FromStudent
        {
            get
            {
                return a => new StudentTemplate
                {
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Level = a.Level
                };
            }
        }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public int Level { get; set; }
    }
}