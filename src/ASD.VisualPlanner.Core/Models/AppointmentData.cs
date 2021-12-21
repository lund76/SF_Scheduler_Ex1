using System;

namespace ASD.VisualPlanner.Core.Models
{
    public class AppointmentData
    {
        public int Id { get; set; }
        public string? Subject { get; set; }
        public string? Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? Description { get; set; }
        public bool IsAllDay { get; set; }
        public string? RecurrenceRule { get; set; }
        public string? RecurrenceException { get; set; }
        public int? RecurrenceId { get; set; }
        public int[]? ResourceId { get; set; }
        public string? CssClass { get; set; }
        public int ParentResourceId { get; set; }
        public bool IsBlock { get; set; }
        public bool IsReadonly { get; set; }
    }
}   