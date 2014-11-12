namespace TravelWithMe.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TravelWithMe.Data.Repositories;
    using TravelWithMe.Models;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface ITravelWithMeData
    {
        IGenericRepository<TravelWithMeUser> Users { get; }

        IGenericRepository<Travel> Travels { get; }

        IGenericRepository<City> Cities { get; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();
    }
}
