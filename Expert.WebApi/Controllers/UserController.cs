using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web.Http;
using Expert.DomainEntities.Entities;
using Expert.DomainEntities.ServiceContracts;
using Expert.WebApi.ViewModels;

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

            return CreatedAtRoute("GetUser", new { userId = user.Id }, user);
        }

        [Route("{userId}", Name = "GetUser")]   
        public IHttpActionResult GetUser(string userId) 
        {
            User user = _userRepository.GetUser(userId);

            return Ok(user);
        }

        [Route("update")]
        [HttpPost]
        public IHttpActionResult UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);

            return Ok(user);
        }

        [Route("updateSubcategories")]
        [HttpPost]
        public IHttpActionResult UpdateUserSubcategories([FromBody] UserSubcategoriesUpdate model)
        {
            User user = _userRepository.GetUser(model.UserId);

            user.Subcategories = model.Subcategories;

            _userRepository.UpdateUser(user);

            return Ok(user);
        }

        [Route("topUsers/{categoryId}")]
        [HttpGet]
        public IHttpActionResult GetTopUsersByCategory(string categoryId)
        {
            if (string.IsNullOrWhiteSpace(categoryId))
            {
                Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Cannot retrieve users");
            }

            List<User> topUsers = _userRepository.GetUsersByFilter(x => x.Subcategories.Contains(categoryId)).OrderByDescending(x => x.Rating).Take(3).ToList();

            return Ok(topUsers);
        }
    }
}
