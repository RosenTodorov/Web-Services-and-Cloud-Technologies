namespace Articles.WCF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;

    using Articles.Data;
    using Articles.Models;
    using System.ServiceModel.Activation;
    using System.ServiceModel.Web;

    [AspNetCompatibilityRequirements(RequirementsMode
    = AspNetCompatibilityRequirementsMode.Allowed)]    
    public class AlertService : IAlertService
    {
        private IAlertsData data;

        public AlertService()
        {
            this.data = new AlertsData(ArticlesDbContext.Create());
        }


        public ICollection<Alert> Get()
        {
            var alerts = this.data.Alerts.All().ToList();
            return alerts;
        }
    }
}
