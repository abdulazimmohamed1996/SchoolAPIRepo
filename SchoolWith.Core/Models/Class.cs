using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWith.Core.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>(); //Meaning that on class can have more than one student
        public ICollection<ClassSubject> ClassSubjects { get; set; }     // Many-to-Many
    }
}
