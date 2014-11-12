namespace Articles.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using Articles.Data;
    using Articles.Web.DataModels;

    public class TagsController : BaseApiController
    {
        public TagsController(IArticlesData data)
            :base(data)
        {
        }

        public IHttpActionResult Get()
        {
            var tags = this.data.Tags.All();
            return Ok(tags);
        }

        public IHttpActionResult Get(int id)
        {
            var tag = this.data.Tags.Find(id);
            if (tag == null)
            {
                return NotFound();
            }

            var articles = tag.Articles.AsQueryable()
                .Select(ArticleDataModel.FromArticle);

            return Ok(articles);
        }
    }
}
