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

        public Book Book { get; set; }

        public void OnGet()
        {

        }
    }
}
