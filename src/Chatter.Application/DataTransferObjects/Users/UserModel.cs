namespace Chatter.Application.DataTransferObjects.Users
{
    public class UserModel
    {
        public long Id { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public int RoleId { get; set; }
    }
}
