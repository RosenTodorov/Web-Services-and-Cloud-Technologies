namespace StudentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CourseIntance")]
    public class Course
    {
        public Course()
        {
            this.Id = Guid.NewGuid();
            this.Students = new HashSet<Student>();
            this.Homeworks = new HashSet<Homework>();
        }
        public Guid Id { get; set; }

        [MinLength(3)]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MinLength(10)]
        [MaxLength(6000)]
        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }

        [NotMapped]
        public TimeSpan? CourseLenght
        {
            get
            {
                return this.EndDate - this.StartDate;
            }
        }
    }
}