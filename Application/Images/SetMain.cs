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
    public class SetMain
    {
        public class Command : IRequest
        {
            public int IdProduct { get; set; }
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.SingleOrDefaultAsync(x => x.Id == request.IdProduct);
                
                if (product == null)
                    throw new RestException(HttpStatusCode.NotFound, new { Product = "Not found" });

                var image = product.Images.FirstOrDefault(x => x.Id == request.Id);

                if (image == null)
                    throw new RestException(HttpStatusCode.NotFound, new { Image = "Not found" });

                var currentMain = product.Images.FirstOrDefault(x => x.IsMain);

                currentMain.IsMain = false;
                image.IsMain = true;

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}