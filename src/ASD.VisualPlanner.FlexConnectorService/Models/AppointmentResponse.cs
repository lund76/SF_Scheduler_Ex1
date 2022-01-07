

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



    public int OrderId { get; set; }


    public string Subject { get; set; }


    public DateTime StartDate { get; set; }


    public DateTime StartTime { get; set; }


    public DateTime EndDate { get; set; }


    public DateTime EndTime { get; set; }

  
    public string AppointmentType { get; set; }

  
    public string ResourceName { get; set; }

 
    public int ResourceId { get; set; }

    public int ResourceRank { get; set; }
    

   
    public int ActorNo { get; set; }


    public int AgreementNo { get; set; }

    
}