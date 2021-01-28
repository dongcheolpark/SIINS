using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SIINS_APP_API.Models
{
    public class auth
    {
        public string id { get; set; }
        public string pw { get; set; }
    }
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
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }

}