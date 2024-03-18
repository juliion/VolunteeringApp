using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VolunteeringApp.BLL.DTOs.Category;
using VolunteeringApp.BLL.DTOs.Organization;
using VolunteeringApp.BLL.Interfaces;
using VolunteeringApp.PL.ViewModels.Category;
using VolunteeringApp.PL.ViewModels.Organization;

namespace VolunteeringApp.PL.Controllers;

public class AdminController : Controller
{
    private readonly IMapper _mapper;
    private readonly IOrganizationService _organizationService;
    private readonly ICategoryService _categoryService;

    public AdminController(IMapper mapper, IOrganizationService organizationService, ICategoryService categoryService)
    {
        _mapper = mapper;
        _organizationService = organizationService;
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> OrganizationsManagement([FromQuery]OrganizationsQueryFilters filters)
    {
        var filteredorgsDTOs = await _organizationService.GetFiltered(filters);

        var filteredOrgs = _mapper.Map<FilteredOrganizationsDTO, FilteredOrganizationsViewModel>(filteredorgsDTOs);

        return View(filteredOrgs);
    }
    [HttpGet]
    public async Task<IActionResult> OrganizationDetails(Guid id)
    {
        var orgDTO = await _organizationService.Get(id);

        var org = _mapper.Map<OrganizationDTO, OrganizationViewModel>(orgDTO);
        return View(org);
    }
    [HttpGet]
    public async Task<IActionResult> CategoriesManagement([FromQuery] CategoriesQueryFilters filters)
    {
        var filteredCategoriesDTOs = await _categoryService.GetFiltered(filters);

        var filteredCategories = _mapper.Map<FilteredCategoriesDTO, FilteredCategoriesViewModel>(filteredCategoriesDTOs);

        return View(filteredCategories);
    }
}
