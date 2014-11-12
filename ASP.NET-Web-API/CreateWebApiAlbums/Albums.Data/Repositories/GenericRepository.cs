namespace Albums.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private IAlbumsContext context;
        private readonly IDbSet<T> set;

        public GenericRepository(IAlbumsContext albumContext)
        {
            this.context = albumContext;
            this.set = context.Set<T>();
        }

        public IQueryable<T> All()
        {
            return this.context.Set<T>();
        }

        public System.Linq.IQueryable<T> Find(Expression<Func<T, bool>> conditions)
        {
            return this.All().Where(conditions);
        }

        public void Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public void Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
        }

        public void Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public void Detach(T entity)
        {
            this.ChangeState(entity, EntityState.Detached);
        }

        private void ChangeState(T entity, EntityState state)
        {
            this.context.Set<T>().Attach(entity);
            this.context.Entry(entity).State = state;
        }

        public void SaveChange()
        {
            this.context.SaveChanges();
        }
    }
}