using System.Web.Http;
using Expert.DomainEntities.ServiceContracts;
using Expert.DomainEntities.Entities;
using System.Net.Http;
using System.Net;
using System.Collections.Generic;
using System.Linq;

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
        public IHttpActionResult GetCategories(bool includeSubcategories = false)
        {
            List<Category> categories = null;

            if (includeSubcategories)
            {
                categories = _categoryRepository.GetCategoriesWithSubcategories().ToList();
            }
            else
            {
                categories = _categoryRepository.GetCategories().ToList();
            }
            
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