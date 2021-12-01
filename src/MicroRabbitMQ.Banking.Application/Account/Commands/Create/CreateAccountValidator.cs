using FluentValidation;

namespace MicroRabbitMQ.Banking.Application.Account.Commands.Create {
    public class CreateAccountValidator : AbstractValidator<CreateAccount> {
        public CreateAccountValidator() {
            RuleFor(v => v.AccountType)
                .Must(BeCheckingOrSavings)
                .NotEmpty();
        }

        private bool BeCheckingOrSavings(string accountType) {
            return accountType == "Checking" || accountType == "Savings";
        }
    }
}
