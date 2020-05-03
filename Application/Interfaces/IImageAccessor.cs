using Application.Images;
using Microsoft.AspNetCore.Http;

namespace Application.Interfaces
{
    public interface IImageAccessor
    {
         ImageUploadResults AddImage(IFormFile file);

         string DeleteImage(string publicId);
    }
}