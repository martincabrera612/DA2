using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Services.Sessions;
using WebApi.Controllers.Sessions.Models;
using WebApi.Filters;

namespace WebApi.Controllers.Sessions
{
    [Route("api/sessions")]
    [ApiController]
    [ExceptionFilter]
    public class SessionController(ISessionService _sessionService) : ControllerBase
    {
        [HttpPost]
        public IActionResult PostSession([FromBody] Login login)
        {
            Session session = _sessionService.AddSession(login.Username, login.Password);
            User userIn = _sessionService.GetUserFromSession(session.Token);
            return Ok(session);
        }
    }
}
