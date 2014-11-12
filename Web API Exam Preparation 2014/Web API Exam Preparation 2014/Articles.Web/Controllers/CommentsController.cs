namespace Articles.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using Microsoft.AspNet.Identity;

    using Articles.Data;
    using Articles.Models;
    using Articles.Web.DataModels;

    [Authorize]
    public class CommentsController : BaseApiController
    {
        public CommentsController(IArticlesData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult All(int id)
        {
            var article = this.data.Articles.Find(id);
            if (article == null)
            {
                return NotFound();
            }

            var comments = article.Comments.AsQueryable().Take(10)
                .Select(CommentDataModel.FromComment);

            return Ok(comments);
        }

        [HttpPost]
        public IHttpActionResult Create(int id, CommentDataModel model)
        {
            var newComment = new Comment
            {
                AuthorID = this.User.Identity.GetUserId(),
                Content = model.Content,
                DateCreated = DateTime.Now
            };

            this.data.Articles.Find(id).Comments.Add(newComment);
            this.data.SaveChanges();

            model.ID = newComment.ID;
            model.DateCreated = newComment.DateCreated;

            return Ok(model);
        }
    }
}