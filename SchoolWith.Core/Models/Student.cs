using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWith.Core.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        [ForeignKey("Class")]
        public int ClassId {  get; set; }
        public Class Class { get; set; }
        public ICollection<StudentSubject> StudentSubjects { get; set; }

    }
}
