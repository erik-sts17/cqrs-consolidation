using CQRS.Domain.Entities;
using MediatR;

namespace CQRS.Application.Members.Queries
{
    public class GetMemberByIdQuery : IRequest<Member>
    {
        public int Id { get; set; }
    }
}