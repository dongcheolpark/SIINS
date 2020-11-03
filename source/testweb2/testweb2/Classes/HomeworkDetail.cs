using MvcMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testweb2.Classes
{
    public class HomeworkDetail
    {
        public Homework Homework { get; set; }
        public IEnumerable<NoteCat> Category { get; set; }
        public List<string> Catname { get; set; }
        public HomeworkDetail(Homework a, IEnumerable<NoteCat> b,List<string> c)
        {
            Homework = a;
            Category = b;
            Catname = c;
        }
    }
}