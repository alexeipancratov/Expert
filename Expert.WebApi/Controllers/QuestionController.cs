using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Expert.DomainEntities.Entities;
using Expert.DomainEntities.ServiceContracts;

namespace Expert.WebApi.Controllers
{
    [RoutePrefix("question")]
    public class QuestionController : ApiController
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        [Route("getAll")]
        [HttpGet]
        public IHttpActionResult GetQuestions()
        {
            var question = _questionRepository.GetQuestions();

            return Ok(question);
        }

        [Route("{id}", Name = "GetQuestion")]
        public IHttpActionResult GetQuestion(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Cannot retrieve question");
            }

            var question = _questionRepository.GetQuestionByFilter(x => x.Id == id).SingleOrDefault();

            return Ok(question);
        }


        [Route("create")]
        [HttpPost]
        public IHttpActionResult CreateQuestion(Question question)
        {
            if (!ModelState.IsValid)
            {
                Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Cannot create question");
            }

            _questionRepository.Save(question);

            return CreatedAtRoute("GetQuestion", new {id = question.Id}, question);
        }
    }
}