namespace TravelWithMe.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using TravelWithMe.Data.Repositories;
    using TravelWithMe.Models;

    public class TravelWithMeData : ITravelWithMeData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public TravelWithMeData()
            : this(new TravelWithMeDbContext())
        {
        }

        public TravelWithMeData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<TravelWithMeUser> Users
        {
            get
            {
                return this.GetRepository<TravelWithMeUser>();
            }
        }

        public IGenericRepository<Travel> Travels
        {
            get
            {
                return this.GetRepository<Travel>();
            }
        }

        public IGenericRepository<City> Cities
        {
            get
            {
                return this.GetRepository<City>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EfRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IGenericRepository<T>)this.repositories[typeOfRepository];
        }


        public IDbSet<T> Set<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public System.Data.Entity.Infrastructure.DbEntityEntry<T> Entry<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
