namespace AbankApi.Application.Dtos.User
{
    public class CreateUserDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Phone { get; set; }
        public required string Email { get; set; }
        public required string Address { get; set; }
        public required string Password { get; set; }
    }
}
