using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Products
{
    public class Edit
    {
        public class Command : IRequest<ProductDTO>
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
        public class Handler : IRequestHandler<Command, ProductDTO>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                this._mapper = mapper;
                _context = context;
            }

            public async Task<ProductDTO> Handle(Command request, CancellationToken cancellationToken)
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

                var productUpdated = await _context.Products.FindAsync(request.Id);

                if (productUpdated == null)
                    throw new RestException(HttpStatusCode.NotFound, new { product = "Product Not Found" });

                var productToReturn = _mapper.Map<Product, ProductDTO>(productUpdated);
                if (success) return productToReturn;

                throw new Exception("Problem saving changes");
            }
        }
    }
}