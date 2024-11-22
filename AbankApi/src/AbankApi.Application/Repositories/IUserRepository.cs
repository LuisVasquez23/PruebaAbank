using AbankApi.Domain.Entities;

namespace AbankApi.Application.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserEntity>> GetAllAsync();
        Task<UserEntity?> FindByIdAsync(int id);
        Task<UserEntity> CreateAsync(UserEntity user);
        Task<UserEntity> UpdateAsync(UserEntity user);
        Task<UserEntity?> DeleteAsync(int id);
        Task<UserEntity?> FindByEmailAndPasswordAsync(string email, string password);
    }
}
