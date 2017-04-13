using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Expert.DomainEntities.Entities;

namespace Expert.WebApi.ViewModels
{
    public class QandAViewModel
    {
        public Question Question { get; set; }
        public List<Answer> Answers { get; set; }
    }
}