namespace VolunteeringApp.DLL.Entities;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<Opportunity> Opportunities { get; set; } = new List<Opportunity>();
}
