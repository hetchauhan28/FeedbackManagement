
using Microsoft.AspNetCore.Mvc;
using FeedbackManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace FeedbackManagement.Controllers
{
    public class FeedbackController : Controller
    {
        private static readonly List<Feedback> feedbackList = new();
        private static int nextId = 1;

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                feedback.Id = nextId++;
                feedback.SubmittedOn = System.DateTime.Now;
                feedbackList.Add(feedback);

                return RedirectToAction(nameof(Index));
            }

            return View(feedback);
        }

        public IActionResult Index()
        {
            return View(feedbackList.OrderByDescending(
                f => f.SubmittedOn).ToList());
        }

        public IActionResult Details(int id)
        {
            var feedback = feedbackList.FirstOrDefault(f => f.Id == id);

            if (feedback == null)
            {
                return NotFound();
            }

            return View(feedback);
        }
    }
}
