using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetGlobalizationAndLocalization
{
    public class IdentityErrorMessages
    {
        public const string ConcurrencyFailure = "İyimser eşzamanlılık hatası, nesne değiştirildi.";
        public const string DefaultError = "Bilinmeyen bir hata oluştu.";
        public const string DuplicateEmail = "'{0}' e-postası zaten alınmış.";
        public const string DuplicateUserName = "'{0}' kullanıcı adı zaten alınmış.";
        public const string InvalidEmail = "'{0}' e-postası geçersiz.";
        public const string DuplicateRoleName = "Rol adı '{0}' zaten alınmış.";
        public const string InvalidRoleName = "Rol adı '{0}' geçersiz.";
        public const string InvalidToken = "Geçersiz token.";
        public const string InvalidUserName = "'{0}' kullanıcı adı geçersiz, sadece harf veya rakam içerebilir.";
        public const string LoginAlreadyAssociated = "Bu girişe sahip bir kullanıcı zaten var.";
        public const string PasswordMismatch = "Yanlış şifre.";
        public const string PasswordRequiresDigit = "Şifreler en az bir rakam içermelidir ('0'-'9').";
        public const string PasswordRequiresLower = "Şifreler en az bir küçük harf içermelidir ('a'-'z').";
        public const string PasswordRequiresNonAlphanumeric = "Şifreler en az bir alfasayısal olmayan karakter içermelidir.";
        public const string PasswordRequiresUniqueChars = "Şifreler en az {0} farklı karakter kullanmalıdır.";
        public const string PasswordRequiresUpper = "Şifreler en az bir büyük harfe sahip olmalıdır ('A'-'Z').";
        public const string PasswordTooShort = "Şifreler en az {0} karakter olmalıdır.";
        public const string UserAlreadyHasPassword = "Kullanıcının zaten bir şifre seti var.";
        public const string UserAlreadyInRole = "Kullanıcı zaten '{0}' rolünde.";
        public const string UserNotInRole = "Kullanıcı '{0}' rolünde değil.";
        public const string UserLockoutNotEnabled = "Kilitleme bu kullanıcı için etkin değil.";
        public const string RecoveryCodeRedemptionFailed = "Kurtarma kodu kullanımı başarısız oldu.";
    }
}
