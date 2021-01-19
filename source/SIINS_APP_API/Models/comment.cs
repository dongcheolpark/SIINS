using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SIINS_APP_API.Models
{
    public class Comment
    {
        [Key]
        public int CommentNo { get; set; }
        public int ParentNo { get; set; }
        public string CommentContents { get; set; }
        public string UserName { get; set; }
    }

    public class CommentDBContext : DbContext
    {
        public CommentDBContext(DbContextOptions<CommentDBContext> options) : base(options)
        {
        }
        public DbSet<Comment> Comment { get; set; }
    }
}