using System.Collections.Generic;

namespace Expert.WebApi.ViewModels
{
    public class UserSubcategoriesUpdate
    {
        public string UserId { get; set; }

        public List<string> Subcategories { get; set; }
    }
}