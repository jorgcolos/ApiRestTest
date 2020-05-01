using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Aplication.Errors;
using FluentValidation;
using MediatR;
using Persistence;

namespace Aplication.Products
{
    public class Edit
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
            public string SKU { get; set; }
            public string Name { get; set; }
            public int? Quantity { get; set; }
            public double? Price { get; set; }
            public string Description { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                //RuleFor(x => x.SKU).NotEmpty();
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.Quantity).NotEmpty();
                RuleFor(x => x.Price).NotEmpty();
            }
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
                var product = await _context.Products.FindAsync(request.Id);

                if (product == null)
                    throw new RestException(HttpStatusCode.NotFound, new { product = "Product Not Found" });

                product.SKU = request.SKU ?? product.SKU;
                product.Name = request.Name ?? product.Name;
                product.Quantity = request.Quantity ?? product.Quantity;
                product.Price = request.Price ?? product.Price;
                product.Description = request.Description ?? request.Description;

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}