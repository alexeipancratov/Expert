using Expert.DomainEntities.Entities;
using Expert.DomainEntities.ServiceContracts;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Expert.WebApi.Controllers
{
    [RoutePrefix("subcategories")]
    public class SubcategoriesController : ApiController
    {
        private readonly ISubcategoryRepository _subcategoryRepository;

        public SubcategoriesController(ISubcategoryRepository subcategoryRepository)
        {
            _subcategoryRepository = subcategoryRepository;
        }

        [Route("{subcategoryId}", Name = "GetSubcategory")]
        public IHttpActionResult GetCategory(string subcategoryId)
        {
            var category = _subcategoryRepository.GetSubcategory(subcategoryId);

            return Ok(category);
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreateSubcategory(Subcategory subcategory)
        {
            if (!ModelState.IsValid)
            {
                Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Cannot create question");
            }

            _subcategoryRepository.Create(subcategory);

            return CreatedAtRoute("GetSubcategory", new { subcategoryId = subcategory.Id }, subcategory);
        }
    }
}
