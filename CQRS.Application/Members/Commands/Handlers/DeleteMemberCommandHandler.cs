using CQRS.Domain.Entities;
using CQRS.Domain.Interfaces;
using MediatR;

namespace CQRS.Application.Members.Commands.Handlers
{
    public class DeleteMemberCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteMemberCommand, Member?>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Member?> Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
        {
            var member = await _unitOfWork.MemberRepository.Delete(request.Id);

            if (member == null)
                return null;

            await _unitOfWork.CommitAsync();
            return member;
        }
    }
}
