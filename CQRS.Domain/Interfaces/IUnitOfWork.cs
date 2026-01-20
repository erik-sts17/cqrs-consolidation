using CQRS.Domain.Interfaces.Members;

namespace CQRS.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public IMemberRepository MemberRepository { get; }
        Task CommitAsync();
    }
}