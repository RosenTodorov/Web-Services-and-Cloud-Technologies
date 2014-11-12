namespace StudentSystem.Web.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using StudentSystem.Data;
    using StudentSystem.Web.Models;
    using StudentSystem.Models;

    public class StudentsController : ApiController
    {
        private StudentsSystemData data = new StudentsSystemData();

        // GET students/
        [HttpGet]
        public IQueryable<StudentTemplate> GetStudents()
        {
            return this.data.Students.All().Select(student => new StudentTemplate() { FirstName = student.FirstName, LastName = student.LastName, Level = student.Level });
        }

        // GET students/id
        public HttpResponseMessage GetStudentsById(int id)
        {
            var neededStudent = this.data.Students.All().Where(student => student.StudentIdentification == id).Select(student => new StudentTemplate() { FirstName = student.FirstName, LastName = student.LastName, Level = student.Level }).FirstOrDefault();

            if (neededStudent == null)
            {
                Request.CreateResponse(HttpStatusCode.NotFound, "Student not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, neededStudent);
        }

        // POST students/
        [HttpPost]
        public HttpResponseMessage AddStudent([FromBody]StudentTemplate student)
        {
            try
            {
                this.data.Students.Add(new Student() { FirstName = student.FirstName, LastName = student.LastName, Level = student.Level });
                this.data.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Student added.");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error occured when trying to add the student.");
            }

        }

        // PUT students/
        [HttpPut]
        public HttpResponseMessage UpdateStudentLevel(int id, [FromBody]int level)
        {
            var studentToUpdate = this.data.Students.All().FirstOrDefault(student => student.StudentIdentification == id);
            if (studentToUpdate == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Student does not exist.");
            }
            else
            {
                studentToUpdate.Level = level;
                this.data.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Student level updated.");
            }
        }

        // DELETE students/id
        [HttpDelete]
        public HttpResponseMessage DeleteStudent(int id)
        {
            var studentToDelete = this.data.Students.All().FirstOrDefault(student => student.StudentIdentification == id);
            if (studentToDelete == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "The student does not exist.");
            }
            else
            {
                this.data.Students.Delete(studentToDelete);
                this.data.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Student deleted.");
            }
        }
    }
}