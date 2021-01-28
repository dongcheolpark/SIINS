using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace SIINS_APP_API.Models
{
    public class Homework
    {
        [Key]
        public int NoteNo { get; set; }
        public string Subject { get; set; }
        public string T_Name { get; set; }
        public string Contents { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int NoteGroup { get; set; }
    }
    public class NoteCat
    {
        [Key]
        public int NoteCatId { get; set; }
        public int NoteNo { get; set; }
        public string CatAttribute { get; set; }
    }
    public class NoteClass
    {
        [Key]
        public int NoteClassId { get; set; }
        public int NoteId { get; set; }
        public int NoteClasses { get; set; }

    }
    public class HomeworkDBContext : DbContext
    {
        public HomeworkDBContext(DbContextOptions<HomeworkDBContext> options) : base(options)
        {
        }
        public DbSet<Homework> Homework { get; set; }
    }

    public class NoteCatDBContext : DbContext
    {
        public NoteCatDBContext(DbContextOptions<NoteCatDBContext> options) : base(options)
        {
        }
        public DbSet<NoteCat> NoteCats { get; set; }
        
    }

    public class NoteClassDBContext : DbContext
    {
        public NoteClassDBContext(DbContextOptions<NoteClassDBContext> options) : base(options)
        {
        }
        public DbSet<NoteClass> NoteClasses { get; set; }
    }
}