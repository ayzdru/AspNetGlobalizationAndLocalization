using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Microsoft.VisualBasic;

namespace AspNetGlobalizationAndLocalization
{
    public class MultilanguageIdentityErrorDescriber : IdentityErrorDescriber
    {
        private readonly IStringLocalizer<IdentityErrorMessages> _localizer;
        public MultilanguageIdentityErrorDescriber(IStringLocalizer<IdentityErrorMessages> localizer)
        {
            _localizer = localizer;
        }
        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError()
            {
                Code = nameof(DuplicateEmail),
                Description = string.Format(_localizer[IdentityErrorMessages.DuplicateEmail], email)
            };
        }
        public override IdentityError PasswordRequiresUniqueChars(int uniqueChars)
        {
            return new IdentityError { Code = nameof(PasswordRequiresUniqueChars), Description = _localizer[IdentityErrorMessages.PasswordRequiresUniqueChars] };
        }
        public override IdentityError RecoveryCodeRedemptionFailed()
        {
            return new IdentityError { Code = nameof(RecoveryCodeRedemptionFailed), Description = _localizer[IdentityErrorMessages.RecoveryCodeRedemptionFailed] };

        }
        public override IdentityError DefaultError() { return new IdentityError { Code = nameof(DefaultError), Description = _localizer[IdentityErrorMessages.DefaultError] }; }
        public override IdentityError ConcurrencyFailure() { return new IdentityError { Code = nameof(ConcurrencyFailure), Description = _localizer[IdentityErrorMessages.ConcurrencyFailure] }; }
        public override IdentityError PasswordMismatch() { return new IdentityError { Code = nameof(PasswordMismatch), Description = _localizer[IdentityErrorMessages.PasswordMismatch] }; }
        public override IdentityError InvalidToken() { return new IdentityError { Code = nameof(InvalidToken), Description = _localizer[IdentityErrorMessages.InvalidToken] }; }
        public override IdentityError LoginAlreadyAssociated() { return new IdentityError { Code = nameof(LoginAlreadyAssociated), Description = _localizer[IdentityErrorMessages.LoginAlreadyAssociated] }; }
        public override IdentityError InvalidUserName(string userName) { return new IdentityError { Code = nameof(InvalidUserName), Description = string.Format(_localizer[IdentityErrorMessages.InvalidUserName], userName) }; }
        public override IdentityError InvalidEmail(string email) { return new IdentityError { Code = nameof(InvalidEmail), Description = string.Format(_localizer[IdentityErrorMessages.InvalidEmail], email) }; }
        public override IdentityError DuplicateUserName(string userName) { return new IdentityError { Code = nameof(DuplicateUserName), Description = string.Format(_localizer[IdentityErrorMessages.DuplicateUserName], userName) }; }
        public override IdentityError InvalidRoleName(string role) { return new IdentityError { Code = nameof(InvalidRoleName), Description = string.Format(_localizer[IdentityErrorMessages.InvalidRoleName], role) }; }
        public override IdentityError DuplicateRoleName(string role) { return new IdentityError { Code = nameof(DuplicateRoleName), Description = string.Format(_localizer[IdentityErrorMessages.DuplicateRoleName], role) }; }
        public override IdentityError UserAlreadyHasPassword() { return new IdentityError { Code = nameof(UserAlreadyHasPassword), Description = _localizer[IdentityErrorMessages.UserAlreadyHasPassword] }; }
        public override IdentityError UserLockoutNotEnabled() { return new IdentityError { Code = nameof(UserLockoutNotEnabled), Description = _localizer[IdentityErrorMessages.UserLockoutNotEnabled] }; }
        public override IdentityError UserAlreadyInRole(string role) { return new IdentityError { Code = nameof(UserAlreadyInRole), Description = string.Format(_localizer[IdentityErrorMessages.UserAlreadyInRole], role) }; }
        public override IdentityError UserNotInRole(string role) { return new IdentityError { Code = nameof(UserNotInRole), Description = string.Format(_localizer[IdentityErrorMessages.UserNotInRole], role) }; }
        public override IdentityError PasswordTooShort(int length) { return new IdentityError { Code = nameof(PasswordTooShort), Description = string.Format(_localizer[IdentityErrorMessages.PasswordTooShort], length) }; }
        public override IdentityError PasswordRequiresNonAlphanumeric() { return new IdentityError { Code = nameof(PasswordRequiresNonAlphanumeric), Description = _localizer[IdentityErrorMessages.PasswordRequiresNonAlphanumeric] }; }
        public override IdentityError PasswordRequiresDigit() { return new IdentityError { Code = nameof(PasswordRequiresDigit), Description = _localizer[IdentityErrorMessages.PasswordRequiresDigit] }; }
        public override IdentityError PasswordRequiresLower() { return new IdentityError { Code = nameof(PasswordRequiresLower), Description = _localizer[IdentityErrorMessages.PasswordRequiresLower] }; }
        public override IdentityError PasswordRequiresUpper() { return new IdentityError { Code = nameof(PasswordRequiresUpper), Description = _localizer[IdentityErrorMessages.PasswordRequiresUpper] }; }
    }
}
