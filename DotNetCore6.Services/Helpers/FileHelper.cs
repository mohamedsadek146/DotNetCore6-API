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
    public class FileHelper
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
                    uploadedFile.FileName = fileName;
                    uploadedFile.OriginalFileName = originalFileName;
                    uploadedFile.FilePath = HttpRequestHelper.GetBaseAddress() + "/uploads/" + toFolderName + "/" + fileName;
                    uploadedFiles.Add(uploadedFile);
                }
            }

            return uploadedFiles;
        }
        public static IEnumerable<UploadedFile> Upload(IEnumerable<IFormFile> files, string toFolderName)
        {
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "uploads", toFolderName);
            if (!Directory.Exists(pathToSave))
            {
                Directory.CreateDirectory(pathToSave);
            }
            //var files = context.Request.Form.Files;
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
                    uploadedFile.FileName = fileName;
                    uploadedFile.OriginalFileName = originalFileName;
                    uploadedFile.FilePath = HttpRequestHelper.GetBaseAddress() + "/uploads/" + toFolderName + "/" + fileName;
                    uploadedFiles.Add(uploadedFile);
                }
            }

            return uploadedFiles;
        }

        public static UploadedFile Upload(IFormFile file)
        {
            return Upload(file, Constants._TEMP_UPLOAD_PATH);
        }
        public static UploadedFile Upload(IFormFile file, string toFolderName)
        {
            if (file == null)
                return null;
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "uploads", toFolderName);
            if (!Directory.Exists(pathToSave))
            {
                Directory.CreateDirectory(pathToSave);
            }
            //var files = context.Request.Form.Files;


            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            string fileExtension = file.FileName.Split('.').Last();
            string fileName = Guid.NewGuid().ToString() + "." + fileExtension;
            var fullPath = Path.Combine(pathToSave, fileName);
            //var dbPath = Path.Combine(folderName, fileName);
            var uploadedFile = new UploadedFile();
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);

                uploadedFile.FileName = fileName;
                uploadedFile.OriginalFileName = originalFileName;
                uploadedFile.FilePath = HttpRequestHelper.GetBaseAddress() + "/uploads/" + toFolderName + "/" + fileName;
            }


            return uploadedFile;
        }

        public static bool IsFileExists(string file)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), file);
            return File.Exists(filePath);
        }

        public static bool MoveFile(string filePath, string newFilePath)
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory(), filePath);
            newFilePath = Path.Combine(Directory.GetCurrentDirectory(), newFilePath);
            string newFolderPath = Path.GetDirectoryName(newFilePath);
            if (!Directory.Exists(newFolderPath))
                Directory.CreateDirectory(newFolderPath);
            if (File.Exists(filePath))
            {
                File.Move(filePath, newFilePath);
                return true;
            }

            return false;
        }

        public static bool DeleteFile(string file)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), file);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }

            return false;
        }

    }
}
