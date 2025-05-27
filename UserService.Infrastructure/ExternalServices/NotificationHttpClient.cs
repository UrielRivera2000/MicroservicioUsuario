using UserService.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Infrastructure.ExternalServices
{
    public class NotificationHttpClient : INotificationService
    {
        private readonly HttpClient _client;
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(typeof(NotificationHttpClient));

        public NotificationHttpClient(HttpClient client)
        {
            _client = client;
        }

        public async Task SendEmailNotificationAsync(string email, string message)
        {
            try
            {
                var content = JsonContent.Create(new { email, message });
                var response = await _client.PostAsync("/api/notifications/email", content);
                response.EnsureSuccessStatusCode();
                _logger.Info($"Notificación enviada a: {email}");
            }
            catch (Exception ex)
            {
                _logger.Error("Error al enviar notificación", ex);
                throw;
            }
        }
    }
}
