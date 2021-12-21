using System.Threading.Tasks;
using ASD.VisualPlanner.Core.Models;

namespace ASD.VisualPlanner.Core.Services
{
    public interface ISettingsService
    {
        Task<Settings> GetScheduleSettings();
    }
}