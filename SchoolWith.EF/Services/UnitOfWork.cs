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

        public UnitOfWork(SchoolDbContext context, IStringLocalizer<string> localizer)
        {
            _context = context;
            Students = new StudentServices(_context, this, localizer);
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
