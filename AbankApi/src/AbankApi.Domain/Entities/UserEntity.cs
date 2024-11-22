using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace AbankApi.Domain.Entities
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        [Column("first_name")]
        public required string FirstName { get; set; }
        [Column("last_name")]
        public required string LastName { get; set; }
        [Column("date_of_birth")]
        public DateTime DateOfBirth { get; set; }
        [Column("address")]
        public required string Address { get; set; }
        [Column("password")]
        public required string Password { get; set; }
        [Column("phone")]
        public string? Phone { get; set; }
        [Column("email")]
        public required string Email { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
