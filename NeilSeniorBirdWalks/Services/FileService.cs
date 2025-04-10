using Microsoft.AspNetCore.Components.Forms;
using System.Runtime.CompilerServices;

namespace NeilSeniorBirdWalks.Services
{
    public class FileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private const string UploadsFolder = "uploads";
        private const string ImagesFolder = "images";

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }


        public async Task<string> SaveFileAsync(IBrowserFile file)
        {
            if (file == null)
            {
                return string.Empty;
            }
            else
            {
                //Uploads the file to the Uploads folder
                var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, ImagesFolder, UploadsFolder);
                Directory.CreateDirectory(uploadPath);

                var fileName = $"{Guid.NewGuid()}_{file.Name}";
                var filePath = Path.Combine(uploadPath, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.OpenReadStream(maxAllowedSize: 10485760).CopyToAsync(fileStream);
                }
                // Returns the relative path to the file to save in the database
                return $"/{ImagesFolder}/{UploadsFolder}/{fileName}";
            }
        }

    }
}
