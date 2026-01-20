using CQRS.Domain.Entities;
using CQRS.Domain.Interfaces.Members;
using Dapper;
using System.Data;

namespace CQRS.Infra.Repositories.Members
{
    public class MemberDapperRepository(IDbConnection dbConnection) : IMemberDapperRepository
    {
        private readonly IDbConnection _dbConnection = dbConnection;

        public async Task<IEnumerable<Member>> GetAll()
        {
            string query = "SELECT * FROM MEMBERS";
            return await _dbConnection.QueryAsync<Member>(query);
        }

        public async Task<Member?> GetById(int id)
        {
            string query = "SELECT * FROM MEMBERS WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Member>(query, new { Id = id });
        }
    }
}