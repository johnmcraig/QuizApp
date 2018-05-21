using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QuizApp.Data;
using QuizApp.Data.Entities;

namespace QuizApp.Controllers
{
    [Produces("application/json")]
    [Route("api/QuizGameAPI")]
    public class QuizGameAPIController : Controller
    {
        private readonly IRepositoryEf<Quiz> _quizRepo;
        private readonly QuizAppDbContext _dbContext;
        private readonly ILogger<QuizGameAPIController> _logger;

        public QuizGameAPIController(IRepositoryEf<Quiz> quizRepo, 
            QuizAppDbContext dbContext, ILogger<QuizGameAPIController> logger)
        {
            _quizRepo = quizRepo;
            _dbContext = dbContext;
            _logger = logger;
        }

        // GET: api/QuizGameAPI
        [HttpGet]
        public async Task<IActionResult> GetQuizzes()
        {
            var quizzes = await _dbContext.Quizzes
                .Include(q => q.Questions)
                .ThenInclude(a => a.Answers)
                .ToListAsync();
            try
            {
                return Ok(_quizRepo.ListAll());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to find a quiz: {ex}");
                return BadRequest("Failed to find a quiz");
            }
        }

        // GET: api/QuizGameAPI/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetQuiz(int id)
        {
            var quiz = await _dbContext.Quizzes
                .FirstOrDefaultAsync();

            try
            {
                return Ok(quiz);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to find quiz: {ex}");
                return BadRequest("Failed to get quiz");
            }
        }
        
        // POST: api/QuizGameAPI
        [HttpPost]
        public IActionResult Post([FromBody]Quiz entity)
        {
            try
            {
                 _quizRepo.Add(entity: entity);
                return Created($"api/QuizGame/{entity.Id}", entity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to post a quiz: {ex}");
                return BadRequest("Failed to post a quiz");
            }
        }
        
        // PUT: api/QuizGameAPI/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
