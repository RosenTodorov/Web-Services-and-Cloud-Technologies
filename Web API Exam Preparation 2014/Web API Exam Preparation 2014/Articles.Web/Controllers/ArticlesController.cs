namespace Articles.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using Microsoft.AspNet.Identity;

    using Articles.Data;
    using Articles.Models;
    using Articles.Web.DataModels;

    public class ArticlesController : BaseApiController
    {
        public ArticlesController(IArticlesData data)
            : base(data)
        {
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Create(ArticleDataModel model)
        {
            var currentUserID = this.User.Identity.GetUserId();

            var category = GetCategory(model);
            var tags = GetTags(model);

            var article = new Article
            {
                AuthorID = currentUserID,
                DateCreated = DateTime.Now,
                Title = model.Title,
                Content = model.Content,
                CategoryID = category.ID,
                Tags = tags,
            };

            this.data.Articles.Add(article);
            this.data.SaveChanges();

            model.ID = article.ID;
            model.DateCreated = article.DateCreated;
            model.Tags = article.Tags.Select(t => t.Name);

            return Ok(model);
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return this.All(null, 0);
        }

        [HttpGet]
        public IHttpActionResult All(int page)
        {
            return this.All(null, page);
        }

        [HttpGet]
        public IHttpActionResult All(string category)
        {
            return this.All(category, 0);
        }

        [HttpGet]
        public IHttpActionResult All(string category, int page)
        {
            var articles = this.GetAllOrderedByDate()
                .Where(a => category != null ? a.Caterogy.Name.Equals(category, StringComparison.InvariantCultureIgnoreCase) : true)
                .Skip(10 * page)
                .Take(10)
                .Select(ArticleDataModel.FromArticle).ToList();

            return Ok(articles);
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult Details(int id)
        {
            var article = this.data.Articles.Find(id);
            if (article == null)
            {
                return NotFound();
            }

            var articleModel = new ArticleDetailsDataModel(article);
            return Ok(articleModel);
        }

        private IQueryable<Article> GetAllOrderedByDate()
        {
            return this.data.Articles.All()
                .OrderBy(a => a.DateCreated);
        }

        private Category GetCategory(ArticleDataModel model)
        {
            var category = this.data.Categories.All()
                .FirstOrDefault(c => c.Name == model.Category);

            if (category == null)
            {
                category = new Category { Name = model.Category };
                this.data.Categories.Add(category);
            }
            return category;
        }

        private HashSet<Tag> GetTags(ArticleDataModel model)
        {
            HashSet<Tag> tags = new HashSet<Tag>();
            var newTagNames = model.Tags.ToList();
            var tagsFromTitle = model.Title.Split(' ');
            newTagNames.AddRange(tagsFromTitle);

            foreach (var newTagName in newTagNames)
            {
                var tag = this.data.Tags.All()
                    .FirstOrDefault(t => t.Name == newTagName);
                if (tag == null)
                {
                    tag = new Tag { Name = newTagName };
                    this.data.Tags.Add(tag);
                }

                tags.Add(tag);
            }
            return tags;
        }
    }
}