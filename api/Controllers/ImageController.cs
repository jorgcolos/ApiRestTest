using System.Threading.Tasks;
using Application.Images;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class ImageController : BaseController
    {
        [HttpPost("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Image>> Add(int id, [FromForm]Add.Command command)
        {
            command.IdProduct = id;
            return await Mediator.Send(command);
        }

        [HttpDelete("{idProduct}/{idImage}")]
        [AllowAnonymous]
        public async Task<ActionResult<Unit>> Delete(int idProduct, int idImage)
        {
            return await Mediator.Send(new Delete.Command { IdProduct = idProduct, Id = idImage });
        }

        [HttpPost("{idProduct}/{idImage}/setMain")]
        [AllowAnonymous]
        public async Task<ActionResult<Unit>> setMain(int idProduct, int idImage)
        {
            return await Mediator.Send(new SetMain.Command { IdProduct = idProduct, Id = idImage });
        }

    }
}