using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VolunteeringApp.BLL.Interfaces;
using VolunteeringApp.BLL.Services;
using VolunteeringApp.BLL.DTOs.Organization;
using VolunteeringApp.DLL.Enums;
using Microsoft.Extensions.Primitives;
using VolunteeringApp.BLL.DTOs.Category;
using VolunteeringApp.PL.ViewModels.Category;
using VolunteeringApp.BLL.DTOs.Opportunity;

namespace VolunteeringApp.PL.Api;

[Route("api/[controller]")]
[ApiController]
public class AdminController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IOrganizationService _organizationService;
    private readonly ICategoryService _categoryService;
    private readonly IOpportunityService _opportunityService;

    public AdminController(IMapper mapper, IOrganizationService organizationService, ICategoryService categoryService, IOpportunityService opportunityService)
    {
        _mapper = mapper;
        _organizationService = organizationService;
        _categoryService = categoryService;
        _opportunityService = opportunityService;
    }
    [HttpPost("ChangeOrganizationStatus")]
    public async Task<IActionResult> ChangeOrganizationStatus(Guid organizationId, string status)
    {
        if (Enum.TryParse(status, out OrganizationStatus statusEnum))
        {
            await _organizationService.Update(organizationId, new UpdateOrganizationDTO { Status = statusEnum });
        }
        return Ok();
    }
    [HttpPost("ChangeOpportunityStatus")]
    public async Task<IActionResult> ChangeOpportunityStatus(Guid opportunityId, string status)
    {
        if (Enum.TryParse(status, out OpportunityStatus statusEnum))
        {
            await _opportunityService.Update(opportunityId, new UpdateOpportunityDTO { Status = statusEnum });
        }
        return Ok();
    }
    [HttpPost("AddCategory")]
    public async Task<IActionResult> AddCategory(CreateCategoryViewModel categoryViewModel)
    {
        var categoryDto = _mapper.Map<CreateCategoryViewModel, CreateCategoryDTO>(categoryViewModel);

        await _categoryService.Add(categoryDto);
        return Ok();
    }
    [HttpDelete("DeleteCategory/{categoryId}")]
    public async Task<IActionResult> DeleteCategory(Guid categoryId)
    {
        await _categoryService.Delete(categoryId);
        return Ok();
    }
    [HttpPut("EditCategory/{categoryId}")]
    public async Task<IActionResult> EditCategory(Guid categoryId, UpdateCategoryViewModel categoryViewModel)
    {
        var categoryDto = _mapper.Map<UpdateCategoryViewModel, UpdateCategoryDTO>(categoryViewModel);

        await _categoryService.Update(categoryId, categoryDto);
        return Ok();
    }
}
