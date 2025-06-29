using SchoolWith.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWith.Core.Dtos.Classes
{
    public class ReturnClassDto
    {
        public string? Message { get; set; } = string.Empty;
        public Class Class { get; set; }
    }
}
