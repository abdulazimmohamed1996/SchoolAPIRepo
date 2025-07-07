using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWith.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentService Students { get; }
        IClassService Classes { get; }
        ITeacherServices Teachers { get; }
        ISupjectServices Supjects { get; }
        Task<int> Complete();
    }
}
