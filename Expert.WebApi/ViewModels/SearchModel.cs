using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Expert.WebApi.ViewModels
{
    public class SearchModel
    {
        public string QuestionId { get; set; }

        public string QuestionDescription { get; set; }

        public string AnswerId { get; set; }

        public string AnswerDescription { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }    
    }
}