using Microsoft.Extensions.Localization;
using SchoolWith.Core.Interfaces;
using SchoolWith.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWith.EF.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SchoolDbContext _context;
        public IStudentService Students { get; private set; }

        public IClassService Classes { get; private set; }

        public ITeacherServices Teachers { get; private set; }

        public ISupjectServices Supjects { get; private set; }

        public UnitOfWork(SchoolDbContext context, IStringLocalizer<string> localizer)
        {
            _context = context;
            Students = new StudentServices(_context, this, localizer);
            Classes = new ClassServices(_context, this,localizer);
            Teachers = new TeacherServices(_context, this, localizer);
            Supjects = new SubjectServices(_context, this, localizer);

        }

        public async Task<int> Complete()
        {
           return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
