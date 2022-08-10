using AppointmentSchedulingApp.Services;
using AppointmentSchedulingApp.Utility;
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
            
           ViewBag.Duration =  Helper.GetTimeDropDown();
           ViewBag.DoctorList =  _appointmentService.GetDoctorsList();
           ViewBag.PatientList =  _appointmentService.GetPatientsList();
            return View();
        }
    }
}