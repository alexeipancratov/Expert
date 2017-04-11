using System.Collections.Generic;

namespace Expert.DomainEntities.Entities
{
    public class User : CoreEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public int Level { get; set; }

        public string Department { get; set; }

        public List<int> Categories { get; set; }   
    }
}
