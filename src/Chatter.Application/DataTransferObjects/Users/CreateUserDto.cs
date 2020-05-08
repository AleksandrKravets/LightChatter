namespace Chatter.Application.DataTransferObjects.Users
{
    public class CreateUserDto
    {
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
    }
}
