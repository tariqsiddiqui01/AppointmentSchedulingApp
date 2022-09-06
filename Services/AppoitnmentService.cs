using System.Collections.Generic;
using AppointmentSchedulingApp.Models;
using AppointmentSchedulingApp.Models.ViewModels;
using System.Linq;
using AppointmentSchedulingApp.Utility;
using System.Threading.Tasks;
using System;

namespace AppointmentSchedulingApp.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _db;
        public AppointmentService(ApplicationDbContext db)
        {
              _db =db;
        }

        public async Task<int> AddUpdate(AppointmentVM appointment)
        {
            var startDate = DateTime.Parse(appointment.StartDate);
            var endDate = DateTime.Parse(appointment.StartDate).AddMinutes(Convert.ToDouble(appointment.Duration));
            if(appointment != null && appointment.Id > 0){
                //upd
                return 1;
            }
            else{
                Appointment appObj = new  Appointment(){
                    Title = appointment.Title,
                    Description = appointment.Description,
                    StartDate = startDate,
                    EndDate = endDate,
                    Duration = appointment.Duration,
                    DoctorId = appointment.DoctorId,
                    PatientId = appointment.PatientId,
                    IsDoctorApproved = appointment.IsDoctorApproved,
                    AdminId = appointment.AdminId
                };

                _db.Appointments.Add(appObj);
                await _db.SaveChangesAsync();
                return 2;

            }
        }

        public List<DoctorVM> GetDoctorsList()
        {
            var doctors = (from user in _db.Users
            join userRoles in _db.UserRoles on user.Id equals userRoles.UserId
            join roles in _db.Roles.Where(x=>x.Name == Helper.Doctor) on userRoles.RoleId equals roles.Id 
            select new DoctorVM{
                Id = user.Id,
                Name = user.Name
            }).ToList();

            return doctors;
        }

        public List<PatientVM> GetPatientsList()
        {
           var patients = (from user in _db.Users
            join userRoles in _db.UserRoles on user.Id equals userRoles.UserId
            join roles in _db.Roles.Where(x=>x.Name == Helper.Patient) on userRoles.RoleId equals roles.Id 
            select new PatientVM{
                Id = user.Id,
                Name = user.Name
            }).ToList();

            return patients;
        }
    }
}