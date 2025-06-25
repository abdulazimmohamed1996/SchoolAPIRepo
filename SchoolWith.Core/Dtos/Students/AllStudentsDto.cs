using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWith.Core.Dtos.Students
{
    public class AllStudentsDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public string ClassName { get; set; }
    }
}
