using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRezor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRezor.Pages.BookLIst
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public EditModel(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }
        [BindProperty]
        public Book Book { get; set; }
        public async Task OnGet(int id)
        {
            Book = await _applicationDbContext.Book.FindAsync(id);
        }


        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookFromDb = await _applicationDbContext.Book.FindAsync(Book.Id);
                BookFromDb.Name = Book.Name;
                BookFromDb.Author = Book.Author;
                BookFromDb.ISBN = Book.ISBN;
                await _applicationDbContext.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();

        }
    }
}
