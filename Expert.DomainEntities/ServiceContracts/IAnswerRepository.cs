using System;
using System.Linq.Expressions;
using Expert.DomainEntities.Entities;

namespace Expert.DomainEntities.ServiceContracts
{
    public interface IAnswerRepository
    {
        void Save(Answer question);

        void Update(Answer question);

        Answer GetAnswer(Expression<Func<Answer, bool>> filterExpression);
    }
}
