using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleTask.DAL.Context;
using PurpleTask.Models;
using PurpleTask.ViewModels;
using System.Diagnostics;

namespace PurpleTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly PurpleDbContext _dbContext;
        public HomeController(PurpleDbContext dbContext )
        {
            _dbContext= dbContext;
        }
        public async Task< IActionResult> Index()
        {
            CardCategoryViewModel model = new CardCategoryViewModel();

          model.Sliders= await _dbContext.Sliders.ToListAsync();
            model.Categories= await _dbContext.Categories
                .Include(c=>c.Cards).
                ToListAsync();
            model.Cards = await _dbContext.Card.Include(c => c.Category).ToListAsync();

            return View(model);
        }

       
    }
}