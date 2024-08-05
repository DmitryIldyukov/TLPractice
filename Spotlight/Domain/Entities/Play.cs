namespace Domain.Entities;

public class Play
{
    public int PlayId { get; init; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TicketPrice { get; set; }
    public string Description { get; set; }
    public int TheaterId { get; set; }
    public Theater Theater { get; set; }
    public int CompositionId { get; set; }
    public Composition Composition { get; set; }

    public Play( 
        string name, 
        DateTime startDate, 
        DateTime endDate, 
        decimal ticketPrice, 
        string description, 
        int theaterId, 
        int compositionId )
    {
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
        TicketPrice = ticketPrice;
        Description = description;
        TheaterId = theaterId;
        CompositionId = compositionId;
    }
}