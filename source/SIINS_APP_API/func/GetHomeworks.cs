using Microsoft.EntityFrameworkCore;
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
        private SelectedCategoriesDBcontext userCatDB;
        private NoteCatDBContext noteCatDB;
        private NoteClassDBContext noteClassDB;
        private User user;

        public GetHomeworks(HomeworkDBContext homeworkDB, UserDBContext userDB, NoteCatDBContext noteCatDB,
                            SelectedCategoriesDBcontext userCatDB, NoteClassDBContext noteClassDB, string id)
        {
            this.homeworkDB = homeworkDB;
            this.userDB = userDB;
            this.userCatDB = userCatDB;
            this.noteCatDB = noteCatDB;
            this.noteClassDB = noteClassDB;
            user = userDB.Users.First(e => e.UserId == id);
        }
        public async Task<List<Homework>> Run()
        {

            var userlist = from a in await userCatDB.SelectedCategories.ToListAsync()
                           where a.CatUName == user.UserNo
                           select a;

            var homeworklist = from a in await homeworkDB.Homework.ToListAsync()
                               orderby a.Date
                               select a;

            var noteclasslist = await noteClassDB.NoteClasses.ToListAsync();

            List<Homework> result = new List<Homework>();

            foreach (var item in homeworklist)
            {
                bool check = false;
                var catlist = from a in await noteCatDB.NoteCats.ToListAsync()
                              where a.NoteNo == item.NoteNo
                              select a;
                foreach (var item2 in noteclasslist)
                {
                    if (item2.NoteClasses == user.UserGroup)
                    {
                        check = true;
                        break;
                    }
                    if (check) break;
                }
                if (!check) continue;
                check = false;
                foreach (var item2 in userlist)
                {
                    foreach (var item3 in catlist)
                    {
                        if (int.Parse(item3.CatAttribute) == item2.CatUSelect)
                        {
                            check = true;
                            break;
                        }
                    }
                    if (check) break;
                }
                if (check)
                {
                    result.Add(item);
                }
            }

            return result;
        }
    }
}
