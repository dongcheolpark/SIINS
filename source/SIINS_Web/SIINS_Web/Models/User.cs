using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace SiinsWeb.Models
{
    public class User
    {   
        [Key]
        public int UserNo { get; set; }
        public string UserName { get; set; }
        public string UserClass { get; set; }
        public string UserId { get; set; }
        public string UserPassword { get; set; }
        public int UserGroup { get; set; }
    }

    public class UserDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<UserDBContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }

}