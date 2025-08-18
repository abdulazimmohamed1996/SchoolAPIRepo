using SchoolWith.Core.Dtos.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWith.Core.Dtos.Classes
{
    public class ClassWithStudents
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AllStudentsDto> Students { get; set; }
    }
}
