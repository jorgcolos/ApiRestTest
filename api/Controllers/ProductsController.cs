using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Products;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    
    public class ProductsController : BaseController
    {
        [HttpGet]
        [AllowAnonymous]
        //get all the products
        public async Task<ActionResult<List<ProductDTO>>> List()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        //Get product by id
        public async Task<ActionResult<ProductDTO>> Details(int id)
        {
            return await Mediator.Send(new Details.Query { Id = id });
        }

        [HttpPost]
        [AllowAnonymous]
        //Create new Product
        public async Task<ActionResult<Unit>> Create(Create.Command command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("createAuth")]
        [Authorize]
        //Create new product with validation for loged users
        public async Task<ActionResult<Unit>> CreateAuth(Create.Command command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        //Edit a product by id
        public async Task<ActionResult<Unit>> Edit(int id, Edit.Command command)
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
    }
}