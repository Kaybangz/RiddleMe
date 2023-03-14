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

            return View(riddles);
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

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var riddle = await _dbContext.Riddles.FirstOrDefaultAsync(r => r.Id == id);

            if (riddle != null)
            {
                var viewModel = new UpdateRiddleVM
                {
                    Id = riddle.Id,
                    Question = riddle.Question,
                    Answer = riddle.Answer,
                    CreatedAt = riddle.CreatedAt,
                };

                return await Task.Run(() => View("View", viewModel));
            }



            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> View(UpdateRiddleVM updateRiddleVM)
        {
            var riddle = await _dbContext.Riddles.FindAsync(updateRiddleVM.Id);

            if (riddle != null)
            {
                riddle.Question = updateRiddleVM.Question;
                riddle.Answer = updateRiddleVM.Answer;
                riddle.CreatedAt = updateRiddleVM.CreatedAt;

                await _dbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }


    }
}
