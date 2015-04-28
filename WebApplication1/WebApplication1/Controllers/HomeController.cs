using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : ApiController
    {

        public dynamic Get()
        {
            IList<CommentModel> _comments = new List<CommentModel>();

            for (int i = 1; i <= 5; i++)
            {
                _comments.Add(new CommentModel { Author = "Person" + i, Text = "This is a comment" });
            }

            return _comments;

            //return Ok("Hello, Web API");
        }

        [HttpPost]
        public dynamic AddComment(dynamic comment)
        {
            string json = comment.ToString();
            CommentModel c = JObject.Parse(json).ToObject<CommentModel>();

            IList<CommentModel> _comments = Get();

            _comments.Add(c);

            return _comments;

            //return Ok("Hello, Web API");
        }
    }
}
