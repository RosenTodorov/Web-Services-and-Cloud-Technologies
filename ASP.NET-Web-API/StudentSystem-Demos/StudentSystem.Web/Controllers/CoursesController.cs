namespace StudentSystem.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using StudentSystem.Data;
    using StudentSystem.Web.Models;
    using StudentSystem.Models;

    public class CoursesController : ApiController
    {
        private StudentsSystemData data = new StudentsSystemData();

        // GET courses/
        [HttpGet]
        public IEnumerable<CourseTemplate> GetAllCourses()
        {
            var allCourses = this.data.Courses.All()
                .Select(course => new CourseTemplate()
                {
                    Name = course.Name,
                    Students = course.Students.Select(student => new StudentTemplate()
                    {
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        Level = student.Level
                    }).ToList()
                });

            return allCourses;
        }

        // GET courses/name
        [HttpGet]
        public HttpResponseMessage GetCourseByName(string name)
        {
            var neededCourse = this.data.Courses.All()
                .Where(course => course.Name == name)
                .Select(CourseTemplate.FromAirCraft).FirstOrDefault();

            if (neededCourse == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Course does not exist.");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, neededCourse);
            }
        }

        // POST courses/
        [HttpPost]
        public HttpResponseMessage Add([FromBody]CourseTemplate course)
        {
            if (!this.ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                var newCourse = new Course() { Name = course.Name };
                this.data.Courses.Add(newCourse);
                this.data.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Course added.");
            }
        }

        // PUT courses/name
        [HttpPut]
        public HttpResponseMessage UpdateName(string name, [FromBody]string newName)
        {
            var courseToUpdate = this.data.Courses.All().Where(course => course.Name == name).FirstOrDefault();
            if (courseToUpdate == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Course does not exist.");
            }
            else
            {
                courseToUpdate.Name = newName;
                this.data.Courses.Update(courseToUpdate);
                this.data.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Course updated.");
            }
        }

        // DELETE courses/name
        [HttpDelete]
        public HttpResponseMessage Delete(string name)
        {
            var courseToDelete = this.data.Courses.All().Where(course => course.Name == name).FirstOrDefault();
            if (courseToDelete == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Course does not exist.");
            }
            else
            {
                this.data.Courses.Delete(courseToDelete);
                this.data.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Course deleted.");
            }
        }
    }
}