using AutoMapper;
using VolunteeringApp.BLL.DTOs.Category;
using VolunteeringApp.BLL.DTOs.Opportunity;
using VolunteeringApp.BLL.DTOs.Organization;
using VolunteeringApp.BLL.DTOs.User;
using VolunteeringApp.DLL.Entities;

namespace VolunteeringApp.BLL.Common.Mappings;

public class BLLProfile : Profile
{
    public BLLProfile()
    {
        CreateMap<User, UserDTO>();

        CreateMap<CreateOrganizationDTO, Organization>();
        CreateMap<Organization, OrganizationDTO>();

        CreateMap<CreateCategoryDTO, Category>();
        CreateMap<Category, CategoryDTO>();

        CreateMap<CreateOpportunityDTO, Opportunity>();
        CreateMap<Opportunity, OpportunityDTO>();
    }
}
