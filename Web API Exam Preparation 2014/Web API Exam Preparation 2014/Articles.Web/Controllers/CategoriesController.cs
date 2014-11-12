namespace Articles.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using Articles.Data;
using System.Web.Http;
    using Articles.Web.DataModels;

    public class CategoriesController : BaseApiController
    {
        public CategoriesController(IArticlesData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var categories = this.data.Categories.All().Select(c => c.Name);
            return Ok(categories);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var category = this.data.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            var articles = category.Articles.AsQueryable()
                .Select(ArticleDataModel.FromArticle);

            return Ok(articles);
        }
    }
}