﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Expert.DomainEntities.Entities;
using Expert.DomainEntities.ServiceContracts;
using MongoDB.Driver;

namespace Expert.Data.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly IMongoCollection<Answer> _collection;

        public AnswerRepository(ExpertContext context)
        {
            _collection = context.Database.GetCollection<Answer>("answers");
        }

        public void Save(Answer answer)
        {
            _collection.InsertOne(answer);
        }

        public void Update(Answer answer)
        {
            _collection.ReplaceOne(a => a.Id == answer.Id, answer);
        }

        public List<Answer> GetAnswers(Expression<Func<Answer, bool>> filterExpression)
        {
            return _collection.AsQueryable().Where(filterExpression).ToList();
        }

        public Answer GetAnswer(string answerId)
        {
            return _collection.FindSync(a => a.Id == answerId).Single();
        }
    }
}
