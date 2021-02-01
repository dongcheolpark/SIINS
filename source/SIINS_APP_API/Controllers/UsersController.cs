using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SIINS_APP_API.func;
using SIINS_APP_API.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace SIINS_APP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserDBContext _context;


        public UsersController(UserDBContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}/{pw}")]
        public async Task<ActionResult<bool>> GetUser(string id,string pw)
        {
            if (await UserExists.Run(id, pw, _context))
            {
                return true;
            }
            return false;
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<string> PostUser(string id,string pw)
        {
            return "1";
        }
    }
}
