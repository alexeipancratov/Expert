using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Expert.DomainEntities.Entities;

namespace Expert.WebApi.Controllers
{
    [RoutePrefix("categories")]
    public class CategoriesController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetCategories()
        {
            return Ok(new Category { Description = "Description 1", Name = ".NET" });
        }
    }
}