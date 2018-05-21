using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuizApp.Data;
using QuizApp.Data.Entities;

namespace QuizApp.Controllers
{
    public class QuizController : Controller
    {
        private readonly IRepositoryEf<Quiz> _quizRepo;
        private readonly QuizAppDbContext _dbContext;
        private readonly ILogger<QuizController> _logger;

        public QuizController(IRepositoryEf<Quiz> quizRepo, QuizAppDbContext dbContext, ILogger<QuizController> logger)
        {
            _quizRepo = quizRepo;
            _dbContext = dbContext;
            _logger = logger;
        }
        // GET: Quiz
        public IActionResult Index()
        {
            var quiz = _quizRepo.ListAll();

            return View(_quizRepo.ListAll());
        }

        // GET: Quiz/Details/5
        public IActionResult Details(int id)
        {
            return View(_quizRepo.GetById(id));
        }

        // GET: Quiz/Create
        public IActionResult Create()
        {
            Quiz newQuiz = new Quiz
            {
                PublishDate = DateTime.Now
            };

            return View(newQuiz);
        }

        // POST: Quiz/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Quiz newQuiz ,IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _quizRepo.Add(newQuiz);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to create a quiz: {ex}");

                return View(newQuiz);
            }
        }

        // GET: Quiz/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_quizRepo.GetById(id));
        }

        // POST: Quiz/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            Quiz quiz = _quizRepo.GetById(id);

            try
            {
                _quizRepo.Update(quiz);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to delete a quiz: {ex}");

                return View(quiz);
            }
        }

        // GET: Quiz/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_quizRepo.GetById(id));
        }

        // POST: Quiz/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            Quiz quiz = _quizRepo.GetById(id);

            try
            {
                _quizRepo.Delete(quiz);
    
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to delete a quiz: {ex}");

                return View(quiz);
            }
        }
    }
}