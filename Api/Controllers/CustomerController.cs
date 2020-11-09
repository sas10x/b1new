using System.Threading.Tasks;
using Application.Customers;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [AllowAnonymous]
    public class CustomerController : BaseController
    {
        [HttpPost("session")]
        public async Task<ActionResult<Unit>> Login(Session.Command command)
        {
            return await Mediator.Send(command);
        }
        [HttpPost("signup")]
        public async Task<ActionResult<Customer>> Register(SignUp.Command command)
        {
            var id = await Mediator.Send(command);
            return Ok(id);
        }  
    }
}