using SIINS_APP_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIINS_APP_API.func
{

    public class GetHomeworks
    {
        private HomeworkDBContext homeworkDB;
        private UserDBContext userDB;
        private UserCategoriesDBcontext userCatDB;
        private int UserNo, UserGr;

        public GetHomeworks(HomeworkDBContext homeworkDB, UserDBContext userDB, NoteCatDBContext noteCatDB , UserCategoriesDBcontext userCatDB, string id)
        {
            this.homeworkDB = homeworkDB;
            this.userDB = userDB;
            this.userCatDB = userCatDB;
            var a = userDB.Users.First(e => e.UserId == id);
            UserNo = a.UserNo;
            UserGr = a.UserGroup;
        }
        public List<Homework> Run()
        {

            var userlist = from a in userCatDB.Categories.ToList()
                           where a.CatUName == UserNo
                           select a;
            var homeworklist = from a in homeworkDB.Homework.ToList()
                               orderby a.Date
                               select a;
            

        }

    }
}
