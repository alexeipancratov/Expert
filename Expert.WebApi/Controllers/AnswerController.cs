using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Expert.DomainEntities.Entities;
using Expert.DomainEntities.ServiceContracts;
using Expert.WebApi.ViewModels;

namespace Expert.WebApi.Controllers
{
    [RoutePrefix("answer")]
    public class AnswerController : ApiController
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IUserRepository _userRepository;

        public AnswerController(IAnswerRepository answerRepository, IUserRepository userRepository)
        {
            _answerRepository = answerRepository;
            _userRepository = userRepository;
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

            if (answer == null)
            {
                return NotFound();
            }

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


        [Route("create/{questionId}")]
        [HttpPost]
        public IHttpActionResult CreateAnswer(string questionId, [FromBody]Answer answer)  
        {
            if (!ModelState.IsValid)
            {
                Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Cannot create answer");
            }

            answer.QuestionId = questionId;
            _answerRepository.Save(answer);

            return Ok(answer);
        }

        [Route("rateAnswer")]
        [HttpPost]
        public IHttpActionResult RateAnswer(RateAnswerViewModel model)
        {
            var answer = _answerRepository.GetAnswer(model.AnswerId);
            var user = _userRepository.GetUser(answer.UserId);

            if (model.Operation == "up")
            {
                answer.Likes++;
                user.Rating++;
            }
            else if (model.Operation == "down")
            {
                answer.Likes--;
                user.Rating--;
            }

            _answerRepository.Update(answer);
            _userRepository.UpdateUser(user);

            return Ok();
        }

        [Route("acceptAnswer")]
        [HttpPost]
        public IHttpActionResult AcceptAnswer(string answerId)
        {
            Answer answer = _answerRepository.GetAnswer(answerId);
            answer.Accepted = true;

            _answerRepository.Update(answer);

            return Ok();
        }
    }
}
