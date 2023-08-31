using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;
using ServicesLayer.Interface;


namespace ServicesLayer.Repository
{
    public class StorageFiles : IstorageFile
    {

        public readonly string connecctionString;
        public StorageFiles(IConfiguration configuration) {
            connecctionString = configuration.GetConnectionString("azureStorage");
        }
        public async Task DeleteFile(string router , string container )
        {

            if(string.IsNullOrEmpty(router)) {

                return;
            }
            var client =new BlobContainerClient(container, connecctionString);
            await client.CreateIfNotExistsAsync();
            var file = Path.GetFileName(router);
            var blob = client.GetBlobClient(file);

            await blob.DeleteIfExistsAsync();
         
        }

        public async Task<string> EditFile(byte[] content, string extension, string container, string router, string contentType)
        {

            await DeleteFile(router, container);
            return await SaveFile(content, extension, container, contentType);


        }

        public async Task<string> SaveFile(byte[] content, string extension, string container, string contentType)
        {
            var client = new BlobContainerClient(connecctionString, container);
            await client.CreateIfNotExistsAsync();
            client.SetAccessPolicy(PublicAccessType.Blob);

            var nameFile = $"{Guid.NewGuid()}{extension}";
            var blob = client.GetBlobClient(nameFile);

            var blobUploadOptions = new BlobUploadOptions();
            var blobHttpHeader = new BlobHttpHeaders(); 
            blobHttpHeader.ContentType = contentType;
            blobUploadOptions.HttpHeaders = blobHttpHeader;
                

            await blob.UploadAsync(new BinaryData(content), blobUploadOptions );

            return blob.Uri.ToString();

         
        }
    }
}
