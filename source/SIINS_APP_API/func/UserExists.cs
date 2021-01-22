using SIINS_APP_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIINS_APP_API.func
{
    public class UserExists
    {
        public static bool Run(string id, string pw, UserDBContext _context)
        {
            pw = Encryption.Encode(pw);
            var iscorrect = from a in _context.Users.ToList()
                            where a.UserId == id
                            where a.UserPassword == pw
                            select a;
            if (iscorrect.Count() != 0)
            {
                return true;
            }
            return false;
        }
    }
}
