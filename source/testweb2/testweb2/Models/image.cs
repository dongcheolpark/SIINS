using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcMovie.Models
{
    public class Image
    {
        [Key]
        public int ImgNo { get; set; }
        public string Imgurl { get; set; }
    }

    public class ImageDBContext : DbContext
    {
        public DbSet<Image> Image { get; set; }
    }
}