using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIINS_APP_API.func;
using SIINS_APP_API.Models;

namespace SIINS_APP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelectedCategoriesController : ControllerBase
    {
        private readonly SelectedCategoriesDBcontext _context;
        private readonly UserDBContext userDB;

        public SelectedCategoriesController(SelectedCategoriesDBcontext context,UserDBContext userDB)
        {
            _context = context;
            this.userDB = userDB;
        }

        [HttpPost]
        public async Task<ActionResult<List<SelectedCategory>>> PostCategory([Bind("id,pw")] auth user)
        {
            int no = await UserExists.RunNo(user.id, user.pw, userDB);
            if (no != 0)
            {
                var a = from b in await _context.SelectedCategories.ToListAsync()
                        where b.CatUName == no
                        select b;
                return a.ToList();
            }
            return null;
        }

        private bool SelectedCategoryExists(int id)
        {
            return _context.SelectedCategories.Any(e => e.CatUId == id);
        }
    }
}
