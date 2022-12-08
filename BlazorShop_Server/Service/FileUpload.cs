﻿using BlazorShop_Server.Service.IService;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorShop_Server.Service
{
	public class FileUpload : IFileUpload
	{
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUpload(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> UploadFile(IBrowserFile file)
        {
            FileInfo fileInfo = new(file.Name);
            var fileName = Guid.NewGuid().ToString()+fileInfo.Extension;
            var folderDirectory = $"{_webHostEnvironment.WebRootPath}\\images\\product";
            if(!Directory.Exists(folderDirectory))
            {
                Directory.CreateDirectory(folderDirectory);
            }
            var filePath = Path.Combine(folderDirectory, fileName);

            await using FileStream fs = new FileStream(filePath, FileMode.Create);
            await file.OpenReadStream().CopyToAsync(fs);

            var fullPath = $"/images/product/{fileName}";
            return fullPath;
        }   

        public bool DeleteFile(String filePath)
        {
            if(File.Exists(filePath))
            {
                File.Delete(_webHostEnvironment.WebRootPath+filePath);
                return true;
            }
            return false;
        }
    }
}
