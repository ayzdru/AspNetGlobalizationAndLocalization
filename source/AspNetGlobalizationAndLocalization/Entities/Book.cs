using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xaki;

namespace AspNetGlobalizationAndLocalization.Entities
{
    public class Book : ILocalizable
    {
        public int Id { get; set; }

        [Required(ErrorMessage = DataAnnotationMessages.Required), Localized]
        public string Name { get; set; }

        [Localized, DataType(DataType.Html)]
        public string Description { get; set; }
    }
}
