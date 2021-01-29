using API.Models;
using API.Repositories;
using API.Sercuity;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
	[Route("account")]
	public class AccountController : ControllerBase
	{
		[HttpPost]
		[Route("login")]
		[AllowAnonymous]
		public ActionResult<dynamic> Authenticate([FromBody] User model)
		{
			if (model == null)
				return BadRequest(new { message = "Invalid parameter User!" });

			var user = SecurityRepository.GetUser(model.Username, model.Password);
			if (user == null)
				return NotFound(new { message = "Username or Password Invalid!"});


			var token = TokenService.GenerateToken(user);

			return Ok( new { user, token } );
		}

		[HttpGet]
		[Route("anonymous")]
		[AllowAnonymous]
		public string Anonymous() => "Your access is Anonymous.";

		[HttpGet]
		[Route("authenticated")]
		[Authorize]
		public string Authenticated() => $"You is Authenticated - {User.Identity.Name}";

		[HttpGet]
		[Route("employee")]
		[Authorize(Roles = Roles.Employee)]
		[Authorize(Roles = Roles.Manager)]
		public string Employee() => $"{User.Identity.Name}, you are Employee.";

		[HttpGet]
		[Route("manager")]
		[Authorize(Roles = Roles.Manager)]
		public string Manager() => $"{User.Identity.Name}, you are Manager.";
	}
}
