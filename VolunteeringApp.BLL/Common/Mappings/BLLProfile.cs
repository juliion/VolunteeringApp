using AutoMapper;
using VolunteeringApp.BLL.DTOs.Organization;
using VolunteeringApp.DLL.Entities;

namespace VolunteeringApp.BLL.Common.Mappings;

public class BLLProfile : Profile
{
    public BLLProfile()
    {

        CreateMap<CreateOrganizationDTO, Organization>();
        CreateMap<Organization, OrganizationDTO>();
    }
}
