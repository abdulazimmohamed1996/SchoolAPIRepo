using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWith.Core.Dtos.Subjects
{
    public class EditSupjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int teacherId {  get; set; }
    }
}
