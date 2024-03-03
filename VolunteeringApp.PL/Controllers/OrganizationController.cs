using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VolunteeringApp.BLL.DTOs.Organization;
using VolunteeringApp.BLL.Interfaces;
using VolunteeringApp.PL.ViewModels.Organization;

namespace VolunteeringApp.PL.Controllers;

public class OrganizationController : Controller
{
    private readonly IMapper _mapper;
    private readonly IOrganizationService _organizationService;

    public OrganizationController(IMapper mapper, IOrganizationService organizationService)
    {
        _mapper = mapper;
        _organizationService = organizationService;
    }

    [HttpGet]
    public IActionResult CreateOrganization(Guid userId)
    {
        var organizationViewModel = new CreateOrganizationViewModel
        {
            UserId = userId
        };
        return View("CreateOrganization", organizationViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrganization(CreateOrganizationViewModel organizationViewModel)
    {
        if (organizationViewModel == null) 
        {
            return View("CreateOrganization", organizationViewModel);
        }
        var orgDto = _mapper.Map<CreateOrganizationViewModel, CreateOrganizationDTO>(organizationViewModel);

        await _organizationService.Add(orgDto);
        return RedirectToAction("Index", "Home");
    }
}
