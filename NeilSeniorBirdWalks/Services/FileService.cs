using Microsoft.AspNetCore.Components.Forms;
using NeilSeniorBirdWalks.Models;
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

        private bool IsImageFile(string filePath)
        {
            var extension = Path.GetExtension(filePath).ToLowerInvariant();
            return extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif";
        }

        public List<ImageFileInfo> GetUploadedImages()
        {
            var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, ImagesFolder, UploadsFolder);

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
                return new List<ImageFileInfo>();
            }

            var files = Directory.GetFiles(uploadPath)
                .Where(f => IsImageFile(f))
                .Select(f => new ImageFileInfo
                {
                    FileName = Path.GetFileName(f),
                    FilePath = $"/{ImagesFolder}/{UploadsFolder}/{Path.GetFileName(f)}",
                    UploadDate = File.GetCreationTime(f),
                    Description = string.Empty
                })
                .OrderByDescending(f => f.UploadDate)
                .ToList();

            return files;
        }

    }
}
