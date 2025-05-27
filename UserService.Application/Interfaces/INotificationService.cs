using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendEmailNotificationAsync(string email, string message);
    }
}
