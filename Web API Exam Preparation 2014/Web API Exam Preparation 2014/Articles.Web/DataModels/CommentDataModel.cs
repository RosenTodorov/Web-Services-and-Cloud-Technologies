namespace Articles.Web.DataModels
{
    using Articles.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    public class CommentDataModel
    {
        public static Expression<Func<Comment, CommentDataModel>> FromComment
        {
            get
            {
                return c => new CommentDataModel
                {
                    ID = c.ID,
                    Content = c.Content,
                    DateCreated = c.DateCreated,
                    AuthorName = c.Author.UserName
                };
            }
        }

        public int ID { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public string AuthorName { get; set; }
    }
}