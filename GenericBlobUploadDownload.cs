
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;    
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;

namespace GenericBlobWork
{
    public class HttpTriggerCSharp1
    {
        [FunctionName("HttpTriggerCSharp1")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string container_name = req.Query["container_name"];
            string blob_name = req.Query["blob_name"];
            string conn_string = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");
            
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            container_name = container_name ?? data?.container_name;
            blob_name = blob_name ?? data?.blob_name;
            
            // Download Blob
            log.LogInformation($"C# HTTP trigger function is downloading {container_name}/{blob_name}");
            download_blob(blob_name, container_name, conn_string);
            log.LogInformation($"C# HTTP trigger function has downloaded {System.IO.Path.GetTempPath() + blob_name}");

            //***Here we can do whatever transforms we would like***//
            

            // Upload Blob
            string target_name = blob_name;
            log.LogInformation($"C# HTTP trigger function is uploading {System.IO.Path.GetTempPath()+target_name}");
            upload_blob(target_name, container_name, conn_string);
            log.LogInformation($"C# HTTP trigger function is downloading {container_name}/{target_name}");

            string responseMessage = string.IsNullOrEmpty(blob_name)
                ? "This HTTP triggered function executed successfully. Pass a container and blob in the query string or in the request body for a response."
                : $"This HTTP triggered function executed successfully for {container_name}/{blob_name}";

            return new OkObjectResult(responseMessage);        
        }
        private void download_blob(string blob_name, string container_name, string conn_string) 
        {          
            CloudStorageAccount mycloudStorageAccount = CloudStorageAccount.Parse(conn_string);  
            CloudBlobClient blobClient = mycloudStorageAccount.CreateCloudBlobClient();  
            
            CloudBlobContainer container = blobClient.GetContainerReference(container_name);  
            CloudBlockBlob cloudBlockBlob = container.GetBlockBlobReference(blob_name);  
            
            // provide the file download location below            
            //Stream file = File.OpenWrite(System.IO.Path.GetTempPath()+blob_name);    
            Stream file = File.OpenWrite(blob_name);    
            
            cloudBlockBlob.DownloadToStreamAsync(file);
        } 
        private void upload_blob(string target_name, string container_name, string conn_string) 
        {  
            Stream file;  

            file = new FileStream(Path.Combine(System.IO.Path.GetTempPath(), target_name), FileMode.Open);  
            
            CloudStorageAccount mycloudStorageAccount = CloudStorageAccount.Parse(conn_string);  
            CloudBlobClient blobClient = mycloudStorageAccount.CreateCloudBlobClient();  
            CloudBlobContainer container = blobClient.GetContainerReference(container_name);    
            
            CloudBlockBlob cloudBlockBlob = container.GetBlockBlobReference(target_name);  
            
            cloudBlockBlob.UploadFromStreamAsync(file); 
            
        }  
        private void convert_pdf()
        {

        }
    }
}


