using CQRS.Domain.Entities;
using MediatR;

namespace CQRS.Application.Members.Commands.Notifications
{
    public class MemberCreatedNotification(Member member) : INotification
    {
        public Member Member { get; set; } = member;
    }
}