using UserService.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
    }
}
