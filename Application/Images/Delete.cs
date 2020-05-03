using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Images
{
    public class Delete
    {
        public class Command : IRequest
        {
            public int IdProduct { get; set; }
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IImageAccessor _imageAccessor;

            public Handler(DataContext context, IImageAccessor imageAccessor)
            {
                _imageAccessor = imageAccessor;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.SingleOrDefaultAsync(x => x.Id == request.IdProduct);
                
                if (product == null)
                    throw new RestException(HttpStatusCode.NotFound, new { Product = "Product Not Found" });

                var image = product.Images.FirstOrDefault(x => x.Id == request.Id);

                if (image == null)
                    throw new RestException(HttpStatusCode.NotFound, new { Image = "Image Not Found" });

                if (image.IsMain)
                    throw new RestException(HttpStatusCode.BadRequest, new { Image = "You cannot delete your main image" });

                var result = _imageAccessor.DeleteImage(image.IdCloudinary);

                if (result == null)
                    throw new Exception("Problem deleting the image");

                product.Images.Remove(image);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}