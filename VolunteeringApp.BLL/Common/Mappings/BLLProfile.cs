using AutoMapper;
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
    }
}
