using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Expert.DomainEntities.Entities;
using Expert.DomainEntities.ServiceContracts;
using Expert.WebApi.ViewModels;

namespace Expert.WebApi.Controllers
{
    [RoutePrefix("question")]
    public class QuestionController : ApiController
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;

        public QuestionController(IQuestionRepository questionRepository,
                                  IAnswerRepository answerRepository)
        {
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
        }

        [Route("{questionId}", Name = "GetQuestion")]
        public IHttpActionResult GetQuestion(string questionId)
        {
            if (string.IsNullOrEmpty(questionId))
            {
                Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Cannot retrieve question");
            }

            var question = _questionRepository.GetQuestionsByFilter(x => x.Id == questionId).SingleOrDefault();

            return Ok(question);
        }


        [Route("withAnswers/{questionId}")]
        public IHttpActionResult GetQuestionWithAnswers(string questionId)  
        {
            if (string.IsNullOrEmpty(questionId))
            {
                Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Cannot retrieve question");
            }

            var question = _questionRepository.GetQuestionsByFilter(x => x.Id == questionId).SingleOrDefault();
            var answers = _answerRepository.GetAnswers(x => x.QuestionId == questionId);

            var viewModel = new QandAViewModel
            {
                Question = question,
                Answers = answers
            };
            return Ok(viewModel);
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

            return CreatedAtRoute("GetQuestion", new { questionId = question.Id}, question);
        }

        [Route("getByCategory/{categoryId}")]
        public IHttpActionResult GetQuestionsByCategory(string categoryId)
        {
            if (string.IsNullOrWhiteSpace(categoryId))
            {
                Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Cannot retrieve questions");
            }

            var questions = _questionRepository.GetQuestionsByFilter(x => x.CategoryId == categoryId);

            return Ok(questions);
        }

    }
}