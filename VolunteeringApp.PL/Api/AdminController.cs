using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VolunteeringApp.BLL.Interfaces;
using VolunteeringApp.BLL.Services;
using VolunteeringApp.BLL.DTOs.Organization;
using VolunteeringApp.DLL.Enums;
using Microsoft.Extensions.Primitives;

namespace VolunteeringApp.PL.Api;

[Route("api/[controller]")]
[ApiController]
public class AdminController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IOrganizationService _organizationService;

    public AdminController(IMapper mapper, IOrganizationService organizationService)
    {
        _mapper = mapper;
        _organizationService = organizationService;
    }
    [HttpPost("ChangeOrganizationStatus")]
    public async Task<IActionResult> ChangeOrganizationStatus(Guid organizationId, string status)
    {
        if (Enum.TryParse(status, out Status statusEnum))
        {
            await _organizationService.Update(organizationId, new UpdateOrganizationDTO { Status = statusEnum });
        }
        return Ok();
    }
}
