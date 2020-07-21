using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetGlobalizationAndLocalization
{
    public class ModelBindingMessages
    {
        public const string ModelState_AttemptedValueIsInvalid = "{1} alanı için '{0}' değeri geçersiz.";

        public const string ModelBinding_MissingBindRequiredMember = "'{0}' parametresi veya özelliği için bir değer verilmedi.";

        public const string KeyValuePair_BothKeyAndValueMustBePresent = "Bir değer gerekli.";

        public const string ModelBinding_MissingRequestBodyRequiredMember = "Boş olmayan bir istek gövdesi gereklidir.";

        public const string ModelState_NonPropertyAttemptedValueIsInvalid = "'{0}' değeri geçerli değil.";

        public const string ModelState_NonPropertyUnknownValueIsInvalid = "Sağlanan değer geçersiz.";

        public const string HtmlGeneration_NonPropertyValueMustBeNumber = "Alan bir sayı olmalıdır.";

        public const string ModelState_UnknownValueIsInvalid = "{0} alanı için sağlanan değer geçersiz.";

        public const string HtmlGeneration_ValueIsInvalid = "'{0}' değeri geçersiz.";

        public const string HtmlGeneration_ValueMustBeNumber = "{0} alanı bir sayı olmalıdır.";

        public const string ModelBinding_NullValueNotValid = "'{0}' değeri geçersiz.";
    }
}
