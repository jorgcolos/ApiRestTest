using System.Collections.Generic;
using System.Threading.Tasks;
using Application.User;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class UserController : BaseController
    {

        [HttpGet]
        [AllowAnonymous]
        //List of all Users
        public async Task<ActionResult<List<AppUser>>> List()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        //Get user by id
        public async Task<ActionResult<AppUser>> Details(int id)
        {
            return await Mediator.Send(new Details.Query { Id = id });
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        //Edit a user by id
        public async Task<ActionResult<User>> Edit(int id, Edit.Command command)
        {
            command.Id = id;
            return await Mediator.Send(command);
        }
        [HttpDelete("{id}")]
        [AllowAnonymous]
        //Delete a product
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await Mediator.Send(new Delete.Command { Id = id });
        }
        [AllowAnonymous]
        [HttpPost("login")]
        //Login for User (Email, Password)
        public async Task<ActionResult<User>> Login(Login.Query query)
        {
            return await Mediator.Send(query);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        // Register new users
        public async Task<ActionResult<User>> Register(Register.Command command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("currentUser")]
        //Get the current loged user
        public async Task<ActionResult<User>> CurrentUser()
        {
            return await Mediator.Send(new CurrentUser.Query());
        }

    }
}