using AbankApi.Application.Repositories;
using AbankApi.Domain.Entities;
using Dapper;
using System.Data;

namespace AbankApi.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly IDbConnection _connection;

        public UserRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        #region GET USERS
        public async Task<IEnumerable<UserEntity>> GetAllAsync()
        {
            return await _connection.QueryAsync<UserEntity>("SELECT * FROM users");
        }
        #endregion

        #region GET USER BY ID 
        public async Task<UserEntity?> FindByIdAsync(int id)
        {
            var query = "SELECT * FROM Users WHERE Id = @Id";
            return await _connection.QueryFirstOrDefaultAsync<UserEntity>(query, new { Id = id });
        }
        #endregion

        #region CREATE USER 
        public async Task<UserEntity> CreateAsync(UserEntity user)
        {
            var query = @"
            INSERT INTO Users (first_name, last_name , date_of_birth , address , password , phone , email , created_at )
            VALUES (@FirstName, @LastName, @DateOfBirth, @Address, @Password, @Phone, @Email, @CreatedAt)
            RETURNING *";

            return await _connection.QuerySingleAsync<UserEntity>(query, new
            {
                user.FirstName,
                user.LastName,
                user.DateOfBirth,
                user.Address,
                user.Password,
                user.Phone,
                user.Email,
                CreatedAt = DateTime.UtcNow
            });
        }
        #endregion

        #region DELETE USER 
        public async Task<UserEntity?> DeleteAsync(int id)
        {
            var query = "DELETE FROM Users WHERE Id = @Id RETURNING *";
            return await _connection.QuerySingleOrDefaultAsync<UserEntity>(query, new { Id = id });
        }
        #endregion

        #region UPDATE USER 
        public async Task<UserEntity> UpdateAsync(UserEntity user)
        {
            var query = @"
            UPDATE Users SET
                first_name = @FirstName,
                last_name = @LastName,
                date_of_birth = @DateOfBirth,
                address = @Address,
                phone = @Phone,
                email = @Email,
                updated_at = @UpdatedAt
            WHERE Id = @Id
            RETURNING *";

            return await _connection.QuerySingleAsync<UserEntity>(query, new
            {
                user.FirstName,
                user.LastName,
                user.DateOfBirth,
                user.Address,
                user.Phone,
                user.Email,
                UpdatedAt = DateTime.UtcNow,
                user.Id
            });
        }

        #endregion

        #region GET USER BY EMAIL AND PASSWORD 
        public async Task<UserEntity?> FindByEmailAndPasswordAsync(string email, string password)
        {
            var query = "SELECT * FROM users WHERE email = @email AND password = @password";
            return await _connection.QueryFirstOrDefaultAsync<UserEntity>(query, new { Email = email, Password = password });
        }
        #endregion
    }
}
