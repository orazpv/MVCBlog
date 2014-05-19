using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBlog.Models;

namespace MvcBlog.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        public ActionResult Index(string Blogger, string BlogTitle, string Msg, string search)
        {
            //Here takes care of the search blog
            if (search !=null)
            {
                search = search.ToLower();
                List<Blog> filteredBlog = new List<Blog>();
                filteredBlog = BlogsAndComments.Instance.BlogList.Where(k => k.Blogger.ToLower().Contains(search) ||
                    k.BlogTitle.ToLower().Contains(search) || k.Msg.ToLower().Contains(search)).ToList();

               return View(filteredBlog);
            }
            DateTime blogtime = DateTime.Now;
            string blogid = Guid.NewGuid().ToString("N");

            //check for null value in the BlogList
            if (BlogsAndComments.Instance.BlogList.Count == 0)
            {
                BlogsAndComments.Instance.BlogList = new List<Blog>(){
                    new Blog(blogid,Blogger,BlogTitle,Msg,blogtime)
                };
            }
            else
            {
                BlogsAndComments.Instance.BlogList.Add(new Blog(blogid, Blogger, BlogTitle, Msg, blogtime));
            }

            return View(BlogsAndComments.Instance.BlogList);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(BlogsAndComments.Instance.BlogList);
        }

        public ActionResult ViewBlog(string id)
        {
            
            Blog Blog = BlogsAndComments.Instance.BlogList.Find(m=>m.BlogId == id);
            BlogsAndComments.Instance.Blog = Blog;

            return View(BlogsAndComments.Instance);
        }

        [HttpPost]
        public ActionResult ViewBlog(string id, string Blogger, string Msg){
            //Create the comment
            DateTime commentTime = DateTime.Now;
            string blogId = id;
            string commentId = Guid.NewGuid().ToString("N");
            if (BlogsAndComments.Instance.CommentList.Count == 0)
            {
                BlogsAndComments.Instance.CommentList = new List<Comment>(){
                    new Comment(commentId,blogId,Blogger,Msg,commentTime)
                };
            }
            else
            {
                BlogsAndComments.Instance.CommentList.Add(new Comment(commentId, blogId, Blogger, Msg, commentTime));
            }
            return View(BlogsAndComments.Instance);
        }

        public ActionResult Edit(string id)
        {
            Blog Blog = BlogsAndComments.Instance.BlogList.Find(m => m.BlogId == id);

            return View(Blog);
        }

        [HttpPost]
        public ActionResult Edit(string id, string Blogger, string BlogTitle, string Msg)
        {
            //Get the blog from the list
            Blog Blog = BlogsAndComments.Instance.BlogList.Find(m => m.BlogId == id);

            //get the index of the blog
            int index = BlogsAndComments.Instance.BlogList.IndexOf(Blog);

            //Use the index to update the blog in the list
            DateTime blogTime = DateTime.Now; //Get the current date
            BlogsAndComments.Instance.BlogList[index].Blogger = Blogger;
            BlogsAndComments.Instance.BlogList[index].BlogTitle = BlogTitle;
            BlogsAndComments.Instance.BlogList[index].Msg = Msg;
            BlogsAndComments.Instance.BlogList[index].BlogTime = blogTime;

            return Redirect("/");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            Blog Blog = BlogsAndComments.Instance.BlogList.Find(m => m.BlogId == id);

            return View(Blog);
        }

        [HttpPost]
        public ActionResult DeleteSubmit(string id)
        {
            Blog blog = BlogsAndComments.Instance.BlogList.Find(m => m.BlogId == id);

            //get the index of the blog
            int index = BlogsAndComments.Instance.BlogList.IndexOf(blog);

            //Remove the blog at the index
            BlogsAndComments.Instance.BlogList.RemoveAt(index);

            //Delete all the comments on this Blog
            BlogsAndComments.Instance.CommentList.RemoveAll(m => m.BlogId == id);

            return Redirect("/");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult EditComment(string id)
        {
            Comment comment = BlogsAndComments.Instance.CommentList.Find(x => x.CommentId == id);
            return View(comment);
        }

        [HttpPost]
        public ActionResult EditComment(string id, string Blogger, string Msg)
        {
            //Get the comment
            Comment comment = BlogsAndComments.Instance.CommentList.Find(x => x.CommentId == id);

            //Get the index of this comment in the comment list
            int index = BlogsAndComments.Instance.CommentList.IndexOf(comment);

            //get the blodId that will be used to redirect the page
            string blogId = BlogsAndComments.Instance.CommentList[index].BlogId;

            //Update this comment
            BlogsAndComments.Instance.CommentList[index].Blogger = Blogger;
            BlogsAndComments.Instance.CommentList[index].Msg = Msg;

            return Redirect("/Home/ViewBlog/" + blogId);
        }

        //Delete Comments
        public ActionResult DeleteComment(string id)
        {
            Comment comment = BlogsAndComments.Instance.CommentList.Find(m => m.CommentId == id);

            return View(comment);
        }

        //Submit the Comment to be deleted
        [HttpPost]
        public ActionResult DeleteCommentSubmit(string id)
        {
            Comment comment = BlogsAndComments.Instance.CommentList.Find(m => m.CommentId == id);

            //get the index of the Comment
            int index = BlogsAndComments.Instance.CommentList.IndexOf(comment);

            //get the blodId of the comment that will be used to redirect the page
            string blogId = BlogsAndComments.Instance.CommentList[index].BlogId;

            //Remove the Comment at the index
            BlogsAndComments.Instance.CommentList.RemoveAt(index);

            return Redirect("/Home/ViewBlog/" + blogId);
        }

    }
}