using LearnAngular.API.Data;
using LearnAngular.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace LearnAngular.API.Repositories.Implementation
{
    public class UserRepository: IUserRepository
    {
        private readonly MongoDbContext _dbContext; // Assuming you have a DbContext for MongoDB, otherwise this can be removed.

        public UserRepository(MongoDbContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbContext.Users.ToListAsync();  
        }
    }
}
