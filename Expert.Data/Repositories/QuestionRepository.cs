using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Expert.DomainEntities.Entities;
using Expert.DomainEntities.ServiceContracts;
using MongoDB.Driver;

namespace Expert.Data.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ExpertContext _context;

        public QuestionRepository(ExpertContext context)
        {
            _context = context;
        }

        public IQueryable<Question> GetQuestions()
        {
            return _context.Database.GetCollection<Question>("questions").AsQueryable();
        }

        public IQueryable<Question> GetQuestionByFilter(Expression<Func<Question, bool>> expression)
        {
            return GetQuestions().Where(expression);
        }

        public void Save(Question question)
        {
            _context.Database.GetCollection<Question>("questions").InsertOne(question);
        }

        public void Update(Question question)
        {
            _context.Database.GetCollection<Question>("questions").UpdateOne(Builders<Question>.Filter.Eq(x => x.Id, question.Id), 
                                                                             Builders<Question>.Update.Set(x => x, question));
        }
    }
}
