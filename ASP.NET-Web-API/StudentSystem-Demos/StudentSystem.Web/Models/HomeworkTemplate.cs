namespace StudentSystem.Web.Models
{
    using StudentSystem.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    public class HomeworkTemplate
    {
        public static Expression<Func<Homework, HomeworkTemplate>> FromHomework
        {
            get
            {
                return a => new HomeworkTemplate
                {
                    TimeSent = a.TimeSent,
                    FileUrl = a.FileUrl,
                    CourseId = a.CourseId,
                    StudentIdentification = a.StudentIdentification
                };
            }
        }

        [Required]
        public string FileUrl { get; set; }

        public DateTime TimeSent { get; set; }

        public int StudentIdentification { get; set; }

        public Guid CourseId { get; set; }
    }
}