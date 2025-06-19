using Mapster;
using Microsoft.Extensions.Localization;
using SchoolWith.Core.Dtos.Students;
using SchoolWith.Core.Interfaces;
using SchoolWith.Core.Models;
using SchoolWith.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWith.EF.Services
{
    public class StudentServices : BaseRepository<Student>, IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<string> _localizer;
        public StudentServices(SchoolDbContext context, IUnitOfWork unitOfWork, IStringLocalizer<string> localizer) : base(context)
        {
            _unitOfWork = unitOfWork;
            _localizer = localizer;
        }

        public async Task<ReturnStudentDto> AddStudent(AddStudentDto studentDto)
        {
            var output = new ReturnStudentDto();
            var StudentExit = await _unitOfWork.Students.Find(S => S.FullName == studentDto.FullName);
            if (StudentExit != null)
            {
                output.Message = string.Format(_localizer["Student Name already exsist"]);
            }
            else
            {
                var AddedStuden = studentDto.Adapt<Student>();
                await _unitOfWork.Students.Add(AddedStuden);
                await _unitOfWork.Students.CommitChanges();
                output.Student = AddedStuden;
            }
            return output;

        }

        public async Task<string> DeleteStudent(int StudentId)
        {
            if (StudentId == null)
            {
                return "Empty Id";
            }
            else
            {
                var student = await _unitOfWork.Students.FindById(StudentId);
                if (student == null)
                {
                    return string.Format(_localizer["Can't Find This Student"]); ;
                }
                else
                {


                    await _unitOfWork.Students.Delete(student);
                    await _unitOfWork.Students.CommitChanges();
                    return string.Format(_localizer["Student Deleted Successfull"]);
                }
            }
        }

        public async Task<List<Student>> GetAllStudents()
        {
            var students = await _unitOfWork.Students.GetAll();
            return students.ToList();
        }

        public async Task<ReturnStudentDto> UpdateDtudent(EditStudentDto dto)
        {
            var output = new ReturnStudentDto();

            var studentExist = await _unitOfWork.Students.FindById(dto.Id);
            if (studentExist == null)
            {
                output.Message = string.Format(_localizer["Student Not Found"]);
            }
            else
            {
                // تحديث الخصائص يدوياً أو باستخدام AutoMapper
                studentExist.FullName = dto.FullName;
                studentExist.Age = dto.Age;
                studentExist.BirthDate = dto.BirthDate;
                studentExist.ClassId = dto.ClassId;

                await _unitOfWork.Students.Update(studentExist);
                await _unitOfWork.Students.CommitChanges();
                output.Student = studentExist;
            }
            return output;
        }

    }
}

