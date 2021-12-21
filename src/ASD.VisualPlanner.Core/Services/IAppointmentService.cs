using System.Collections.Generic;
using ASD.VisualPlanner.Core.Models;

namespace ASD.VisualPlanner.Core.Services
{
    public interface IAppointmentService
    {
        List<AppointmentData> AppointmentPool { get; set; }
        IEnumerable<AppointmentData> GetActiveAppointments();
        IEnumerable<AppointmentData> GetBlockedAppointments();
        IEnumerable<AppointmentData> GetCorporateHolidays();
        IEnumerable<AppointmentData> GetUnassignedAppointments();
        IEnumerable<ResourceData> GetResourceList();
    }
}