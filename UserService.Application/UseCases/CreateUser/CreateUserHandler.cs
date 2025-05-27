
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Application.Interfaces;
using UserService.Application.UseCases;
using UserService.Domain.Entitites;
using UserService.Domain.Interfaces;

namespace UserService.Application.UseCases.CreateUser
{
    public class CreateUserHandler:ICreateUserHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly INotificationService _notificationService;
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(typeof(CreateUserHandler));

        public CreateUserHandler(IUserRepository userRepository, INotificationService notificationService)
        {
            _userRepository = userRepository;
            _notificationService = notificationService;
        }

        public async Task HandleAsync(User user)
        {
            try
            {
                await _userRepository.AddAsync(user);
                await _notificationService.SendEmailNotificationAsync(user.Email, "¡Bienvenido a la plataforma!");
                _logger.Info($"Usuario creado y notificado: {user.Email}");
            }
            catch (Exception ex)
            {
                _logger.Error("Error al crear usuario", ex);
                throw;
            }
        }
    }
}
