using Microsoft.AspNetCore.Mvc;
using ServiceAPICall.Models;

namespace ServiceAPICall.Controllers
{
    public class JSONCallController : Controller
    {
        CommentDetails _commentObj = new CommentDetails();
        public IActionResult CommanDetails()
        {
            ViewBag.CommentObj = _commentObj.GetComments();
            return View();
        }
    }
}
