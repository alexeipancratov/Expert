using System.Linq;
using System.Web.Http;
using Expert.DomainEntities.ServiceContracts;
using Expert.DomainEntities.Entities;
using System.Net.Http;
using System.Net;

namespace Expert.WebApi.Controllers
{
    [RoutePrefix("categories")]
    public class CategoriesController : ApiController
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetCategories()
        {
            var categories = _categoryRepository.GetCategories();
            
            return Ok(categories);
        }

        [HttpGet]
        [Route("withSubcategories")]
        public IHttpActionResult GetCategoriesWithSubcategories()
        {
            var categories = _categoryRepository.GetCategoriesWithSubcategories();

            return Ok(categories);
        }

        [Route("{categoryId}", Name = "GetCategory")]
        public IHttpActionResult GetCategory(string categoryId)
        {
            var category = _categoryRepository.GetCategory(categoryId);

            return Ok(category);
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreateCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Cannot create question");
            }

            _categoryRepository.Create(category);

            return CreatedAtRoute("GetCategory", new { categoryId = category.Id }, category);
        }
    }
}