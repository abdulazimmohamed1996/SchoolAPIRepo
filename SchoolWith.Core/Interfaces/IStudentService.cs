using SchoolWith.Core.Dtos.Students;
using SchoolWith.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWith.Core.Interfaces
{
    public interface IStudentService : IBaseRepository<Student>
    {
        Task<ReturnStudentDto>AddStudent(AddStudentDto studentDto);
        Task<List<Student>> GetAllStudents();
        Task<ReturnStudentDto> UpdateDtudent(EditStudentDto studentDto);
        Task<string> DeleteStudent(int StudentId);
    }
}
