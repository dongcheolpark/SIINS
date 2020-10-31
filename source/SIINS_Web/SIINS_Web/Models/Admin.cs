using SiinsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiinsWeb.Controllers;

namespace SiinsWeb.Models
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