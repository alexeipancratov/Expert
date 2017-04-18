using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Expert.DomainEntities.Entities;
using Expert.DomainEntities.ServiceContracts;

namespace Expert.Data.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        public void Save(Answer question)
        {
            throw new NotImplementedException();
        }

        public void Update(Answer question)
        {
            throw new NotImplementedException();
        }

        public List<Answer> GetAnswers(Expression<Func<Answer, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }
    }
}
