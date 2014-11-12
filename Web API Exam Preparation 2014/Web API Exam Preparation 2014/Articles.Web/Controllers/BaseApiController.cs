namespace Articles.Web.Controllers
{
    using Articles.Data;

    using System;
    using System.Web;
    using System.Web.Http;

    public class BaseApiController : ApiController
    {
        protected IArticlesData data;

        public BaseApiController(IArticlesData data)
        {
            this.data = data;
        }
    }
}