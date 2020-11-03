namespace SiinsWeb.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

<<<<<<< HEAD:source/testweb2/testweb2/Migrations/Configuration.cs
    internal sealed class Configuration : DbMigrationsConfiguration<testweb2.Models.UserDBContext>
=======
    internal sealed class Configuration : DbMigrationsConfiguration<SiinsWeb.Models.NoteClassDBContext>
>>>>>>> ab9e3a839a0355e33e4bfc33a08cdccb45bc2612:source/SIINS_Web/SIINS_Web/Migrations/Configuration.cs
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

<<<<<<< HEAD:source/testweb2/testweb2/Migrations/Configuration.cs
        protected override void Seed(testweb2.Models.UserDBContext context)
=======
        protected override void Seed(SiinsWeb.Models.NoteClassDBContext context)
>>>>>>> ab9e3a839a0355e33e4bfc33a08cdccb45bc2612:source/SIINS_Web/SIINS_Web/Migrations/Configuration.cs
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
