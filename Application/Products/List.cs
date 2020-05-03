using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Products
{
    public class List
    {
        public class Query : IRequest<List<ProductDTO>> { }

        public class Handler : IRequestHandler<Query, List<ProductDTO>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                this._mapper = mapper;
                _context = context;
            }


            public async Task<List<ProductDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var products = await _context.Products.ToListAsync();

                return _mapper.Map<List<Product>, List<ProductDTO>>(products);
            }
        }
    }
}