using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JobApplication.Models;
using JobApplication.Services;

namespace JobApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailSender emailSender;

        public HomeController(IEmailSender emailSender)
        {
            this.emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult JobApplication()
        {
            var model = new JobApplicationViewModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult JobApplication(JobApplicationViewModel application)
        {
            if (!ModelState.IsValid)
            {
                return View(application);
            }

            this.emailSender.Send(application.Email, application.FirtsName, application.Position);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
