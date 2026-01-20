using CQRS.Application.Members.Commands.Notifications;
using CQRS.Domain.Entities;
using CQRS.Domain.Interfaces;
using MediatR;

namespace CQRS.Application.Members.Commands.Handlers
{
    public class CreateMemberCommandHandler(IUnitOfWork unitOfWork, IMediator mediator) : IRequestHandler<CreateMemberCommand, Member>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMediator _mediator = mediator;

        public async Task<Member> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            var member = new Member(request.FirstName, request.LastName, request.Gender, request.Email, request.Active);
            
            await _unitOfWork.MemberRepository.Add(member);
            await _unitOfWork.CommitAsync();

            await _mediator.Publish(new MemberCreatedNotification(member), cancellationToken);

            return member;
        }
    }
}