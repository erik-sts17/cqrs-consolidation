using CQRS.Domain.Entities;
using MediatR;

namespace CQRS.Application.Members.Commands
{
    public class UpdateMemberCommand : MemberCommandBase, IRequest<Member>
    {
        public int Id { get; set; }
    }
}
