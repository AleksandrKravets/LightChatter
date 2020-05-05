namespace Chatter.Domain.Dto
{
    public class TokensResponseModel
    {
        public AccessToken AccessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}
