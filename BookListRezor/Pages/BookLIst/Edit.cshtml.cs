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
    }
}
