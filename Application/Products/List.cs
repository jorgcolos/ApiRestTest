using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Products
{
    public class List
    {
        public class ProductsEnvelope
        {
            public List<ProductDTO> Products { get; set; }
            public int ProductCount { get; set; }
        }
        public class Query : IRequest<ProductsEnvelope>
        {
            public Query(int? limit, int? offset, string name, string Sku, double? startPrice, double? endPrice)
            {
                Limit = limit;
                Offset = offset;
                Name = name;
                SKU = Sku;
                StartPrice = startPrice;
                EndPrice = endPrice;

            }
            public int? Limit { get; set; }
            public int? Offset { get; set; }
            public string Name { get; set; }
            public string SKU { get; set; }
            public double? StartPrice { get; set; }
            public double? EndPrice { get; set; }
        }

        public class Handler : IRequestHandler<Query, ProductsEnvelope>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                this._mapper = mapper;
                _context = context;
            }


            public async Task<ProductsEnvelope> Handle(Query request, CancellationToken cancellationToken)
            {
                if (request.StartPrice >= request.EndPrice)
                    throw new RestException(HttpStatusCode.NotFound, new { product = "Start price can't be less that maximun price" });


                var queryable = _context.Products
                .AsQueryable();

                if (request.StartPrice != null || request.EndPrice != null)
                {
                    var startPrice = request.StartPrice ?? 0;
                    var endPrice = request.EndPrice ?? 999999.99;

                    queryable = queryable.Where(x => x.Price >= startPrice && x.Price <= endPrice);
                }

                if (request.Name != null)
                    queryable = queryable.Where(x => x.Name.Contains(request.Name));

                if (request.SKU != null)
                    queryable = queryable.Where(x => x.SKU.Contains(request.SKU));

                var products = await queryable
                .Skip(request.Offset ?? 0)
                .Take(request.Limit ?? 3).ToListAsync();

                return new ProductsEnvelope
                {
                    Products = _mapper.Map<List<Product>, List<ProductDTO>>(products),
                    ProductCount = queryable.Count()
                };

            }
        }
    }
}