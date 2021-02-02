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
        private CommentDBContext commentDB;

        public HomeworkController(HomeworkDBContext context,UserDBContext userDB, NoteCatDBContext noteCatDB,
                            SelectedCategoriesDBcontext userCatDB, NoteClassDBContext noteClassDB,CommentDBContext commentDB)
        {
            _context = context;
            this.userDB = userDB;
            this.userCatDB = userCatDB;
            this.noteCatDB = noteCatDB;
            this.noteClassDB = noteClassDB;
            this.commentDB = commentDB;
        }

        // GET: api/Homework
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Homework>>> GetHomework()
        {
            DelHomeworks();
            var a = await _context.Homework.ToListAsync();
            return a;
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
        public async Task<ActionResult<List<Homework>>> PostHomework([Bind("id,pw")]auth user)
        {
            if (await UserExists.Run(user.id, user.pw, userDB))
            {
                GetHomeworks a = new GetHomeworks(_context,userDB,noteCatDB,userCatDB,noteClassDB,user.id);
                DelHomeworks();
                return await a.Run();
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
        void DelHomeworks()
        {
            var data = from a in _context.Homework.ToList()
                       where a.Date < DateTime.Today
                       select a;
            foreach (var item in data)
            {
                _DelHomeworks(item);
            }
            return;
        }
        void _DelHomeworks(Homework item)
        {
            var data2 = from a in noteCatDB.NoteCats.ToList()
                        where a.NoteNo == item.NoteNo
                        select a;
            var data3 = from a in noteClassDB.NoteClasses.ToList()
                        where a.NoteId == item.NoteNo
                        select a;
            var data4 = from a in commentDB.Comments.ToList()
                        where a.ParentNo == item.NoteNo
                        select a;
            foreach(var item2 in data2)
            {
                noteCatDB.NoteCats.Remove(item2);
            }
            foreach (var item2 in data3)
            {
                noteClassDB.NoteClasses.Remove(item2);
            }
            foreach (var item2 in data4)
            {
                commentDB.Comments.Remove(item2);
            }

            _context.Homework.Remove(item);

            _context.SaveChanges();
            noteCatDB.SaveChanges();
            noteClassDB.SaveChanges();
            commentDB.SaveChanges();
        }

    }
}
