using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Expert.WebApi.Controllers
{
    [RoutePrefix("categories")]
    public class CategoriesController : ApiController
    {
        [HttpGet]
        [Route]
        public IHttpActionResult GetCategories()
        {
            throw new NotImplementedException();
        }
    }
}