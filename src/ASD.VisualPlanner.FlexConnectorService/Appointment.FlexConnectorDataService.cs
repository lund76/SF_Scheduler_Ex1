using Amesto.FlexConnector.Client;
using ASD.VisualPlanner.Core.Models;
using ASD.VisualPlanner.Core.Services;
using ASD.VisualPlanner.FlexConnectorService.Helpers;
using ASD.VisualPlanner.FlexConnectorService.Models;
using RestSharp;
using RestSharp.Authenticators;

namespace ASD.VisualPlanner.FlexConnectorService;

public partial class FlexConnectorDataService : IAppointmentService 
{
    public List<AppointmentData> AppointmentPool { get; set; }

    public IEnumerable<AppointmentData> GetActiveAppointments()
    {

        var client = new RestClient("https://XXXX");
        client.Authenticator = new HttpBasicAuthenticator("xxx", "xxxx");

        var request = new RestRequest("/Flex/GetDataset", Method.GET);
        request.AddParameter("FirmNo", 370);
        request.AddParameter("ResponseType", 9998);

        var response = client.Get<FlexConnectorResponse>(request);

        var data = response.Data.Data.ToType<AppointmentResponse>();
        

        var mappedAppointments = AppointmentMapper.MapResponseToAppointmentData(data);

        return mappedAppointments;
    }

    public IEnumerable<AppointmentData> GetBlockedAppointments()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<AppointmentData> GetCorporateHolidays()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<AppointmentData> GetUnassignedAppointments()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ResourceData> GetResourceList()
    {
        throw new NotImplementedException();
    }
}