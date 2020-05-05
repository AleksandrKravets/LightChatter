using Chatter.Application.Contracts.Validators;
using Chatter.Common.ConfigurationModels;
using Microsoft.Extensions.Options;

namespace Chatter.Application.Infrastructure.Validators
{
    public class PasswordValidator : IPasswordValidator
    {
        private readonly PasswordHandler _handler;
        private readonly PasswordSettings _passwordSettings;

        public PasswordValidator(IOptions<PasswordSettings> passwordSettings)
        {
            _passwordSettings = passwordSettings.Value;
            _handler = new PasswordLengthHandler();
        }

        public bool ValidatePassword(string password)
        {
            return _handler.Handle(password, _passwordSettings);
        }
    }

    public abstract class PasswordHandler
    {
        public PasswordHandler _nextHandler;

        public PasswordHandler NextHandler(PasswordHandler nextHandler)
        {
            this._nextHandler = nextHandler;
            return nextHandler;
        }

        public abstract bool Handle(string password, PasswordSettings settings);
    }

    public class PasswordLengthHandler : PasswordHandler
    {
        public override bool Handle(string password, PasswordSettings settings)
        {
            if (password.Length < settings.RequiredLength)
                return false;

            return _nextHandler == null ? true :  _nextHandler.Handle(password, settings);
        }
    }
}
