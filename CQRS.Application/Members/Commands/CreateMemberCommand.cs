using CQRS.Domain.Entities;
using MediatR;

namespace CQRS.Application.Members.Commands
{
    public class CreateMemberCommand : MemberCommandBase, IRequest<Member>
    {
    }
}