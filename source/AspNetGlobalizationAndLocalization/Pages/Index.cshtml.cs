using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetGlobalizationAndLocalization.Data;
using AspNetGlobalizationAndLocalization.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Xaki;

namespace AspNetGlobalizationAndLocalization.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IObjectLocalizer _objectLocalizer;
        private readonly IHtmlLocalizer<IndexModel> _htmlLocalizer;

        public IndexModel(ApplicationDbContext dbContext, IObjectLocalizer objectLocalizer, IHtmlLocalizer<IndexModel> htmlLocalizer)
        {
            _dbContext = dbContext;
            _objectLocalizer = objectLocalizer;
            _htmlLocalizer = htmlLocalizer;
        }
        public List<Book> Books { get; set; }
        public void OnGet()
        {
            Books = _dbContext.Books.ToList();
            Books = _objectLocalizer.Localize<Book>(Books).ToList();
            ViewData["Message"] = _htmlLocalizer["Html Yerelleştirme : <b>Merhaba</b><i> {0}</i>", "Ayaz Duru"];
        }

        
        public IActionResult OnPostSetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }
}
