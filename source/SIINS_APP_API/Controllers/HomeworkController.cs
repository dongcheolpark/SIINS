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
    public class HomeworkController : ControllerBase
    {
        private readonly HomeworkDBContext _context;
        private readonly UserDBContext userDB;
        private SelectedCategoriesDBcontext userCatDB;
        private NoteCatDBContext noteCatDB;
        private NoteClassDBContext noteClassDB;

        public HomeworkController(HomeworkDBContext context,UserDBContext userDB, NoteCatDBContext noteCatDB,
                            SelectedCategoriesDBcontext userCatDB, NoteClassDBContext noteClassDB)
        {
            _context = context;
            this.userDB = userDB;
            this.userCatDB = userCatDB;
            this.noteCatDB = noteCatDB;
            this.noteClassDB = noteClassDB;
        }

        // GET: api/Homework
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Homework>>> GetHomework()
        {
            return await _context.Homework.ToListAsync();
        }

        // GET: api/Homework/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Homework>> GetHomework(int id)
        {
            var homework = await _context.Homework.FindAsync(id);

            if (homework == null)
            {
                return NotFound();
            }

            return homework;
        }

        // POST: api/Homework
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<List<Homework>> PostHomework([Bind("id,pw")]auth user)
        {
            if (UserExists.Run(user.id, user.pw, userDB))
            {
                GetHomeworks a = new GetHomeworks(_context,userDB,noteCatDB,userCatDB,noteClassDB,user.id);
                return a.Run();
            }
            return null;
        }

        // DELETE: api/Homework/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHomework(int id)
        {
            var homework = await _context.Homework.FindAsync(id);
            if (homework == null)
            {
                return NotFound();
            }

            _context.Homework.Remove(homework);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
