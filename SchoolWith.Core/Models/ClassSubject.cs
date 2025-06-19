using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWith.Core.Models
{
    public class ClassSubject
    {
        [ForeignKey("Class")]
        public int ClassId {  get; set; }
        public Class Class { get; set; }
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
