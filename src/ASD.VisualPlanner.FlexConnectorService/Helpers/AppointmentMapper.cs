using ASD.VisualPlanner.Core.Models;
using ASD.VisualPlanner.FlexConnectorService.Models;

namespace ASD.VisualPlanner.FlexConnectorService.Helpers;

public class AppointmentMapper
{
    public static IEnumerable<AppointmentData> MapResponseToAppointmentData(IEnumerable<AppointmentResponse> data,
        bool isBlocked = false) 
    {
        var mappedCollection = data.Select(ar => new AppointmentData
        {
            Id = ar.Id,
            StartTime = GetCombinedDateTime(ar.StartDate,ar.StartTime),
            EndTime = GetCombinedDateTime(ar.EndDate,ar.EndTime),
            Description = ar.Subject,
            Subject = ar.Subject,
            ResourceId = new int[] {ar.ResourceId},
            CssClass = GetBuildInTypeFromName(ar.AppointmentType),
            IsBlock = isBlocked
            
        });
        return mappedCollection;
    }

    private static string GetBuildInTypeFromName(string appointmentType)
    {
        var typeNames = new[] {"type1", "type2" , "type3", "type4" , "type5" };

        var tn = typeNames.FirstOrDefault(f => f.ToLower().Contains(appointmentType?.ToLower() ?? string.Empty)) ?? "type5";
        return tn;

    }

    private static DateTime GetCombinedDateTime(DateTime date, DateTime time)
    {
        return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
    }

    public static IEnumerable<AppointmentData> ResolveAndMapHolidayResponseToAppointmentData
        (IEnumerable<AppointmentResponse> corporateHolidayAppointments, IEnumerable<ResourceData> resourceList, int seed)
    {
        
        var apps = MapResponseToAppointmentData(corporateHolidayAppointments).ToList();
        foreach (var a in apps)
        {
            a.Id = ++seed;
            a.IsAllDay = true;
            a.IsReadonly = true;
            a.ResourceId = resourceList.Select(s => s.Id).ToArray();
        }

        return apps;
    }
}