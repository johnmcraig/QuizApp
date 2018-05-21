using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Data;
using QuizApp.Data.Entities;

namespace QuizApp.Controllers
{
    public class GameController : Controller
    {
        private readonly IRepositoryEf<Quiz> _quizRepo;

        public GameController(IRepositoryEf<Quiz> quizRepo)
        {
            _quizRepo = quizRepo;
        }
        // GET: Game
        public ActionResult Index()
        {
            return View();
        }
    }
}