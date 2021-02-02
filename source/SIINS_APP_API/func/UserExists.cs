using Microsoft.EntityFrameworkCore;
using SIINS_APP_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIINS_APP_API.func
{
    public class UserExists
    {
        public static async Task<bool> Run(string id, string pw, UserDBContext _context)
        {
            pw = Encryption.Encode(pw);
            var iscorrect = from a in await _context.Users.ToListAsync()
                            where a.UserId == id
                            where a.UserPassword == pw
                            select a;
            if (iscorrect.Count() != 0)
            {
                return true;
            }
            return false;
        }

        public static async Task<int> RunNo(string id, string pw, UserDBContext _context)
        {
            pw = Encryption.Encode(pw);
            var iscorrect = from a in await _context.Users.ToListAsync()
                            where a.UserId == id
                            where a.UserPassword == pw
                            select a;
            if (iscorrect.Count() != 0)
            {
                return iscorrect.First().UserNo;
            }
            return 0;
        }
    }
}
