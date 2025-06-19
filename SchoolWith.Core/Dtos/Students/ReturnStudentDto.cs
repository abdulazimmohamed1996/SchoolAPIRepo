using SchoolWith.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWith.Core.Dtos.Students
{
    public class ReturnStudentDto
    {
        public string? Message {  get; set; }=string.Empty;
        public Student Student { get; set; }    
    }
}
