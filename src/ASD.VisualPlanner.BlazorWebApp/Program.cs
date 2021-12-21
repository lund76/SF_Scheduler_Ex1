using System.Reflection;
using System.Runtime.CompilerServices;
using ASD.VisualPlanner.Core.Services;
using ASD.VisualPlanner.CustomDataAdapter;
using ASD.VisualPlanner.FlexConnectorService;
using ASD.VisualPlanner.FlexConnectorService.Mock;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


builder.Services.AddSyncfusionBlazor();

var licenseKey = builder.Configuration["Syncfusion:LicenseKey"];
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(licenseKey);

builder.Services.AddScoped<IAppointmentService, MockAppointmentService>();
builder.Services.AddScoped<ISettingsService, MockSettingsService>();
builder.Services.AddScoped<PlannerDataAdapter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

   
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
