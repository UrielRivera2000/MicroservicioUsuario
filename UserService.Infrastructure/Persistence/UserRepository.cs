using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain.Entitites;
using UserService.Domain.Interfaces;

namespace UserService.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        public Task AddAsync(User user)
        {
            // Aquí simulas guardado en base de datos (por ahora)
            return Task.CompletedTask;
        }
    }
}
