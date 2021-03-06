﻿using System;
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
    public class AnswerController : Controller
    {
        private readonly QuizAppDbContext _dbContext;
        private readonly IRepositoryEf<Answer> _answerRepo;
        private readonly ILogger<AnswerController> _logger;

        public AnswerController(IRepositoryEf<Answer> answerRepo, ILogger<AnswerController> logger, QuizAppDbContext dbContext)
        {
            _dbContext = dbContext;
            _answerRepo = answerRepo;
            _logger = logger;
        }
        // GET: Answer
        public IActionResult Index()
        {
            var answer = _answerRepo.ListAll();
            return View(_answerRepo.ListAll());

            /*
            AnswerModel model = new List<AnswerModel>();
            _answerRepo.ListAll()
            .ToList()
            .ForEach(a =>
            {
                AnswerModel answer = new AnswerModel
                {
                    Id = a.Id
                    Content = a.content
                    IsCorrect = a.isCorrect

                };
                model.Add()
            });
             */
        }

        // GET: Answer/Details/5
        public ActionResult Details(int id)
        { 
            return View(_answerRepo.GetById(id));
        }

        // GET: Answer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Answer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Answer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Answer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Answer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Answer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}