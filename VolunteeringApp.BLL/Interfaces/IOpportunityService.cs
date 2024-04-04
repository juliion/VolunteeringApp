using VolunteeringApp.BLL.DTOs.Opportunity;

namespace VolunteeringApp.BLL.Interfaces;

public interface IOpportunityService
{
    public Task<Guid> Add(CreateOpportunityDTO opportunityDTO);
    public Task<FilteredOpportunitiesDTO> GetFiltered(OpportunitiesQueryFilters filters);
    public Task<OpportunityDTO> Get(Guid id);
    public Task Update(Guid id, UpdateOpportunityDTO opportunityDTO);
}
