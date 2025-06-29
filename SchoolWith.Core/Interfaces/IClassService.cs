using SchoolWith.Core.Dtos.Classes;
using SchoolWith.Core.Dtos.SharedDtos;
using SchoolWith.Core.Dtos.Students;
using SchoolWith.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWith.Core.Interfaces
{
    public interface IClassService : IBaseRepository<Class>
    {
        Task<ReturnClassDto>addClass(AddClassDto addClassDto);
        Task<List<Class>> getAllClasses();
        Task<ReturnClassDto> updateClass(EditClassDto editClassDto);
        Task<DeletDto> deleteClass(int classId);

    }
}
