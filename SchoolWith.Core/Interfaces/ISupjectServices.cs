using SchoolWith.Core.Dtos.Subjects;
using SchoolWith.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWith.Core.Interfaces
{
    public interface ISupjectServices :IBaseRepository<Subject>
    {
        Task<ReturnSupjectDto>AddSubject(AddSubjectDto addSubjectDto);

    }
}
