using SchoolWith.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWith.Core.Dtos.Subjects
{
    public class ReturnSupjectDto
    {
        public string? Message { get; set; } =string.Empty;
        public Subject Subject { get; set; }
    }
}
