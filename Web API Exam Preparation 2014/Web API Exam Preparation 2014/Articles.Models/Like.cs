using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Models
{
    public class Like
    {
        public int ID { get; set; }

        public string UserID { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int ArticleID { get; set; }

        public virtual Article Article { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
