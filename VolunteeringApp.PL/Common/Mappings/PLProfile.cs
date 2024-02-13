using AutoMapper;
using VolunteeringApp.BLL.DTOs.Organization;
using VolunteeringApp.DLL.Entities;
using VolunteeringApp.PL.ViewModels.Organization;
using VolunteeringApp.PL.ViewModels.User;

namespace VolunteeringApp.PL.Common.Mappings;

public class PLProfile : Profile
{
    public PLProfile()
    {

        CreateMap<CreateOrganizationViewModel, CreateOrganizationDTO>();
        CreateMap<RegistrationViewModel, User>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(source => source.Email));
    }
}
