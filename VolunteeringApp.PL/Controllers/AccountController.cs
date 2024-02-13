using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VolunteeringApp.BLL.DTOs.Organization;
using VolunteeringApp.BLL.Interfaces;
using VolunteeringApp.DLL.Entities;
using VolunteeringApp.PL.ViewModels.Organization;
using VolunteeringApp.PL.ViewModels.User;

namespace VolunteeringApp.PL.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IMapper _mapper;
    public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
    }
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(RegistrationViewModel regViewModel)
    {
       // var validationRes = _registrationValidator.Validate(regViewModel);
        //if (!validationRes.IsValid)
        //    return BadRequest(validationRes);

        var user = _mapper.Map<RegistrationViewModel, User>(regViewModel);
        var result = await _userManager.CreateAsync(user, regViewModel.Password);
        if (result.Succeeded)
        {

            if (regViewModel.IsOrganizationRep)
            {
                //await _userManager.AddToRoleAsync(user, "OrganizationRepresentative");
                //regViewModel.CreateOrganizationDTO.UserId = user.Id;
                //var orgDto = _mapper.Map<CreateOrganizationViewModel, CreateOrganizationDTO>(regViewModel.CreateOrganizationDTO);
                //await _organizationService.Add(orgDto);
                return RedirectToAction("CreateOrganization", "Organization", new { userId = user.Id });
            }
            else
            {
                await _userManager.AddToRoleAsync(user, "User");
            }
            await _signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Index", "Home");
        }
        return View(regViewModel);
    }
    [HttpGet]
    public IActionResult Login(string? returnUrl = null)
    {
        return View(new LoginViewModel { ReturnUrl = returnUrl });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        if (ModelState.IsValid)
        {
            var result =
                await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, loginViewModel.RememberMe, false);
            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(loginViewModel.ReturnUrl) && Url.IsLocalUrl(loginViewModel.ReturnUrl))
                {
                    return Redirect(loginViewModel.ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Wrong email and/or password");
            }
        }
        return View(loginViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}
