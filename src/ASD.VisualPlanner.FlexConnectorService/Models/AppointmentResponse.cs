using Amesto.FlexConnector.Client;

namespace ASD.VisualPlanner.FlexConnectorService.Models;

/// <summary>
/// The response type as they are converted by the FlexConnector Client.
/// </summary>
public class AppointmentResponse
{
    /// <summary>
    /// Primary key for the context that holds information on start and end
    /// </summary>
    public int Id { get; set; }


    [FlexField("CAL_OrdNo")]
    public int OrderId { get; set; }

    [FlexField("CAL_Descr")]
    public string Subject { get; set; }

    [FlexField("CAL_FrDt")]
    public DateTime StartDate { get; set; }

    [FlexField("CAL_FrTm")]
    public DateTime StartTime { get; set; }

    [FlexField("CAL_FrDt")]
    public DateTime EndDate { get; set; }

    [FlexField("CAL_ToTm")]
    public DateTime EndTime { get; set; }

    /// <summary>
    /// The type of appointment. At the moment takes values of type1 through type5
    /// </summary>
    [FlexField("CAL_AppTp")]
    public string AppointmentType { get; set; }

    /// <summary>
    /// What is the name of the resource that is the owner or context of the appointment
    /// </summary>
    public string ResourceName { get; set; }

    /// <summary>
    /// What is the unique id of the resource
    /// </summary>
    public int ResourceId { get; set; }

    /// <summary>
    /// When multilevel resource is implemented, this is what part of the hierarchy this resource belongs
    /// </summary>
    public int ResourceRank { get; set; }
    

    /// <summary>
    /// Primary key
    /// </summary>
    [FlexField("CAL_AgrActNo")]
    public int ActorNo { get; set; }

    /// <summary>
    /// Primary key
    /// </summary>
    [FlexField("CAL_AgrNo")]
    public int AgreementNo { get; set; }

    
}