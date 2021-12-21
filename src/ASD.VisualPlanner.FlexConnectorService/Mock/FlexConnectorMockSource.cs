using ASD.VisualPlanner.FlexConnectorService.Models;

namespace ASD.VisualPlanner.FlexConnectorService.Mock;

public class FlexConnectorMockSource
{
    public List<AppointmentResponse> AppointmentResponses { get; set; }
    public List<AppointmentResponse> BlockedAppointments { get; set; }
    public List<AppointmentResponse> UnassignedAppointments { get; set; }
    public List<AppointmentResponse> CorporateHolidayAppointments { get; set; }


    private static readonly DateTime FlexConnStartTime = new DateTime().AddTicks(new TimeSpan(8, 0, 0).Ticks);
    private static readonly DateTime FlexConnStartDate = DateTime.Today;
    public FlexConnectorMockSource()
    {
        

        AppointmentResponses = new List<AppointmentResponse>
        {
            new()
            {
                Id = 1 , StartTime = FlexConnStartTime , StartDate = FlexConnStartDate, 
                EndTime = FlexConnStartTime.AddHours(2),EndDate = FlexConnStartDate,
                ResourceId = 1,ResourceName = @"Svend", AppointmentType = "TyPe1", 
                Subject = @"Udfør service på unit 22654",
            },
            new()
            {
                Id = 2 , StartTime = FlexConnStartTime.AddHours(1) , StartDate = FlexConnStartDate,
                EndTime = FlexConnStartTime.AddHours(2),EndDate = FlexConnStartDate,
                ResourceId = 2,ResourceName = @"Denise", AppointmentType = "Type9" ,
                Subject = @"Reklamation 241"
            },
            new()
            {
                Id = 3 , StartTime = FlexConnStartTime.AddHours(1) , StartDate = FlexConnStartDate.AddDays(1),
                EndTime = FlexConnStartTime.AddHours(2),EndDate = FlexConnStartDate.AddDays(1),
                ResourceId = 2,ResourceName = @"Denise", AppointmentType = "Type3" ,
                Subject = @"Rekl. 685"
            }
        };

        BlockedAppointments = new List<AppointmentResponse>()
        {
          
            new()
            {
                Id = 4 , StartTime = FlexConnStartTime , StartDate = FlexConnStartDate.AddDays(-4),
                EndTime = FlexConnStartTime.AddHours(8),EndDate = FlexConnStartDate.AddDays(-4),
                ResourceId = 3,ResourceName = @"Bent",  AppointmentType = "type1",
                Subject = @"Lagt ned med Corona"
            }
        

        };

        CorporateHolidayAppointments = new  List<AppointmentResponse>()
        {
            new()
            {
                Id = 5,
                AppointmentType = "TyPe1", StartDate = new DateTime(2021,12,25),
                EndDate =  new DateTime(2021,12,25),
                Subject = @"Juledag",
            },
        }
        ;

        UnassignedAppointments = new List<AppointmentResponse>()
        {

        };


    }

}