namespace TravelWithMe.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using TravelWithMe.Models;
    using TravelWithMe.Data.Migrations;

    public class TravelWithMeDbContext : IdentityDbContext<TravelWithMeUser>
    {
        public TravelWithMeDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TravelWithMeDbContext, Configuration>());
        }

        public static TravelWithMeDbContext Create()
        {
            return new TravelWithMeDbContext();
        }

        public System.Data.Entity.DbSet<TravelWithMe.Models.City> Cities { get; set; }

        public System.Data.Entity.DbSet<TravelWithMe.Models.Travel> Travels { get; set; }
    }
}
