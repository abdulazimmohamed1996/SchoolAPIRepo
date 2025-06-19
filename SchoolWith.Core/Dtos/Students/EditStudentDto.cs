using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWith.Core.Dtos.Students
{
    public class EditStudentDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public int ClassId { get; set; }
    }
}
