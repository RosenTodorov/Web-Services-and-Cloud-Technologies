namespace Albums.Data.Repositories
{
    using Albums.Data.Repositories;
    using Albums.Models;

    public interface IMusicAlbumsData
    {
        IGenericRepository<Album> Albums { get; }

        IGenericRepository<Artist> Artists { get; }

        IGenericRepository<Song> Songs { get; }

        void SaveChanges();
    }
}