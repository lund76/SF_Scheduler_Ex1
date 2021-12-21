using ASD.VisualPlanner.Core.Models;
using ASD.VisualPlanner.Core.Services;
using ASD.VisualPlanner.FlexConnectorService.Mock;

namespace ASD.VisualPlanner.FlexConnectorService;

public partial class FlexConnectorDataService : ISettingsService
{
    public Task<Settings> GetScheduleSettings()
    {
        return new MockSettingsService().GetScheduleSettings();
    }
}