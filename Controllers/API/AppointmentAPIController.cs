using System;
using System.Security.Claims;
using AppointmentSchedulingApp.Models.ViewModels;
using AppointmentSchedulingApp.Services;
using AppointmentSchedulingApp.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSchedulingApp.Controllers.API
{
    [Route("api/Appointment")]
    [ApiController]
    public class AppointmentAPIController : Controller
    {
        private readonly IAppointmentService _appointmentservice;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string loginUserId;
        private readonly string role;

        public AppointmentAPIController(IAppointmentService appointmentservice, IHttpContextAccessor httpContextAccessor)
        {
            _appointmentservice = appointmentservice;
            _httpContextAccessor = httpContextAccessor;
            loginUserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            role = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
        }

        [HttpPost]
        [Route("SaveCalendarData")]
        public IActionResult SaveCalendarData(AppointmentVM model)
        {

            CommonResponse<int> commonResponse = new CommonResponse<int>();

            try
            {
                commonResponse.status = _appointmentservice.AddUpdate(model).Result;
                if (commonResponse.status == 1)
                    commonResponse.message = Helper.appointmentUpdated;
                if (commonResponse.status == 2)
                    commonResponse.message = Helper.appointmentAdded;
            }
            catch (Exception e)
            {
                commonResponse.message = e.Message;
                commonResponse.status = Helper.failure_code;
            }

            return Ok(commonResponse);
        }

    }
}