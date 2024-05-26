using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VolunteeringApp.BLL.DTOs.Opportunity;
using VolunteeringApp.BLL.Interfaces;
using VolunteeringApp.DLL.Entities;
using VolunteeringApp.PL.ViewModels.Enums;
using VolunteeringApp.PL.ViewModels.Opportunity;

namespace VolunteeringApp.PL.Controllers;

public class OpportunityController : Controller
{
    private readonly IMapper _mapper;
    private readonly IOpportunityService _opportunityService;
    private readonly ICategoryService _categoryService;
    private readonly UserManager<User> _userManager;
    private readonly IWebHostEnvironment _env;
    private readonly IFileService _fileService;

    public OpportunityController(IMapper mapper, IOpportunityService opportunityService, ICategoryService categoryService, UserManager<User> userManager, IWebHostEnvironment env, IFileService fileService)
    {
        _mapper = mapper;
        _opportunityService = opportunityService;
        _categoryService = categoryService;
        _userManager = userManager;
        _env = env;
        _fileService = fileService;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> CreateOpportunity(Guid? userId, Guid? organizationId)
    {
        var user = await _userManager.Users
            .Include(u => u.Organizations)
            .FirstOrDefaultAsync(u => u.Email == User.Identity.Name);
        
        var userOrganization = user?.Organizations.FirstOrDefault();
        
        var categories = await _categoryService.GetAll();

        ViewBag.Categories = categories;
        ViewBag.User = user;
        ViewBag.UserOrganization = userOrganization;

        return View("CreateOpportunity");
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateOpportunity(CreateOpportunityViewModel opportunityViewModel)
    {
        if (opportunityViewModel == null)
        {
            return View("CreateOpportunity", opportunityViewModel);
        }
        var user = await _userManager.Users
            .Include(u => u.Organizations)
            .FirstOrDefaultAsync(u => u.Email == User.Identity.Name);
        var userOrganization = user?.Organizations.FirstOrDefault();

        var opportunityDto = _mapper.Map<CreateOpportunityViewModel, CreateOpportunityDTO>(opportunityViewModel);

        if(opportunityViewModel.OrganizerType == OrganizerType.User)
        {
            opportunityDto.UserOrganizerId = user?.Id;
        }
        else if (opportunityViewModel.OrganizerType == OrganizerType.Organization)
        {
            opportunityDto.OrganizationOrganizerId = userOrganization?.Id;
        }
        if (opportunityViewModel.LocationType == LocationType.Remotely)
        {
            opportunityDto.Location = LocationType.Remotely;
        }
        if (opportunityViewModel.LocationType == LocationType.AllUkraine)
        {
            opportunityDto.Location = LocationType.AllUkraine;
        }
        if (opportunityViewModel.LocationType == LocationType.AddedLocation && !string.IsNullOrEmpty(opportunityViewModel.AddedLocation))
        {
            opportunityDto.Location = opportunityViewModel.AddedLocation;
        }
        if (opportunityViewModel.PictureFile != null && opportunityViewModel.PictureFile.Length > 0)
        {
            var fileName = await _fileService.SaveFile(_env.WebRootPath, opportunityViewModel.PictureFile);
            opportunityDto.PicturePath = fileName;
        }
        await _opportunityService.Add(opportunityDto);
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public async Task<IActionResult> Opportunities([FromQuery] OpportunitiesQueryFilters filters)
    {
        var filteredOppDTOs = await _opportunityService.GetFiltered(filters);

        var filteredOpp = _mapper.Map<FilteredOpportunitiesDTO, FilteredOpportunitiesViewModel>(filteredOppDTOs);

        var categories = await _categoryService.GetAll();
        ViewBag.Categories = categories;

        return View(filteredOpp);
    }

    [HttpGet]
    public async Task<IActionResult> Opportunity(Guid id)
    {
        var oppDTO = await _opportunityService.Get(id);

        var opp = _mapper.Map<OpportunityDTO, OpportunityViewModel>(oppDTO);
        return View(opp);
    }
}
