using System.Collections.Generic;
using System.Threading.Tasks;
using AppointmentSchedulingApp.Models.ViewModels;

namespace AppointmentSchedulingApp.Services
{
    public interface IAppointmentService
    {
        public List<DoctorVM> GetDoctorsList();
        public List<PatientVM> GetPatientsList();
        public Task<int> AddUpdate(AppointmentVM appointment);
    }
}