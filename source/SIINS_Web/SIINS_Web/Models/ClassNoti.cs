using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SiinsWeb.Models
{
    public class ClassNoti
    {
        [Key]
        public int key { get; set; }
        public string ClassNotiText { get; set; }
        public string ClassNotiAttribute { get; set; }
        public string ClassNoticlass { get; set; }
        public string ClassNotiTime { get; set; }
        public bool ClassNotiEmergency { get; set; }

    }

    public class ClassNotiDBcontext : DbContext
    {
        public DbSet<ClassNoti> ClassNotis { get; set; }
    }
}