using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Products
{
    public class Details
    {
        public class Query : IRequest<ProductDTO>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ProductDTO>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                this._mapper = mapper;
                _context = context;
            }

            public async Task<ProductDTO> Handle(Query request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.FindAsync(request.Id);

                if (product == null)
                    throw new RestException(HttpStatusCode.NotFound, new { product = "Product Not Found" });

                var productToReturn = _mapper.Map<Product, ProductDTO>(product);

                return productToReturn;
            }
        }
    }
}