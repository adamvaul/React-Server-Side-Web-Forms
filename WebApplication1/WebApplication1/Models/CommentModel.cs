using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CommentModel
    {
        public string Author { get; set; }
        public string Text { get; set; }

        public object Detail { 
            get {
                return new { id = 0, text = "hello" };
            } 
        }
    }

}