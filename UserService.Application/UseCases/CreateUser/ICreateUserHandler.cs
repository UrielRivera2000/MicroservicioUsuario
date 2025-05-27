using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain.Entitites;

namespace UserService.Application.UseCases.CreateUser
{
    public interface ICreateUserHandler
    {
        Task HandleAsync(User user);
    }
}
