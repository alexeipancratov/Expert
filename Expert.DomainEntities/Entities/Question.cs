using System;

namespace Expert.DomainEntities.Entities
{
    public class Question : CoreEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserId { get; set; }
        public string CategoryId { get; set; }
        public string TagId { get; set; }
        public int Likes { get; set; }
    }
}
