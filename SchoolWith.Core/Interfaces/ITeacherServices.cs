using SchoolWith.Core.Dtos.SharedDtos;
using SchoolWith.Core.Dtos.Teachers;
using SchoolWith.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWith.Core.Interfaces
{
    public interface ITeacherServices : IBaseRepository<Teacher>
    {
        Task<ReturnTeacherDto> AddTeacher(addteacherDto addteacherDto);
        Task<List<Teacher>> getAllTeachers();
        Task<ReturnTeacherDto> editTeacher(EditTeacherDto editTeacherDto);
        Task<DeletDto> deleteTeacher(int teacherId);
        
    }
}
