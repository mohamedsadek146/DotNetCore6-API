using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using DotNetCore6.Helpers;
using DotNetCore6.ViewModels.Shared;

namespace DotNetCore6.Services.Helpers
{
    public class AttachmentHelper
    {
        public static HttpContext context => new HttpContextAccessor().HttpContext;

        public static IEnumerable<UploadedFile> Upload(string toFolderName)
        {
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "uploads", toFolderName);
            if (!Directory.Exists(pathToSave))
            {
                Directory.CreateDirectory(pathToSave);
            }
            var files = context.Request.Form.Files;
            List<UploadedFile> uploadedFiles = new List<UploadedFile>();
            foreach (var file in files)
            {
                var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                string fileExtension = file.FileName.Split('.').Last();
                string fileName = Guid.NewGuid().ToString() + "." + fileExtension;
                var fullPath = Path.Combine(pathToSave, fileName);
                //var dbPath = Path.Combine(folderName, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    var uploadedFile = new UploadedFile();
                    uploadedFile.FileName = originalFileName;
                    uploadedFile.FilePath = HttpRequestHelper.GetBaseAddress() + "/uploads/" + toFolderName + "/" + fileName;
                    uploadedFiles.Add(uploadedFile);
                }
            }

            return uploadedFiles;
        }
    }
}
