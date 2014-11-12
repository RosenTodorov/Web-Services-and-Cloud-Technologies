namespace Articles.Web.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    using Articles.Models;

    public class ArticleDataModel
    {
        public ArticleDataModel()
        {
            this.Tags = new HashSet<string>();
        }

        public static Expression<Func<Article, ArticleDataModel>> FromArticle
        {
            get
            {
                return a => new ArticleDataModel
                {
                    ID = a.ID,
                    Title = a.Title,
                    Content = a.Content,
                    Category = a.Caterogy.Name,
                    DateCreated = a.DateCreated,
                    Tags = a.Tags.Select(t => t.Name)
                };
            }
        }

        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        public string Content { get; set; }

        [Required]
        public string Category { get; set; }

        public DateTime DateCreated { get; set; }

        public IEnumerable<string> Tags { get; set; }
    }
}