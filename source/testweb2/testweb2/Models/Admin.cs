using MvcMovie.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using testweb2.Controllers;

namespace testweb2.Models
{
    public class Admin
    {

        HomeworkDBContext homeworkDB { get; set; }
        CommentDBContext commentDB { get; set; }
        UserDBContext userDB { get; set; }
        CategoryDBContext categoryDB { get; set; }
        UserCategoriesDBcontext userCategoriesDB { get; set; }
        NoteCatDBContext noteCatDB { get; set; }
        ClassNotiDBcontext classNotiDB { get; set; }
    }
}