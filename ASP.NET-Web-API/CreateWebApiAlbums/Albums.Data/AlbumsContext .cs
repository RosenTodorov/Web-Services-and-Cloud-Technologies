namespace Albums.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Albums.Data.Migrations;
    using Albums.Models;

    public class AlbumsContext : DbContext, IAlbumsContext
    {
        // Your context has been configured to use a 'AlbumsContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Albums.Data.AlbumsContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'AlbumsContext' 
        // connection string in the application configuration file.
        public AlbumsContext()
            : base("name=AlbumsContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AlbumsContext, Configuration>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public IDbSet<Album> Albums { get; set; }

        public IDbSet<Artist> Artists { get; set; }

        public IDbSet<Song> Songs { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}