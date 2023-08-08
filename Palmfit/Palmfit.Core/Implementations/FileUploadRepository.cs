﻿using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Palmfit.Core.Dtos;
using Palmfit.Core.Services;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Implementations
{
    public class FileUploadRepository : IFileUploadRepository
    {
        private readonly Cloudinary _cloudinary;
        private readonly PalmfitDbContext _palmfitDb;

        public FileUploadRepository(Cloudinary cloudinary, PalmfitDbContext palmfitDb)
        {
            _cloudinary = cloudinary;
            _palmfitDb = palmfitDb;
        }

        public async Task<string> UploadImageToCloudinaryAndSave(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return "Invalid file data.";
            }

            // Check file size (300KB limit)
            const int maxFileSizeInBytes = 300 * 1024; // 300KB in bytes
            if (file.Length > maxFileSizeInBytes)
            {
                return "File size exceeds the maximum limit (300KB).";
            }

            // Check file extension (allow only jpg and png files)
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!allowedExtensions.Contains(fileExtension))
            {
                return "Only jpg and png files are allowed.";
            }

            // Upload image to Cloudinary
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, file.OpenReadStream())
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.Error != null)
            {
                return "Error uploading image to Cloudinary.";
            }

            // Save Cloudinary URL or public ID to the database
            var fileUploadModel = new FileUploadModel
            {
                Id = Guid.NewGuid().ToString(),
                ImageName = file.FileName,
                CloudinaryPublicId = uploadResult.PublicId, // Store Cloudinary public ID
                CloudinaryUrl = uploadResult.Uri.ToString() // Store Cloudinary URL
            };

            _palmfitDb.fileUploadmodels.Add(fileUploadModel);
            _palmfitDb.SaveChanges();

            return "File uploaded and saved successfully!";
        }
    }
}
