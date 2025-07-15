using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Core.DTOs;

namespace LibraryManagementSystem.Core.Interfaces
{
    public interface IAuthService
    {
        public Task RegisterAsync(RegisterDTO dto);
        public Task<string> LoginAsync(LoginDTO dto);
    }
}
