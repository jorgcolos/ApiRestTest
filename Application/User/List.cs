using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.User
{
    public class List
    {
        public class UsersEnvelope
        {
            public List<AppUser> AppUser { get; set; }
            public int ProductCount { get; set; }
        }
        public class Query : IRequest<UsersEnvelope>
        {
            public Query(int? limit, int? offset, string name)
            {
                Limit = limit;
                Offset = offset;
                Name = name;

            }
            public int? Limit { get; set; }
            public int? Offset { get; set; }
            public string Name { get; set; }
        }
        public class Handler : IRequestHandler<Query, UsersEnvelope>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<UsersEnvelope> Handle(Query request, CancellationToken cancellationToken)
            {
                var queryable = _context.Users
                .AsQueryable();

                if (request.Name != null)
                    queryable = queryable.Where(x => x.Name.Contains(request.Name));

                var users = await queryable
                .Skip(request.Offset ?? 0)
                .Take(request.Limit ?? 3).ToListAsync();

                return new UsersEnvelope
                {
                    AppUser = users,
                    ProductCount = queryable.Count()
                };

            }
        }
    }
}