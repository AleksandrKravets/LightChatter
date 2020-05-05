namespace Chatter.Application.Contracts.Validators
{
    public interface IPasswordValidator
    {
        bool ValidatePassword(string password);
    }
}
