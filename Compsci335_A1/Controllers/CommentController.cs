using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Compsci335_A1.Dtos;
using Compsci335_A1.Models;
using Compsci335_A1.Data;
using System.Net;

namespace Compsci335_A1.Controllers
{
    [Route("api")]
    [ApiController]
    public class CommentController : Controller
    {
        private readonly IWebApiRepo _repository;

        public CommentController(IWebApiRepo repository)
        {
            _repository = repository;
        }

        // POST /api/WriteComment 
        [HttpPost("WriteComment")]
        public ActionResult addComment(CommentInDto comment)
        {
            string time = DateTime.Now.ToString("hh:mm:ss");
            string ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Comments c = new Comments { Comment = comment.Comment, Name = comment.Name, Time = time, IP = ip};
            Comments addedComment = _repository.addComment(c);
            return Content(addedComment.Comment);
        }


        // GET /api/GetComments
        [HttpGet("GetComments")]
        public ContentResult getComments()
        {
            IEnumerable<Comments> comments = _repository.getAllComments();
            string comment = "";
            if(comments.Count() <= 5)
            {
                for (int i = comments.Count()-1; i > -1; i--)
                {
                    comment += $"<html><p>{comments.ElementAt(i).Comment} &mdash; {comments.ElementAt(i).Name}</p></html>";
                }
            }
            else
            {
                for(int i = comments.Count() - 1; i > comments.Count() - 6; i--)
                {
                    comment += $"<html><p>{comments.ElementAt(i).Comment} &mdash; {comments.ElementAt(i).Name}</p></html>";
                }
            }

            ContentResult c = new ContentResult
            {
                Content = comment,
                ContentType = "text/html",
                StatusCode = (int)HttpStatusCode.OK,
            };
            return c;
        }

    }
}
