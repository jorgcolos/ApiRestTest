using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Aplication.Errors;
using Aplication.Interfaces;
using Aplication.Validators;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Aplication.User
{
    public class Edit
    {
        public class Command : IRequest<User>
        {
            public int Id { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public string Name { get; set; }
            public string PhoneNumber { get; set; }
            public DateTime? Birthday { get; set; }
        }
        public class CommanValidator : AbstractValidator<Command>
        {
            public CommanValidator()
            {
                RuleFor(x => x.UserName).NotEmpty();
                RuleFor(x => x.Email).NotEmpty().EmailAddress();
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.PhoneNumber).PhoneNumber();
            }
        }
        public class Handler : IRequestHandler<Command, User>
        {
            private readonly DataContext _context;
            private readonly UserManager<AppUser> _userManager;
            private readonly IJwtGenerator _jwtGenerator;
            public Handler(DataContext context, UserManager<AppUser> userManager, IJwtGenerator jwtGenerator)
            {
                _jwtGenerator = jwtGenerator;
                _userManager = userManager;
                _context = context;
            }

            public async Task<User> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FindAsync(request.Id);

                if (user == null)
                    throw new RestException(HttpStatusCode.NotFound, new { user = "User Not Found" });

                if (await _context.Users.Where(x => x.Id == request.Id &&  x.Email == request.Email && x.Name == request.Name && x.Email == request.Email 
                && x.PhoneNumber == request.PhoneNumber && x.Birthday == request.Birthday).AnyAsync())
                    throw new RestException(HttpStatusCode.BadRequest, new { User = "No data to update" });


                if (await _context.Users.Where(x => x.Email == request.Email && x.Id != request.Id).AnyAsync())
                    throw new RestException(HttpStatusCode.BadRequest, new { Email = "Email already exists" });

                if (await _context.Users.Where(x => x.UserName == request.UserName && x.Id != request.Id).AnyAsync())
                    throw new RestException(HttpStatusCode.BadRequest, new { UserName = "User already exists" });

                user.UserName = request.UserName ?? user.UserName;
                user.Name = request.Name ?? user.Name;
                user.Email = request.Email ?? user.Email;
                user.PhoneNumber = request.PhoneNumber ?? user.PhoneNumber;
                user.Birthday = request.Birthday ?? user.Birthday;


                var success = await _context.SaveChangesAsync() > 0;

                if (success)
                {
                    return new User
                    {
                        Name = user.Name,
                        Token = _jwtGenerator.CreateToken(user),
                        UserName = user.UserName,
                    };
                }

                throw new Exception("Problem saving changes");
            }
        }
    }
}