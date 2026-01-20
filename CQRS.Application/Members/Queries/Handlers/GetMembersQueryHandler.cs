using CQRS.Domain.Entities;
using CQRS.Domain.Interfaces.Members;
using MediatR;

namespace CQRS.Application.Members.Queries.Handlers
{
    public class GetMembersQueryHandler(IMemberDapperRepository memberDapperRepository) : IRequestHandler<GetMembersQuery, IEnumerable<Member>>
    {
        private readonly IMemberDapperRepository _memberDapperRepository = memberDapperRepository;

        public async Task<IEnumerable<Member>> Handle(GetMembersQuery request, CancellationToken cancellationToken)
        {
            return await _memberDapperRepository.GetAll();
        }
    }
}
