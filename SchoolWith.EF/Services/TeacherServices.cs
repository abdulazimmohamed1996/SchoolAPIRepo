using Mapster;
using Microsoft.Extensions.Localization;
using SchoolWith.Core.Dtos.SharedDtos;
using SchoolWith.Core.Dtos.Teachers;
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
    public class TeacherServices : BaseRepository<Teacher> , ITeacherServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<string> _localizer;
        private readonly SchoolDbContext _context;
        public TeacherServices(SchoolDbContext context, IUnitOfWork unitOfWork, IStringLocalizer<string> localizer) : base(context)
        {
            _unitOfWork = unitOfWork;
            _localizer = localizer;
            _context = context;
        }

        public async Task<ReturnTeacherDto> AddTeacher(addteacherDto addteacherDto)
        {
            var output = new ReturnTeacherDto();
            var teacherExit = await _unitOfWork.Teachers.Find(teacher => teacher.Name == addteacherDto.Name);
            if (teacherExit != null) {
                output.Message = string.Format(_localizer["Teacher Name already exsist"]);
            }
            else
            {
                var addedTeacher = addteacherDto.Adapt<Teacher>();
                await _unitOfWork.Teachers.Add(addedTeacher);
                await _unitOfWork.Teachers.CommitChanges();
                output.Teacher = addedTeacher;
            }
            return output;
        }

        public async Task<DeletDto> deleteTeacher(int teacherId)
        {

            var result = new DeletDto();
            if (teacherId == null)
            {

                result.Fail = "Empty Id";
                return result;
            }
            else
            {
                var teacher = await _unitOfWork.Teachers.FindById(teacherId);
                if (teacher == null)
                {

                    result.Fail = string.Format(_localizer["Can't Find This Teacher"]);
                    return result;
                    //return string.Format(_localizer["Can't Find This Student"]); ;
                }
                else
                {


                    await _unitOfWork.Teachers.Delete(teacher);
                    await _unitOfWork.Students.CommitChanges();

                    result.Success = string.Format(_localizer["Teacher Deleted Successfull"]);
                    return result;
                    //return string.Format(_localizer["Student Deleted Successfull"]);
                }
            }
        }

        public async Task<ReturnTeacherDto> editTeacher(EditTeacherDto editTeacherDto)
        {
            var output = new ReturnTeacherDto();
            var teacherExist = await _unitOfWork.Teachers.FindById(editTeacherDto.Id);
            if (teacherExist == null)
            {
                output.Message = string.Format(_localizer["Teacher Not Found"]);
            }
            else
            {
                // تحديث الخصائص يدوياً أو باستخدام AutoMapper
                teacherExist.Name = editTeacherDto.Name;
                await _unitOfWork.Teachers.Update(teacherExist);
                await _unitOfWork.Students.CommitChanges();
                output.Teacher = teacherExist;
            }
            return output;

        }

        public async Task<List<Teacher>> getAllTeachers()
        {
            var allTeachers=await _unitOfWork.Teachers.GetAll();
            return allTeachers.ToList();
        }
    }
}
