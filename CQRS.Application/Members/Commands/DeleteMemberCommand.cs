using CQRS.Domain.Entities;
using MediatR;

namespace CQRS.Application.Members.Commands
{
    public class DeleteMemberCommand : IRequest<Member>
    {
        public int Id { get; set; }
    }
}