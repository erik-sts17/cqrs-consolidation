using CQRS.Domain.Entities;
using CQRS.Domain.Interfaces.Members;
using CQRS.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Infra.Repositories.Members
{
    public class MemberRepository(AppDbContext _context) : IMemberRepository
    {
        protected readonly AppDbContext context = _context;

        public async Task<Member> Add(Member entity)
        {
            await context.Members.AddAsync(entity);
            return entity;
        }

        public async Task<Member?> Delete(int id)
        {
            var member = await GetById(id);
            if (member != null)
                context.Remove(member);
            return member;
        }

        public async Task<IEnumerable<Member>> GetAll()
        {
            var members = await context.Members.ToListAsync();
            return members ?? Enumerable.Empty<Member>();
        }

        public async Task<Member?> GetById(int id)
        {
            var member = await context.Members.FindAsync(id);
            return member;
        }

        public void Update(Member entity)
        {
            context.Update(entity);
        }
    }
}
