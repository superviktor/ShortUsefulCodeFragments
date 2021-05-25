using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class HttpClientPostMultipartFormDataTests
    {
        [Test(Author = "Viktor", Description = "To test run api project using dotnet run in PowerShell")]
        public async Task Example_PostMultipartFormData()
        {
            var httpClient = new HttpClient();
            var fileContent = Encoding.UTF8.GetBytes("fileContent");
            var fileName = "file.csv";
            var actionParamName = "File";
            var url = "https://localhost:5001/api/File";
            var fileDescription = "desc";
            var formStringParam = "FileDescription";
            using var content = new MultipartFormDataContent
            {
                //UploadFileForm IFromFile File 
                {new StreamContent(new MemoryStream(fileContent)), actionParamName, fileName},
                //UploadFileForm string FileDescription
                {new StringContent(fileDescription), formStringParam}
            };

            var response = await httpClient.PostAsync(url, content);
            var responseContent = await response.Content.ReadAsStringAsync();

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual($"File received {fileName} with length {fileContent.Length} and description {fileDescription}", responseContent);
        }
    }
}
