using CQRS.Domain.Entities;

namespace CQRS.Domain.Interfaces.Members
{
    public interface IMemberDapperRepository
    {
        Task<IEnumerable<Member>> GetAll();
        Task<Member?> GetById(int id);
    }
}