using SchoolWith.Core.Dtos.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWith.Core.Dtos.Teachers
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SubjectDto> Subjects { get; set; }
    }
}
