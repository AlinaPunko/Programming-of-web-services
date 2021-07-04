using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3_1.Models
{
    public class StudentAPI
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public HATEOAS Hateoas { get; set; }

        public StudentAPI(Student stud, HATEOAS hateoas)
        {
            Id = stud.Id;
            Name = stud.Name;
            Phone = stud.Phone;
            Hateoas = hateoas;
        }
    }
}