using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRezor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRezor.Pages.BookLIst
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CreateModel(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        [BindProperty]/*it will help to assume that this model is going to be worked everywhere*/
        public Book Book { get; set; }

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _applicationDbContext.Book.AddAsync(Book);
                await _applicationDbContext.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
