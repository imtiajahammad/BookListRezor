using BookListRezor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRezor.Controllers
{

    [Route("api/Book")]//defining the route of api call
    [ApiController]//making sure that this is a api controller
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public BookController(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           
            return Json(new { data =await _applicationDbContext.Book.ToListAsync() });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var bookFromDb = await _applicationDbContext.Book.FirstOrDefaultAsync(u => u.Id == id);
            if (bookFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _applicationDbContext.Book.Remove(bookFromDb);
            await _applicationDbContext.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}
