using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Expert.DomainEntities.ServiceContracts;
using Expert.WebApi.ViewModels;

namespace Expert.WebApi.Controllers
{
    [RoutePrefix("search")]
    public class SearchController : ApiController
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly IUserRepository _userRepository;

        public SearchController(IQuestionRepository questionRepository,
                                IAnswerRepository answerRepository,
                                IUserRepository userRepository)
        {
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        public IHttpActionResult Search(string q)
        {
            List<SearchModel> searchResult = new List<SearchModel>();
            var foundQuestions = _questionRepository.GetQuestionsByFilter(x => x.Description.Contains(q)).ToList();
            if (foundQuestions.Any())
            {
                foundQuestions.ForEach(question => searchResult.Add(new SearchModel { QuestionId = question.Id, QuestionDescription = question.Description}));
            }

            var foundAnswers = _answerRepository.GetAnswers(x => x.Content.Contains(q)).ToList();
            if (foundAnswers.Any())
            {
                foundAnswers.ForEach(answer => searchResult.Add(new SearchModel { AnswerId = answer.Id, QuestionDescription = answer.Content }));
            }

            var foundUsers = _userRepository.GetUsersByFilter(x => x.FirstName.Contains(q) || x.LastName.Contains(q)).ToList();
            if (foundUsers.Any())
            {
                foundUsers.ForEach(user => searchResult.Add(new SearchModel { UserId = user.Id, UserName = string.Concat(user.FirstName," ",user.LastName) }));
            }

            if (!searchResult.Any())
            {
                return NotFound();
            }
                
            return Ok(searchResult);
        }

    }
}