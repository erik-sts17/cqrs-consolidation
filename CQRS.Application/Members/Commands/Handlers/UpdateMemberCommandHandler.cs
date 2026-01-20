using CQRS.Domain.Entities;
using CQRS.Domain.Interfaces;
using MediatR;

namespace CQRS.Application.Members.Commands.Handlers
{
    public class UpdateMemberCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateMemberCommand, Member?>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Member?> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
        {
            var member = await _unitOfWork.MemberRepository.GetById(request.Id);

            if (member == null)
                return member;
            
            member.Update(request.FirstName, request.LastName, request.Gender, request.Email, request.Active);
            _unitOfWork.MemberRepository.Update(member);
            await _unitOfWork.CommitAsync();
            
            return member;
        }
    }
}