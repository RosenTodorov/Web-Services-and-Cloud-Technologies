namespace Albums.Data
{
    using System;
    using System.Collections.Generic;

    using Albums.Models;
    using Albums.Data.Repositories;

    public class AlbumsData : IMusicAlbumsData
    {
        private readonly IAlbumsContext context;
        private readonly IDictionary<Type, object> repositories;

        public AlbumsData(IAlbumsContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public AlbumsData()
            : this(new AlbumsContext())
        {
        }

        public IGenericRepository<Album> Albums
        {
            get
            {
                return this.GetRepository<Album>();
            }
        }

        public IGenericRepository<Song> Songs
        {
            get
            {
                return this.GetRepository<Song>();
            }
        }

        public IGenericRepository<Artist> Artists
        {
            get
            {
                return this.GetRepository<Artist>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);

            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}