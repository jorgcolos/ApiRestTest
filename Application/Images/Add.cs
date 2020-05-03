using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Images
{
    public class Add
    {
        public class Command : IRequest<Image>
        {
            public int IdProduct { get; set; }
            public IFormFile File { get; set; }
        }

        public class Handler : IRequestHandler<Command, Image>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccesor;
            private readonly IImageAccessor _imageAccesor;
            public Handler(DataContext context, IUserAccessor userAccesor, IImageAccessor imageAccesor)
            {
                _imageAccesor = imageAccesor;
                _userAccesor = userAccesor;
                _context = context;
            }

            public async Task<Image> Handle(Command request, CancellationToken cancellationToken)
            {
                var imageUploadResult = _imageAccesor.AddImage(request.File);

                var product = await _context.Products.SingleOrDefaultAsync(x => x.Id == request.IdProduct);
                
                if(product == null)
                    throw new RestException(HttpStatusCode.NotFound, new { product = "Product Not Found" });

                var image = new Image
                {
                    Url = imageUploadResult.Url,
                    IdCloudinary = imageUploadResult.PublicId
                };

                if (!product.Images.Any(x => x.IsMain))
                    image.IsMain = true;

                product.Images.Add(image);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return image;

                throw new Exception("Problem saving changes");
            }
        }
    }
}