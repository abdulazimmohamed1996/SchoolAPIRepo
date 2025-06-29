using Mapster;
using Microsoft.Extensions.Localization;
using SchoolWith.Core.Dtos.Classes;
using SchoolWith.Core.Dtos.SharedDtos;
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
    public class ClassServices : BaseRepository<Class>, IClassService
    {
        private readonly SchoolDbContext _context;
        private IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<string> _localizer;

        public ClassServices(SchoolDbContext context, IUnitOfWork unitOfWork, IStringLocalizer<string> localizer) : base(context)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _localizer = localizer;
        }

        public async Task<ReturnClassDto> addClass(AddClassDto addClassDto)
        {
            var output = new ReturnClassDto();
            var exitClass = await _unitOfWork.Classes.Find(Class => Class.Name == addClassDto.Name);
            if (exitClass != null) {
                output.Message = string.Format(_localizer["Class Name already exsist"]);
            }
            else
            {
                var addedClass = addClassDto.Adapt<Class>();
                await _unitOfWork.Classes.Add(addedClass);
                await _unitOfWork.Classes.CommitChanges();
                output.Class = addedClass;
            }
            return output;
        }

        public async Task<List<Class>> getAllClasses()
        {
            var allClasses = await _unitOfWork.Classes.GetAll();
            return allClasses.ToList();      
        }

        public async Task<ReturnClassDto> updateClass(EditClassDto editClassDto)
        {
            var output = new ReturnClassDto();
            var classExit = await _unitOfWork.Classes.FindById(editClassDto.Id);
            if(classExit == null) {
                output.Message = string.Format(_localizer["Class Not Found"]);
            }
            else
            {
                classExit.Name = editClassDto.Name;
                await _unitOfWork.Classes.Update(classExit);
                await _unitOfWork.Classes.CommitChanges();
                output.Class = classExit;
            }
            return output;
        }

        public async Task<DeletDto> deleteClass(int classId)
        {
            var output = new DeletDto();
            if (classId == null)
            {
                output.Fail = "Empty Id";
                return output;
            }
            else
            {
                var clas = await _unitOfWork.Classes.FindById(classId);
                if (clas == null)
                {

                    output.Fail = string.Format(_localizer["Can't Find This Class"]);
                    return output;
                    //return string.Format(_localizer["Can't Find This Student"]); ;
                }
                else
                {


                    await _unitOfWork.Classes.Delete(clas);
                    await _unitOfWork.Classes.CommitChanges();

                    output.Success = string.Format(_localizer["Class Deleted Successfull"]);
                    return output;
                    //return string.Format(_localizer["Student Deleted Successfull"]);
                }
            }
        }
    }
}
