using CQRS.Domain.Interfaces;
using CQRS.Domain.Interfaces.Members;
using CQRS.Infra.Context;
using CQRS.Infra.Repositories.Members;

namespace CQRS.Infra.Repositories
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork, IDisposable
    {
        private readonly IMemberRepository? _memberRepository;
        private readonly AppDbContext _context = context;

        public IMemberRepository MemberRepository => _memberRepository ?? new MemberRepository(_context);

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
