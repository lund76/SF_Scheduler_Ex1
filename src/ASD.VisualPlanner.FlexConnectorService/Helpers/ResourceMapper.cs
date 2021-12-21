using ASD.VisualPlanner.Core.Models;
using ASD.VisualPlanner.FlexConnectorService.Models;

namespace ASD.VisualPlanner.FlexConnectorService.Helpers;

public class ResourceMapper
{
    public static IEnumerable<ResourceData> GetResourcesFromAppointmentData(IEnumerable<AppointmentResponse> appointmentResponses)
    {
        var resources = 
            appointmentResponses
                .Select(s => new {  s.ResourceId, s.ResourceName }).Distinct()
                .Select(n => new ResourceData{Id  = n.ResourceId , Text = n.ResourceName});

        return resources;

    }
}

