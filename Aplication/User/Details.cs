using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Aplication.Errors;
using Domain;
using MediatR;
using Persistence;

namespace Aplication.User
{
    public class Details
    {
        public class Query : IRequest<AppUser>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, AppUser>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<AppUser> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FindAsync(request.Id);

                if (user == null)
                    throw new RestException(HttpStatusCode.NotFound, new { user = "User Not Found" });

                return user;
            }
        }
    }
}