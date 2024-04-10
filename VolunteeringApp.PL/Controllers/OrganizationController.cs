using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using VolunteeringApp.BLL.DTOs.Organization;
using VolunteeringApp.BLL.Interfaces;
using VolunteeringApp.PL.ViewModels.Organization;

namespace VolunteeringApp.PL.Controllers;

public class OrganizationController : Controller
{
    private readonly IMapper _mapper;
    private readonly IOrganizationService _organizationService;
    private readonly IWebHostEnvironment _env;
    private readonly IFileService _fileService;

    public OrganizationController(IMapper mapper, IOrganizationService organizationService, IWebHostEnvironment env, IFileService fileService)
    {
        _mapper = mapper;
        _organizationService = organizationService;
        _env = env;
        _fileService = fileService;
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
        if (organizationViewModel.PictureFile != null && organizationViewModel.PictureFile.Length > 0)
        {
            var fileName = await _fileService.SaveFile(_env.WebRootPath, organizationViewModel.PictureFile);
            organizationViewModel.PicturePath = fileName;
        }

        var orgDto = _mapper.Map<CreateOrganizationViewModel, CreateOrganizationDTO>(organizationViewModel);

        await _organizationService.Add(orgDto);
        return RedirectToAction("Index", "Home");
    }
}
