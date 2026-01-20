using CQRS.Domain.Entities;
using CQRS.Domain.Interfaces.Members;
using MediatR;

namespace CQRS.Application.Members.Queries.Handlers
{
    public class GetMemberByIdQueryHandler(IMemberDapperRepository memberDapperRepository) : IRequestHandler<GetMemberByIdQuery, Member?>
    {
        private readonly IMemberDapperRepository _memberDapperRepository = memberDapperRepository;

        public async Task<Member?> Handle(GetMemberByIdQuery request, CancellationToken cancellationToken)
        {
            return await _memberDapperRepository.GetById(request.Id);
        }
    }
}