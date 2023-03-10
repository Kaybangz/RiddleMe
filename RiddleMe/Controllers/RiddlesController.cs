using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RiddleMe.Data;
using RiddleMe.Models;
using RiddleMe.Models.Domain;

namespace RiddleMe.Controllers
{
    public class RiddlesController : Controller
    {
        private readonly RiddlemeDbContext _dbContext;

        public RiddlesController(RiddlemeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var riddles = await _dbContext.Riddles.ToListAsync();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(AddRiddleVM addRiddleRequest)
        {
            var riddle = new Riddle()
            {
                Id = Guid.NewGuid(),
                Question = addRiddleRequest.Question,
                Answer = addRiddleRequest.Answer,
                CreatedAt = addRiddleRequest.CreatedAt,
            };

            await _dbContext.Riddles.AddAsync(riddle);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Add");
        }


    }
}
