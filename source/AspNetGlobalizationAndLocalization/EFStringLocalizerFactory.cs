using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetGlobalizationAndLocalization.Data;
using AspNetGlobalizationAndLocalization.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AspNetGlobalizationAndLocalization
{
    public class EFStringLocalizerFactory : IStringLocalizerFactory
    {
        private readonly ApplicationDbContext _db;
        public EFStringLocalizerFactory(ApplicationDbContext db)
        {
            _db = db;
        }

        public IStringLocalizer Create(Type resourceSource)
        {
            return new EFStringLocalizer(_db);
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            return new EFStringLocalizer(_db);
        }
    }
}
