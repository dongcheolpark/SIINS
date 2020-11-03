using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiinsWeb.Models
{
    public class StudentsModel
    {
        public IEnumerable<Category> category { set; get; }
        public IEnumerable<SelectedCategory> userCategory { set; get; }
        public Grade grade { get; set; }
    }
}