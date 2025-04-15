using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using BlobStorageLibrary.Models;

namespace BlobStorageLibrary.Services
{
    public class BlobStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _containerName;

        public BlobStorageService(string blobConnectionString, string containerName)
        {
            _blobServiceClient = new BlobServiceClient(blobConnectionString);
            _containerName = containerName;
        }

        public BlobContainerClient GetContainerClient()
        {
            return _blobServiceClient.GetBlobContainerClient(_containerName);
        }
        // Method that Gets all images from the container
        public async Task<List<string>> ListBlobUrisAsync(int count)
        {
            var containerClient = GetContainerClient();
            var blobUris = new List<string>();

            await foreach (var blobItem in containerClient.GetBlobsAsync().Take(count))
            {
                var blobClient = containerClient.GetBlobClient(blobItem.Name);
                blobUris.Add(blobClient.Uri.ToString());
            }

            return blobUris;
        }

        public async Task<BlobImage> UploadImageAsync(Stream content, string fileName)
        {
            var containerClient = GetContainerClient();
            string uniqueblobName = $"{Guid.NewGuid()}-{fileName}";
            var blobClient = containerClient.GetBlobClient(uniqueblobName);

            await blobClient.UploadAsync(content, overwrite: true);

            return new BlobImage
            {
                Name = uniqueblobName,
                Uri = blobClient.Uri.ToString(),
                Size = content.Length
            };
        }

        public async Task DeleteImageAsync(string blobName)
        {
            var containerClient = GetContainerClient();
            var blobClient = containerClient.GetBlobClient(blobName);
            await blobClient.DeleteIfExistsAsync();
        }

        public async Task<List<BlobImage>> GetImagesWithMetaDataAsync(int count = 30)
        {
            var ContainerClient = GetContainerClient();
            var images = new List<BlobImage>();

            await foreach(var blobItem in ContainerClient.GetBlobsAsync().Take(count))
            {
                var blobClient = ContainerClient.GetBlobClient(blobItem.Name);
                images.Add(new BlobImage
                {
                    Name = blobItem.Name,
                    Uri = blobClient.Uri.ToString(),
                    Size = blobItem.Properties.ContentLength
                });
            }
            return images;
        }

        public async Task<BlobImage> GetRandomImageAsync()
        {
            var containerClient = GetContainerClient();
            var blobItems = new List<Azure.Storage.Blobs.Models.BlobItem>();

            await foreach (var blobItem in containerClient.GetBlobsAsync())
            {
                blobItems.Add(blobItem);
            }

            if(blobItems.Count == 0)
            {
                return null;
            }

            var random = new Random();
            var randomIndex = random.Next(0, blobItems.Count);
            var randomBlobItem = blobItems[randomIndex];

            var blobClient = containerClient.GetBlobClient(randomBlobItem.Name);
            return new BlobImage
            {
                Name = randomBlobItem.Name,
                Uri = blobClient.Uri.ToString(),
                Size = randomBlobItem.Properties.ContentLength
            };

        }
    }
}
