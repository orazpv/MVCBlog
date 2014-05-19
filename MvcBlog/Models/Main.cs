using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcBlog.Models
{
    public class Blog
    {
        public string BlogId { get; set; }
        public string Blogger { get; set; }
        public string BlogTitle { get; set; }
        public string Msg { get; set; }
        public DateTime BlogTime { get; set; }

        public Blog() { }

        public Blog(string blogid, string blogger, string blogtitle, string msg, DateTime blogtime)
        {
            this.BlogId = blogid;
            this.Blogger = blogger;
            this.BlogTitle = blogtitle;
            this.Msg = msg;
            this.BlogTime = blogtime;
        }
    }

    public class Comment
    {   
        /// <summary>
        /// 
        /// </summary>
        public string CommentId { get; set; }
        public string BlogId { get; set; }
        public string Blogger { get; set; }
        public string Msg { get; set; }
        public DateTime CommentTime { get; set; }

        public Comment() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commentid"></param>
        /// <param name="blogid"></param>
        /// <param name="blogger"></param>
        /// <param name="msg"></param>
        /// <param name="commenttime"></param>
        public Comment(string commentid, string blogid, string blogger, string msg, DateTime commenttime)
        {
            this.CommentId = commentid;
            this.BlogId = blogid;
            this.Blogger = blogger;
            this.Msg = msg;
            this.CommentTime = commenttime;
        }
    }

    public sealed class BlogsAndComments
    {
        public List<Blog> BlogList = new List<Blog>(); //List of Blogs
        public List<Comment> CommentList = new List<Comment>(); //List of Comments
        public Blog Blog = new Blog();
        public Comment Comment = new Comment();

        private static readonly BlogsAndComments instance = new BlogsAndComments();

        static BlogsAndComments(){

        }
        private BlogsAndComments(){

        }

        public static BlogsAndComments Instance {get{return instance;} }
    }
}