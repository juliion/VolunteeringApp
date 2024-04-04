namespace VolunteeringApp.PL.ViewModels.Opportunity;

public class FilteredOpportunitiesViewModel
{
    public int Take { get; set; }
    public int Skip { get; set; }
    public long Total { get; set; }
    public List<OpportunityViewModel> Opportunities { get; set; } = new List<OpportunityViewModel>();
}
