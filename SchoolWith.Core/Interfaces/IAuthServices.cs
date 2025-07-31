using SchoolWith.Core.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWith.Core.Interfaces
{
    public interface IAuthServices
    {
        Task<ReturnAuth> AddUser(AddUserDto userRegister);
        Task<ReturnAuth> EditUser(EditUserDto userDto);
    }
}
