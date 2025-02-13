using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;

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
    }
}
