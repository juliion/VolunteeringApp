using Microsoft.AspNetCore.Http;

namespace VolunteeringApp.BLL.Interfaces;

public interface IFileService
{
    public Task<string> SaveFile(string rootPath, IFormFile pictureFile);
}
