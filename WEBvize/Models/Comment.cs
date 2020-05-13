using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBvize.Models
{
    public class Comment
    {
        public int id { get; set; }
        public string comment { get; set; }
        public string CommentName { get; set; }
        public int Movieid { get; set; }

        public Comment(int id, string comment, string commentName, int movieid)
        {
            this.id = id;
            this.comment = comment;
            CommentName = commentName;
            Movieid = movieid;
        }

        public Comment()
        {
            
        }
    }
}