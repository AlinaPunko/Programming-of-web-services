using Lab3_1.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Xml.Linq;

namespace Lab3_1.Controllers
{
    public class StudentController : ApiController
    {

        private Context db = new Context();
        private Context db1 = new Context();

        // GET: api/Students1
        public object GetStudents(int limit = 2,
                int offset = 0,
                int minId = 0,
                int maxId = 100,
                string sort = "ID",
                string columns = "id, name, phone",
                string like = null,
                string globalLike = null,
                string type = "json")
        {
            var requestParams = Request.GetQueryNameValuePairs();


            var students = db.Students.Where(x => x.Id > 0).AsNoTracking();
            var usersFromRepo = db1.Students.Where(x => x.Id > 0).AsNoTracking();

            if (sort.ToLower() == "name")
            {
                students = students.OrderBy(prop => prop.Name);
            }
            else if (sort.ToLower() == "id")
            {
                students = students.OrderBy(prop => prop.Id);
            }
            else
            {
                return BadRequest();
            }

            students = students.Skip(offset)
                .Take(limit)
                .Where(prop => prop.Id >= minId && prop.Id <= maxId);

            if (like != null)
            {
                students = students.Where(prop => prop.Name.ToLower().Contains(like.ToLower()));
            }

           if (globalLike != null)
            {
                students = students.Where(prop => (prop.Name + prop.Id.ToString() + prop.Phone).ToLower().Contains(globalLike.ToLower()));
            }

            var res = new List<dynamic>();
            var xElements = new List<XElement>();
            foreach (var item in students)
            {
                if (type.ToLower() == "xml")
                {
                    var linksXml = new List<XElement>();

                    var xId = new XAttribute("id", item.Id);
                    var xName = new XAttribute("name", item.Name);
                    var xPhone = new XAttribute("phone", item.Phone);
                    var xUser = new XElement("student", linksXml);
                    if (columns.Contains("id"))
                    {
                        xUser.Add(xId);
                    }
                    if (columns.Contains("name"))
                    {
                        xUser.Add(xName);
                    }
                    if (columns.Contains("phone"))
                    {
                        xUser.Add(xPhone);
                    }
                    xElements.Add(xUser);
                }
                else
                {
                    dynamic temp = new ExpandoObject();
                    if (columns.Contains("id"))
                    {
                        temp.Id = item.Id;
                    }
                    if (columns.Contains("name"))
                    {
                        temp.Name = item.Name;
                    }
                    if (columns.Contains("phone"))
                    {
                        temp.Phone = item.Phone;
                    }
                    temp.Hateoas = new HATEOAS("http://localhost:51891/api/Student/" + item.Id, "self");

                    res.Add(temp);
                }
            }

            if (type.ToLower() == "xml")
            {
                var bodyXml = new XElement("Students", xElements);
                return Ok(bodyXml);
            }
            else
            {
                return Ok(JsonConvert.SerializeObject(res));
            }
        }

        // GET: api/Students1/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult GetStudent(int id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            return Content(HttpStatusCode.OK, new StudentAPI(student, new HATEOAS("http://localhost:51891/api/Student/" + id, "self")));
        }

        // PUT: api/Students1/5
        [ResponseType(typeof(void))]
        public object PutStudent([FromBody]Student student)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, new { ModelState, HATEOAS = new HATEOAS("http://localhost:51891/api/Error/400", "error.400") });
            }

            try
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return Content(HttpStatusCode.OK, new StudentAPI(student, new HATEOAS("http://localhost:51891/api/Student/" + student.Id, "self")));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(student.Id))
                {
                    return Content(HttpStatusCode.NotFound, new HATEOAS("http://localhost:51891/api/Error/404", "error.404"));
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Students1
        [ResponseType(typeof(Student))]
        public object PostStudent(Student student)
        {
            if (!ModelState.IsValid)
                return Content(HttpStatusCode.BadRequest, new { ModelState, HATEOAS = new HATEOAS("http://localhost:51891/api/Error/400", "error.400") });

            db.Students.Add(student);
            db.SaveChanges();

            return Content(HttpStatusCode.Created, new StudentAPI(student, new HATEOAS("http://localhost:51891/api/Student/" + student.Id, "self")));
        }

        // DELETE: api/Students1/5
        [ResponseType(typeof(Student))]
        public object DeleteStudent(int id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
                return Content(HttpStatusCode.NotFound, new HATEOAS("http://localhost:51891/api/Error/404", "error.404"));

            db.Students.Remove(student);
            db.SaveChanges();

            return Content(HttpStatusCode.NoContent, new HATEOAS("http://localhost:51891/api/Student/" + id, "self"));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentExists(int id)
        {
            return db.Students.Count(e => e.Id == id) > 0;
        }
    }
}
