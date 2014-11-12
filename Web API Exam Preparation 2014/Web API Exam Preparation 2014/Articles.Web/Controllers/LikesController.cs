namespace Articles.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using Articles.Data;

    public class LikesController : BaseApiController
    {
        public LikesController(IArticlesData data)
            :base(data)
        {
        }

        [HttpPost]
        public IHttpActionResult Like()
        {

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Dislike()
        {


            return Ok();
        }
    }
}
