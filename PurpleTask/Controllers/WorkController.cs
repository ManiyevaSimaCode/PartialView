using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleTask.DAL.Context;
using PurpleTask.Models;
using PurpleTask.ViewModels;

namespace PurpleTask.Controllers
{
    public class WorkController : Controller
    {
        private readonly PurpleDbContext _dbContext;
        public WorkController(PurpleDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            CardCategoryViewModel model = new CardCategoryViewModel();
            model.Cards = await _dbContext.Card
                .Take(4)
                .Include(c => c.Category).ToListAsync();
            model.Categories = await _dbContext.Categories.ToListAsync();
            return View(model);

        }
        public IActionResult LoadMore(int skip)
        {
            var cards = _dbContext.Card
                .Skip(skip)
                .Take(4)
        .Include(c => c.Category)
        .ToList();
            return PartialView("_CardPartialView", cards);
        }
    }
}
