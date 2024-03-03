using AutoMapper;
using VolunteeringApp.BLL.DTOs.Organization;
using VolunteeringApp.BLL.DTOs.User;
using VolunteeringApp.DLL.Entities;
using VolunteeringApp.PL.ViewModels.Organization;
using VolunteeringApp.PL.ViewModels.User;

namespace VolunteeringApp.PL.Common.Mappings;

public class PLProfile : Profile
{
    public PLProfile()
    {
        CreateMap<UserDTO, UserViewModel>();
        CreateMap<RegistrationViewModel, User>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(source => source.Email));

        CreateMap<CreateOrganizationViewModel, CreateOrganizationDTO>();
        CreateMap<OrganizationDTO, OrganizationViewModel>();
        CreateMap<FilteredOrganizationsDTO, FilteredOrganizationsViewModel>();
    }
}
