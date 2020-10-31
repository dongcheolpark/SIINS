using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Web.Mvc;

namespace MvcMovie.Models
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
        public DbSet<Comment> Comment { get; set; }
    }
}