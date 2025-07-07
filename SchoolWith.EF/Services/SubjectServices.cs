using Mapster;
using Microsoft.Extensions.Localization;
using SchoolWith.Core.Dtos.Subjects;
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
                await _unitOfWork.Supjects.AddSubject(addSubjectDto);
                await _unitOfWork.Supjects.CommitChanges();
                output.Subject = addedSubject;
            }
            return output;
        }
    }
}
