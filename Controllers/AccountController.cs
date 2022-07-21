using System;
using AppointmentSchedulingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSchedulingApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AccountController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}