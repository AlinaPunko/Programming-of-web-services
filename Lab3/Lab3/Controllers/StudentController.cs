using Lab3.Models;
using Newtonsoft.Json;
using System;
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

namespace Lab3.Controllers
{
    public class StudentController : ApiController
    {
        private Context _context = new Context();
        private Context _context2 = new Context();

        // GET: api/Student
        [HttpGet]
        public object GetStudents(
                int limit = 2,
                int offset = 0,
                int minId = 0,
                int maxId = 100,
                string sort = "ID",
                string columns = "id, name, phone",
                string like = null,
                string globalLike = null,
                String type = "json")
        {
            // Get params from query
            var requestParams = Request.GetQueryNameValuePairs();


            var students = _context.Students.Where(x => x.Id > 0).AsNoTracking();
            var usersFromRepo = _context2.Students.Where(x => x.Id > 0).AsNoTracking();

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
                    var xHrefP = new XElement("hrefP", $"api/student/{item.Id - 1}");
                    var xHref = new XElement("href", $"api/student/{item.Id}");
                    var xHrefN = new XElement("hrefN", $"api/student/{item.Id + 1}");
                    var linksXml = new List<XElement>();
                    if (usersFromRepo.Count(x => x.Id == item.Id - 1) != 0)
                    {
                        linksXml.Add(xHrefP);
                    }
                    linksXml.Add(xHref);
                    if (usersFromRepo.Count(x => x.Id == item.Id + 1) != 0)
                    {
                        linksXml.Add(xHrefN);
                    }

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
                    temp.Links = new
                    {
                        hrefP = usersFromRepo.Count(x => x.Id == item.Id - 1) != 0 ? $"api/student/{item.Id - 1}" : "",
                        href = $"api/student/{item.Id}",
                        hrefN = usersFromRepo.Count(x => x.Id == item.Id + 1) != 0 ? $"api/student/{item.Id + 1}" : "",
                        rel = "User",
                        type = Request.Method.Method
                    };

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
            /*IQueryable<Student> students = _context.Students;

            
            // Sort by id, name, phone
            if (sort.Count() == 1)
                students = (sort[0].Value == "name" ? students.OrderBy(s => s.Name)
                    : sort[0].Value == "phone" ? students.OrderBy(s => s.Phone)
                    : students.OrderBy(s => s.Id));
            else
                students = students.OrderBy(s => s.Id);

            // Filter by min or max id
            if (minid.Count() == 1) { int min = int.Parse(minid[0].Value); students = students.Where(s => s.Id >= min); }
            if (maxid.Count() == 1) { int max = int.Parse(maxid[0].Value); students = students.Where(s => s.Id <= max); }

            // Search students by name
            if (global_like.Count() == 1)
            {
                string g_like = global_like[0].Value;
                students = students.Where(s => s.Name.Contains(g_like) || s.Phone == g_like);
            }

            // Pagination
            if (limit.Count() == 1 && offset.Count() == 1)
                students = students.Skip(((int.Parse(offset[0].Value)) - 1) * int.Parse(limit[0].Value)).Take(int.Parse(limit[0].Value));

            var list = students.ToList();

            //// Filter columns
            //if (columns.Count() == 1) {
            //    string column_lavue = columns[0].Value;
            //    string[] arr = column_lavue.Split(",".ToCharArray());
            //    bool id = false, name = false, phone = false;

            //    foreach (string val in arr) {
            //        if (val == "id") id = true;
            //        if (val == "name") name = true;
            //        if (val == "phone") phone = true;
            //    }

            //    list.ForEach(s => listApi_.Add(new {  });
            //}


            // Add HATEOAS
            List<StudentAPI> listApi = new List<StudentAPI>();
            list.ForEach(s => listApi.Add(new StudentAPI(s, new HATEOAS("http://localhost:65191/api/Student/" + s.Id, "student." + s.Id))));

            return Ok(listApi);*/
        }

        // GET: api/Student/5
        [HttpGet]
        [ResponseType(typeof(Student))]
        public object GetStudent(int id)
        {
            Student student = _context.Students.Find(id);
            if (student == null)
                return Content(HttpStatusCode.NotFound, new HATEOAS("http://localhost:65191/api/Error/404", "error.404"));

            return Ok(new StudentAPI(student, new HATEOAS("http://localhost:65191/api/Student/" + id, "self")));
        }

        // PUT: api/Student/5
        [HttpPut]
        [ResponseType(typeof(Student))]
        public object PutStudent(int id, Student student)
        {
            student.Id = id;

            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, new { ModelState, HATEOAS = new HATEOAS("http://localhost:65191/api/Error/400", "error.400") });
            }

            try
            {
                _context.Entry(student).State = EntityState.Modified;
                _context.SaveChanges();
                return Content(HttpStatusCode.OK, new StudentAPI(student, new HATEOAS("http://localhost:55556/api/Student/" + student.Id, "self")));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return Content(HttpStatusCode.NotFound, new HATEOAS("http://localhost:55556/api/Error/404", "error.404"));
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Student
        [HttpPost]
        [ResponseType(typeof(Student))]
        public object PostStudent(Student student)
        {
            if (!ModelState.IsValid)
                return Content(HttpStatusCode.BadRequest, new { ModelState, HATEOAS = new HATEOAS("http://localhost:55556/api/Error/400", "error.400") });

            _context.Students.Add(student);
            _context.SaveChanges();

            return Content(HttpStatusCode.Created, new StudentAPI(student, new HATEOAS("http://localhost:55556/api/Student/" + student.Id, "self")));
        }

        // DELETE: api/Student/5
        [HttpDelete]
        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudent(int id)
        {
            Student student = _context.Students.Find(id);
            if (student == null)
                return Content(HttpStatusCode.NotFound, new HATEOAS("http://localhost:55556/api/Error/404", "error.404"));

            _context.Students.Remove(student);
            _context.SaveChanges();

            return Content(HttpStatusCode.NoContent, new HATEOAS("http://localhost:55556/api/Student/" + id, "self"));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Count(x => x.Id == id) > 0;
        }
    }
}
