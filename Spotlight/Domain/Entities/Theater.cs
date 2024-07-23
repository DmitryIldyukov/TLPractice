namespace Domain.Entities;

public class Theater
{
    public int TheaterId { get; init; }
    public string Name { get; private set; }
    public DateTime FirstOpeningDate { get; init; }
    // TODO: Режим работы
    public string Description { get; private set; }
    public string PhoneNumber { get; private set; }

    public ICollection<Play> Plays { get; set; } = new HashSet<Play>();

    public Theater( 
        int theaterId, 
        string name, 
        DateTime firstOpeningDate, 
        string description, 
        string phoneNumber )
    {
        TheaterId = theaterId;
        Name = name;
        FirstOpeningDate = firstOpeningDate;
        Description = description;
        PhoneNumber = phoneNumber;
    }
}
