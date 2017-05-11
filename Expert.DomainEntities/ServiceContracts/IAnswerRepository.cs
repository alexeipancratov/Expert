using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Expert.DomainEntities.Entities;

namespace Expert.DomainEntities.ServiceContracts
{
    public interface IAnswerRepository
    {
        void Save(Answer question);

        void Update(Answer question);

        IQueryable<Answer> GetAnswers(Expression<Func<Answer, bool>> filterExpression);
    }
}
