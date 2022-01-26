using ASD.VisualPlanner.Core.Models;
using ASD.VisualPlanner.Core.Services;
using ASD.VisualPlanner.FlexConnectorService.Helpers;

namespace ASD.VisualPlanner.FlexConnectorService.Mock
{

    public class MockSettingsService : ISettingsService
    {
        public Task<Settings> GetScheduleSettings()
        {
            var settings = new Settings();
            settings.ResourceTitle = "Choose resource";

            return Task.FromResult(settings);
        }
    }

    public class MockAppointmentService: IAppointmentService
    {
        private readonly FlexConnectorMockSource _flexConnMockDataSource;
        private readonly IEnumerable<ResourceData> _resourceList;

        public MockAppointmentService()
        {
            _flexConnMockDataSource = new FlexConnectorMockSource();
            _resourceList = GetResourceList();
            
            AppointmentPool = new List<AppointmentData>();
            AppointmentPool = GetActiveAppointments().ToList();
            AppointmentPool.AddRange(GetBlockedAppointments());
            AppointmentPool.AddRange(GetCorporateHolidays());
            
        }

        public List<AppointmentData> AppointmentPool { get; set; }

        public IEnumerable<AppointmentData> GetActiveAppointments()
        {
            return AppointmentMapper.MapResponseToAppointmentData(_flexConnMockDataSource.AppointmentResponses);
        }

        public IEnumerable<AppointmentData> GetBlockedAppointments()
        {
            return AppointmentMapper.MapResponseToAppointmentData(_flexConnMockDataSource.BlockedAppointments, true);
        }

        public IEnumerable<AppointmentData> GetCorporateHolidays()
        {
            return AppointmentMapper.ResolveAndMapHolidayResponseToAppointmentData(_flexConnMockDataSource.CorporateHolidayAppointments, 
                _resourceList, AppointmentPool.Max(i => i.Id));
        }

        public IEnumerable<AppointmentData> GetUnassignedAppointments()
        {
            return AppointmentMapper.MapResponseToAppointmentData(_flexConnMockDataSource.UnassignedAppointments);
        }

        public IEnumerable<ResourceData> GetResourceList()
        {
            var appResponses = _flexConnMockDataSource.AppointmentResponses.ToList();
            appResponses.AddRange(_flexConnMockDataSource.BlockedAppointments);
            return ResourceMapper.GetResourcesFromAppointmentData(appResponses);

        }
    }
}
