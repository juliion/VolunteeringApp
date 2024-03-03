using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VolunteeringApp.BLL.DTOs.Organization;
using VolunteeringApp.BLL.Interfaces;
using VolunteeringApp.PL.ViewModels.Organization;

namespace VolunteeringApp.PL.Controllers;

public class AdminController : Controller
{
    private readonly IMapper _mapper;
    private readonly IOrganizationService _organizationService;

    public AdminController(IMapper mapper, IOrganizationService organizationService)
    {
        _mapper = mapper;
        _organizationService = organizationService;
    }

    [HttpGet]
    public async Task<IActionResult> OrganizationsManagement([FromQuery]OrganizationsQueryFilters filters)
    {
        var filteredorgsDTOs = await _organizationService.GetFiltered(filters);

        var filteredOrgs = _mapper.Map<FilteredOrganizationsDTO, FilteredOrganizationsViewModel>(filteredorgsDTOs);

        return View(filteredOrgs);
    }
    [HttpGet]
    public async Task<IActionResult> Details(Guid id)
    {
        var orgDTO = await _organizationService.Get(id);

        var org = _mapper.Map<OrganizationDTO, OrganizationViewModel>(orgDTO);
        return View(org);
    }
}
