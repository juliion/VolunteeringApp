using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using VolunteeringApp.BLL.Common.Mappings;
using VolunteeringApp.BLL.Interfaces;
using VolunteeringApp.BLL.Services;
using VolunteeringApp.BLL.Validators;
using VolunteeringApp.DLL;
using VolunteeringApp.DLL.Entities;
using VolunteeringApp.PL.Common.Mappings;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddControllersWithViews();

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<VolunteeringAppDbContext>(opt =>
        opt.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection")));

builder.Services.AddAutoMapper(typeof(BLLProfile));
builder.Services.AddAutoMapper(typeof(PLProfile));

builder.Services.AddValidatorsFromAssemblyContaining<OrganizationValidator>();

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<VolunteeringAppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = config["Jwt:Issuer"],
            ValidAudience = config["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:SigningKey"]))
        };
    });

builder.Services.AddScoped<IOrganizationService, OrganizationService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
