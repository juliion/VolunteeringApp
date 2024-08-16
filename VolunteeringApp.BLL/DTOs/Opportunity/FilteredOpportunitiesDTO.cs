namespace VolunteeringApp.BLL.DTOs.Opportunity;

public class FilteredOpportunitiesDTO
{
    public int Take { get; set; }
    public int Skip { get; set; }
    public long Total { get; set; }
    public List<OpportunityDTO> Opportunities { get; set; } = new List<OpportunityDTO>();
}
