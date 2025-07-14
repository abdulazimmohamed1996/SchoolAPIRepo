using Mapster;
using Microsoft.Extensions.Localization;
using SchoolWith.Core.Dtos.SharedDtos;
using SchoolWith.Core.Dtos.Subjects;
using SchoolWith.Core.Interfaces;
using SchoolWith.Core.Models;
using SchoolWith.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWith.EF.Services
{
    internal class SubjectServices : BaseRepository<Subject>, ISupjectServices
    {
        private readonly SchoolDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<string> _localizer;
        public SubjectServices(SchoolDbContext context, IUnitOfWork unitOfWork, IStringLocalizer<string> localizer) : base(context)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _localizer = localizer;
        }

        public async Task<ReturnSupjectDto> AddSubject(AddSubjectDto addSubjectDto)
        {
            var output = new ReturnSupjectDto();
            var dupjectExit = await _unitOfWork.Supjects.Find(s=>s.Name == addSubjectDto.Name);
            if (dupjectExit != null) {
                output.Message = string.Format(_localizer["Subject Name already exsist"]);
            }
            else
            {
                var addedSubject = addSubjectDto.Adapt<Subject>();
                await _unitOfWork.Supjects.Add(addedSubject);
                await _unitOfWork.Supjects.CommitChanges();
                output.Subject = addedSubject;
            }
            return output;
        }

        public async Task<DeletDto> DeletSupject(int supjectId)
        {
            var output = new DeletDto();
            if(supjectId == null)
            {
                output.Fail = string.Format(_localizer["Empty Id"]);
                return output;
            }
            else
            {
                var supject = await _unitOfWork.Supjects.FindById(supjectId);
                if(supject == null)
                {
                    output.Fail = string.Format(_localizer["Can't Find This Supject"]);
                    return output;
                }
                await _unitOfWork.Supjects.Delete(supject);
                await _unitOfWork.Supjects.CommitChanges();
                output.Success = string.Format(_localizer["Supject Deleted Successfull"]);
                return output;

            }
        }

        public async Task<ReturnSupjectDto> EditSupject(EditSupjectDto editSupjectDto)
        {
            var output = new ReturnSupjectDto();
            var exitSubject = await _unitOfWork.Supjects.FindById(editSupjectDto.Id);
            if(exitSubject == null)
            {
                output.Message = string.Format(_localizer["Subject Not Found"]);
            }
            else
            {
                exitSubject.Name = editSupjectDto.Name;
                exitSubject.teacherId = editSupjectDto.teacherId;
                await _unitOfWork.Supjects.Update(exitSubject);
                await _unitOfWork.Supjects.CommitChanges();
                output.Subject = exitSubject;
            }
            return output;
        }

        public async Task<List<Subject>> getAllSubjects()
        {
            var AllSubjects = await _unitOfWork.Supjects.GetAll();
            return AllSubjects.ToList();
        }
    }
}
