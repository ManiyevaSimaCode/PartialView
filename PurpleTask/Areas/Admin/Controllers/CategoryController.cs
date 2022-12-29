using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleTask.DAL.Context;
using PurpleTask.Models;

namespace PurpleTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly PurpleDbContext _context;
        public CategoryController(PurpleDbContext context)
        {
            _context=context;
        }
        public async Task< IActionResult> Index()
        {
            List<Category> categories = await  _context.Categories.ToListAsync();
            return View(categories);
        }




        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }




        [HttpPost]
        
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();

            }
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }




        [HttpGet]
        public IActionResult Update(int id)
        {
            Category category = _context.Categories.Find(id);
            if (category==null)
            {
                return NotFound();
            }
            return View(category);
        }




        [HttpPost]
        public IActionResult Update(Category category)
        {
            Category editedCategory = _context.Categories.Find(category.Id);
            if (editedCategory==null)
            {
                return NotFound();
            }
            editedCategory.Name = category.Name;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }




        public IActionResult Delete(int id)
        {
            Category category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
