using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace SIINS_APP_API.Models
{
    public class Category
    {
        [Key]
        public int CatId { get; set; }
        public string CatName { get; set; }
        public string CatAttribute { get; set; }
    }

    public class SelectedCategory
    {
        [Key]
        public int CatUId { get; set; }
        public int CatUName { get; set; }
        public int CatUSelect { get; set; }
    }

    public class Grade
    {
        [Key]
        public int GradeNo { get; set; }
        public int Class1 { get; set; }
        public int Class2 { get; set; }
        public int Class3 { get; set; }

        public Grade(int a, int b, int c)
        {
            Class1 = a;
            Class2 = b;
            Class3 = c;
        }
    }

    public class GradeData
    {
        public Grade grade;
        public IEnumerable<Category> category;
        public GradeData(Grade a, IEnumerable<Category> b){
            grade = a;
            category = b;
        }
    }
    public class NoteGradeData
    {
        public Grade grade;
        public IEnumerable<NoteCat> noteCats;
        public NoteGradeData(Grade a, IEnumerable<NoteCat> b)
        {
            grade = a;
            noteCats = b;
        }
    }
    public class GradeDBContext : DbContext
    {
        public DbSet<Grade> Grades { get; set; }
    }

    public class CategoryDBcontext : DbContext
    {
        public CategoryDBcontext(DbContextOptions<CategoryDBcontext> options) : base(options)
        {
        }
        public DbSet<Category> Category { get; set; }
    }

    public class UserCategoriesDBcontext : DbContext
    {
        public UserCategoriesDBcontext(DbContextOptions<UserCategoriesDBcontext> options) : base(options)
        {
        }
        public DbSet<SelectedCategory> Categories { get; set; }
    }

}