using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Expert.Data.Repositories;
using Expert.DomainEntities.Entities;
using Expert.DomainEntities.ServiceContracts;

namespace Expert.WebApi.Controllers
{
    [RoutePrefix("answer")]
    public class AnswerController : ApiController
    {
        private readonly IAnswerRepository _answerRepository;

        public AnswerController(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetAnswer(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Cannot retrieve answer");
            }

            var answer = _answerRepository.GetAnswers(x => x.Id == id).SingleOrDefault();
            return Ok(answer);
        }

        [Route("forQuestion/{questionId}")]
        [HttpGet]
        public IHttpActionResult GetAnswersForQuestion(string questionId)   
        {
            if (string.IsNullOrEmpty(questionId))
            {
                Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Cannot retrieve answers for question {questionId}");
            }

            var answers = _answerRepository.GetAnswers(x => x.QuestionId == questionId);
            return Ok(answers);
        }


        [Route("create")]
        [HttpPost]
        public IHttpActionResult CreateAnswer(Answer answer, string questionId)  
        {
            if (!ModelState.IsValid)
            {
                Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Cannot create answer");
            }

            answer.QuestionId = questionId;
            _answerRepository.Save(answer);

            return CreatedAtRoute("GetAnswer", new { id = answer.Id }, answer);
        }
    }
}
