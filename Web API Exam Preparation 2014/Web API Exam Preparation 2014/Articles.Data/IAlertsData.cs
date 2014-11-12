namespace Articles.Data
{
    using Articles.Data.Repositories;
    using Articles.Models;

    public interface IAlertsData
    {
        IRepository<Alert> Alerts { get; }

        int SaveChanges();
    }
}
