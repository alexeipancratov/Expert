using System;

namespace Expert.DomainEntities.Entities
{
    public class Answer : CoreEntity
    {
        public Question Question { get; set; }

        public DateTime DateTime { get; set; }

        public User User { get; set; }

        public string Content { get; set; }

        public bool Accepted { get; set; }

        public int Likes { get; set; }
    }
}
