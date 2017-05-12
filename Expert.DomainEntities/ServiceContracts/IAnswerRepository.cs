using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Expert.DomainEntities.Entities;

namespace Expert.DomainEntities.ServiceContracts
{
    public interface IAnswerRepository
    {
        void Save(Answer question);

        void Update(Answer question);

        List<Answer> GetAnswers(Expression<Func<Answer, bool>> filterExpression);

        Answer GetAnswer(string answerId);
    }
}
