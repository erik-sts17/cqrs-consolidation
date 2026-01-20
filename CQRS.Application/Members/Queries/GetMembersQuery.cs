using CQRS.Domain.Entities;
using MediatR;

namespace CQRS.Application.Members.Queries
{
    public class GetMembersQuery : IRequest<IEnumerable<Member>>
    {
    }
}