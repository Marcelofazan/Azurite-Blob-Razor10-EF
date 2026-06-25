using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace exemploBlobAzure.Services
{
    public class BlobService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly BlobContainerClient _containerClient;

        public BlobService(BlobServiceClient blobServiceClient)
        {

            var options = new BlobClientOptions(BlobClientOptions.ServiceVersion.V2025_11_05);
            options.Diagnostics.IsLoggingEnabled = false;
            _blobServiceClient = new BlobServiceClient("UseDevelopmentStorage=true", options);
            _containerClient = _blobServiceClient.GetBlobContainerClient("blobimages");
            _containerClient.CreateIfNotExists(PublicAccessType.Blob);
            _containerClient.SetAccessPolicy(PublicAccessType.Blob);
        }

        public async Task<string> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("File is empty.");

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var blobClient = _containerClient.GetBlobClient(fileName);

            await blobClient.UploadAsync(file.OpenReadStream(), overwrite: true);

            return blobClient.Uri.ToString();
        }

    }
}
