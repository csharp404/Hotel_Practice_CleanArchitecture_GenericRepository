namespace Domain.Entities;

public class Room
{
    public int Id { get; set; }
    public int Capacity { get; set; }
    public int NOB { get; set; }
    public int GuestId { get; set; }
    public virtual Guest Guest { get; set; }    
}