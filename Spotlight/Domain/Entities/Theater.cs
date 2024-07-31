namespace Domain.Entities;

public class Theater
{
    public int TheaterId { get; init; }
    public string Name { get; set; }
    public string Address { get; init; }
    public DateTime FirstOpeningDate { get; init; }
    public string Description { get; set; }
    public string PhoneNumber { get; set; }

    public ICollection<Play> Plays { get; set; } = new HashSet<Play>();
    public ICollection<WorkingHours> WorkingHours { get; set; } = new HashSet<WorkingHours>();

    public Theater(
        string name,
        string address,
        DateTime firstOpeningDate, 
        string description, 
        string phoneNumber )
    {
        Name = name;
        Address = address;
        FirstOpeningDate = firstOpeningDate;
        Description = description;
        PhoneNumber = phoneNumber;
    }
}
