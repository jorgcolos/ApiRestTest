using System;
using Application.Images;
using Application.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Infrastructure.Images
{
    public class ImageAccessor : IImageAccessor
    {
        private readonly Cloudinary _cloudinary;

        public ImageAccessor(IOptions<CloudinarySettings> config)
        {
            var acc = new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(acc);
        }
        public ImageUploadResults AddImage(IFormFile file)
        {
            var uploadResults = new ImageUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(file.FileName, stream),
                        Transformation = new Transformation().Height(1000).Width(1000).Crop("fill").Gravity("face")
                    };
                    uploadResults = _cloudinary.Upload(uploadParams);
                }
            }

            if (uploadResults.Error != null)
                throw new Exception(uploadResults.Error.Message);

            return new ImageUploadResults
            {
                PublicId = uploadResults.PublicId,
                Url = uploadResults.SecureUri.AbsoluteUri
            };
        }

        public string DeleteImage(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);

            var result = _cloudinary.Destroy(deleteParams);

            return result.Result == "ok" ? result.Result : null;
        }
    }
}