using MediatR;
using Microsoft.Extensions.Logging;

namespace CQRS.Application.Members.Commands.Notifications.Handlers
{
    public class MemberCreatedEmailHandler(ILogger<MemberCreatedEmailHandler> logger) : INotificationHandler<MemberCreatedNotification>
    {
        private readonly ILogger<MemberCreatedEmailHandler> _logger = logger;

        public Task Handle(MemberCreatedNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Confirmation email sent for: {notification.Member.FirstName}");
            return Task.CompletedTask;
        }
    }
}