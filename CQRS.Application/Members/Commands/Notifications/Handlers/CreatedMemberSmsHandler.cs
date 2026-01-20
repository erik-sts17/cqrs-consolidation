using MediatR;
using Microsoft.Extensions.Logging;

namespace CQRS.Application.Members.Commands.Notifications.Handlers
{
    public class CreatedMemberSmsHandler(ILogger<CreatedMemberSmsHandler> logger) : INotificationHandler<MemberCreatedNotification>
    {
        private readonly ILogger<CreatedMemberSmsHandler> _logger = logger;

        public Task Handle(MemberCreatedNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Confirmation sms sent for: {notification.Member.FirstName}");
            return Task.CompletedTask;
        }
    }
}