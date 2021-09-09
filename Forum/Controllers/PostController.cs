using Forum.Data;
using Forum.Data.ViewModels;
using Forum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PostController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public ActionResult GetById(int Id)
        {
            Post _post = _db.Posts.Where(i => i.Id == Id).FirstOrDefault();
            return PartialView("_Item", _post);
        }
        [HttpPost]
        public ActionResult Add(PostVM postVM)
        {
            if (!ModelState.IsValid)
            {
                Topic topic = _db.Topics.Include(i=>i.Posts).Where(i => i.Id == postVM.Id).FirstOrDefault();
                TopicVM topicVM = new TopicVM(topic, postVM);
                return View($"./../Topic/Index", topicVM);
            }
            Topic _topic = _db.Topics.Where(i => i.Id == postVM.Id).FirstOrDefault();
            _topic.Posts.Add(new Post()
            {
                Message = postVM.Message,
                CreatedDate = DateTime.Now,
                CreatorUserName = User.Identity.Name
            });
            _db.SaveChanges();
            return Redirect($"/Topic/Index/{postVM.Id}");
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Post _post = _db.Posts.Where(i => i.Id == Id).FirstOrDefault();
            if (_post == null)
            {
                return NotFound();
            }
            return PartialView("_Edit", _post);
        }
        [HttpPost]
        public IActionResult Edit(int Id, PostVM postVM)
        {
            Post _post = _db.Posts.Where(i => i.Id == Id).FirstOrDefault();
            if (_post == null)
            {
                return NotFound();
            }
            if(_post.CreatorUserName!=User.Identity.Name && User.Identity.Name != null)
            {
                return BadRequest();
            }
            _post.Message = postVM.Message;
            _post.EditDate = DateTime.Now;
            _db.SaveChanges();
            return PartialView("_Item", _post);
        }
    }
}
    