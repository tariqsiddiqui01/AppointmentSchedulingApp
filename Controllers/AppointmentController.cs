using AppointmentSchedulingApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentController.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        public IActionResult Index(){
            
           ViewBag.DoctorList =  _appointmentService.GetDoctorsList();
            return View();
        }
    }
}