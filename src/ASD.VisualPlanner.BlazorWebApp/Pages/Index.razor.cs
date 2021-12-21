using System.Reflection;
using ASD.VisualPlanner.Core.Models;
using Microsoft.AspNetCore.Components;

namespace ASD.VisualPlanner.BlazorWebApp.Pages
{
    public partial class Index
    {
        
        private string? _assemblyInfo;
        private List<ResourceData> _resourceData = new();
        private Settings _settings = new();
        protected override async Task OnInitializedAsync()
        {
            _settings = await _settingsService.GetScheduleSettings();
            _resourceData = await Task.FromResult(_appointmentService.GetResourceList().ToList());

            var assInfo = Assembly.GetExecutingAssembly().GetCustomAttributes<AssemblyFileVersionAttribute>().FirstOrDefault();
            _assemblyInfo = assInfo.Version;

        }

        private void OnCreated()
        {
        }

        public string[] Resources { get; set; } = { "Owners" };
    } 
}