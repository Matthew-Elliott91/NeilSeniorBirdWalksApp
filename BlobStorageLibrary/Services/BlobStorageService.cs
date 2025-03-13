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
    }
}
