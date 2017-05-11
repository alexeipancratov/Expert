﻿namespace Expert.DomainEntities.Entities
{
    public class Category : CoreEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string PictureUrl { get; set; }

        public string ParentId { get; set; }
    }
}
