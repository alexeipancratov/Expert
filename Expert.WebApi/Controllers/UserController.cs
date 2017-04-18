using System.Net;
using System.Net.Http;
using System.Web.Http;
using Expert.DomainEntities.Entities;
using Expert.DomainEntities.ServiceContracts;

namespace Expert.WebApi.Controllers
{
    [RoutePrefix("user")]
    public class UserController : ApiController
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Route("create")]
        [HttpPost]
        public IHttpActionResult CreateUser(User user)
        {
            if (!ModelState.IsValid)
            {
                Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Cannot create question");
            }

            _userRepository.CreateUser(user);

            return Ok();
        }

        [Route("update")]
        [HttpPost]
        public IHttpActionResult UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);

            return Ok();
        }
    }
}
