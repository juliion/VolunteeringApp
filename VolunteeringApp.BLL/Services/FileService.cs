using Microsoft.AspNetCore.Http;
using VolunteeringApp.BLL.Interfaces;

namespace VolunteeringApp.BLL.Services;

public class FileService : IFileService
{
    private readonly string _uploadsDir;

    public FileService()
    {
        _uploadsDir = "uploads";
    }

    public async Task<string> SaveFile(string rootPath, IFormFile pictureFile)
    {
        var uploadsDirectory = Path.Combine(rootPath, _uploadsDir);
        var fileName = Guid.NewGuid().ToString() + "_" + pictureFile.FileName;
        var filePath = Path.Combine(uploadsDirectory, fileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await pictureFile.CopyToAsync(fileStream);
        }
        return Path.Combine(_uploadsDir, fileName);
    }
}
