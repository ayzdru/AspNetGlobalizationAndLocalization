using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetGlobalizationAndLocalization.Data;
using AspNetGlobalizationAndLocalization.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Xaki;

namespace AspNetGlobalizationAndLocalization.Pages
{
    public class BookEditModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IObjectLocalizer _objectLocalizer;

        public BookEditModel(ApplicationDbContext dbContext, IObjectLocalizer objectLocalizer)
        {
            _dbContext = dbContext;
            _objectLocalizer = objectLocalizer;
        }
      

        public Book Book { get; set; }
        public IActionResult OnGet(int bookId)
        {
            Book = _dbContext.Books.SingleOrDefault(i => i.Id == bookId);

            if (Book is null)
            {
                return NotFound();
            }
            return Page();

        }

        public IActionResult OnPost(Book book)
        {
            _dbContext.Entry(book).State = EntityState.Modified;

            _dbContext.SaveChanges();

            return RedirectToPage(nameof(Index));
        }
    }
}