using MvcMovie.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Web.Http.OData.Query;

namespace testweb2.Models
{
    public class DBmigration : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Homework> Homework { get; set; }
        public DbSet<NoteCat> NoteCat { get; set; }
        public DbSet<NoteClass> NoteClass { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<SelectedCategory> Categories { get; set; }
        public DbSet<ClassNoti> ClassNotis { get; set; }
    }
}