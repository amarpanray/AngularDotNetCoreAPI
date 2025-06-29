using LearnAngular.API.Models.Domain;

namespace LearnAngular.API.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        Task<IEnumerable<User>> GetAllAsync();

        //Task<User?> GetByIdAsync(ObjectId id);
        //Task<User?> UpdateAsync(User user);
        //Task<bool> DeleteAsync(ObjectId id);
    }
}
