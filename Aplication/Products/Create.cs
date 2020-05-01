using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Aplication.Products
{
    public class Create
    {
        public class Command : IRequest
        {
            public string SKU { get; set; }
            public string Name { get; set; }
            public int Quantity { get; set; }
            public double Price { get; set; }
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
                var product = new Product
                {
                    SKU = request.SKU.ToUpper(),
                    Name = request.Name,
                    Quantity = request.Quantity,
                    Price = request.Price,
                    Description = request.Description,
                    Created = DateTime.Now
                };

                _context.Products.Add(product);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}