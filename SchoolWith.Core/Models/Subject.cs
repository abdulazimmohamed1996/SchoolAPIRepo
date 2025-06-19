using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWith.Core.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Teacher")]
        public int teacherId {  get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<StudentSubject> StudentSubjects { get; set; } // Many-to-Many
        public ICollection<ClassSubject> ClassSubjects { get; set; }     // Many-to-Many

    }
}
