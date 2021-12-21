using ASD.VisualPlanner.Core.Models;
using ASD.VisualPlanner.Core.Services;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;

namespace ASD.VisualPlanner.CustomDataAdapter;

public class PlannerDataAdapter : DataAdaptor
{
    private readonly List<AppointmentData> _eventData = new List<AppointmentData>();

    private readonly IAppointmentService _appointmentService;

    public PlannerDataAdapter(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
        _eventData = _appointmentService.AppointmentPool;

        _eventData.Add(new AppointmentData
        {
            Description = Guid.NewGuid().ToString(),
            StartTime = DateTime.Now.AddDays(-3),
            Id = new Random(1).Next(),
            ResourceId = new[] { new Random(0).Next(1, 3) },
            EndTime = DateTime.Now.AddDays(-3).AddHours(2),
            Subject = Guid.NewGuid().ToString()
        });
    } 

    public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)
    {
        await Task.Delay(100); //To mimic asynchronous operation, we delayed this operation using Task.Delay
      
        return dataManagerRequest.RequiresCounts ? new DataResult() { Result = _eventData, Count = _eventData.Count() } : (object)_eventData;
    }
    public override async Task<object> InsertAsync(DataManager dataManager, object data, string key)
    {
        await Task.Delay(100); //To mimic asynchronous operation, we delayed this operation using Task.Delay
        _eventData.Insert(0, data as AppointmentData);
        return data;
    }
    public override async Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key)
    {
        await Task.Delay(10); //To mimic asynchronous operation, we delayed this operation using Task.Delay
        var val = (data as AppointmentData);
        var appointment = _eventData.FirstOrDefault(AppointmentData => AppointmentData.Id == val.Id);
        if (appointment != null)
        {
            appointment.Id = val.Id;
            appointment.Subject = val.Subject;
            appointment.StartTime = val.StartTime;
            appointment.EndTime = val.EndTime;
            appointment.Location = val.Location;
            appointment.Description = val.Description;
            appointment.IsAllDay = val.IsAllDay;
            appointment.ResourceId = val.ResourceId;
            appointment.RecurrenceException = val.RecurrenceException;
            appointment.RecurrenceId = val.RecurrenceId;
            appointment.RecurrenceRule = val.RecurrenceRule;
        }
        return data;
    }
    public override async Task<object> RemoveAsync(DataManager dataManager, object data, string keyField, string key) //triggers on appointment deletion through public method DeleteEvent
    {
        await Task.Delay(100); //To mimic asynchronous operation, we delayed this operation using Task.Delay
        int value = (int)data;
        _eventData.Remove(_eventData.Where((AppointmentData) => AppointmentData.Id == value).FirstOrDefault());
        return data;
    }
    public override async Task<object> BatchUpdateAsync(DataManager dataManager, object changedRecords, object addedRecords, object deletedRecords, string keyField, string key, int? dropIndex)
    {
        await Task.Delay(100); //To mimic asynchronous operation, we delayed this operation using Task.Delay
        object records = deletedRecords;
        List<AppointmentData> deleteData = deletedRecords as List<AppointmentData>;
        foreach (var data in deleteData)
        {
            _eventData.Remove(_eventData.Where((AppointmentData) => AppointmentData.Id == data.Id).FirstOrDefault());
        }
        List<AppointmentData> addData = addedRecords as List<AppointmentData>;
        foreach (var data in addData)
        {
            _eventData.Insert(0, data as AppointmentData);
            records = addedRecords;
        }
        List<AppointmentData> updateData = changedRecords as List<AppointmentData>;
        foreach (var data in updateData)
        {
            var val = (data as AppointmentData);
            var appointment = _eventData.Where((AppointmentData) => AppointmentData.Id == val.Id).FirstOrDefault();
            if (appointment != null)
            {
                appointment.Id = val.Id;
                appointment.Subject = val.Subject;
                appointment.StartTime = val.StartTime;
                appointment.EndTime = val.EndTime;
                appointment.Location = val.Location;
                appointment.Description = val.Description;
                appointment.IsAllDay = val.IsAllDay;
                appointment.ResourceId = val.ResourceId;
                appointment.RecurrenceException = val.RecurrenceException;
                appointment.RecurrenceId = val.RecurrenceId;
                appointment.RecurrenceRule = val.RecurrenceRule;
            }
            records = changedRecords;
        }
        return records;
    }
}

public class TempDataSource
{
}