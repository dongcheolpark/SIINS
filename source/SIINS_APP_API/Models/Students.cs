using System.Collections.Generic;

namespace SIINS_APP_API.Models
{
    public class StudentsModel
    {
        public IEnumerable<Category> category { set; get; }
        public IEnumerable<SelectedCategory> userCategory { set; get; }
        public Grade grade { get; set; }
    }
}