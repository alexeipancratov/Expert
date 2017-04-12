using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Expert.DomainEntities.Entities;

namespace Expert.DomainEntities.ServiceContracts
{
    public interface IQuestionRepository
    {
        IQueryable<Question> GetQuestions();

        IQueryable<Question> GetQuestionByFilter(Expression<Func<Question, bool>> expression);

        void Save(Question question);

        void Update(Question question);
    }
}
