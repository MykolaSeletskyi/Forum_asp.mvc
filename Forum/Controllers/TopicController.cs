using Forum.Data;
using Forum.Data.ViewModels;
using Forum.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Forum.Controllers
{
    public class TopicController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TopicController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Topics()
        {
            return View(_db.Topics.OrderByDescending(i=>i.CreatedDate).ToList());
        }
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_Add", new AddTopicVM() {  });
        }
        [HttpPost]
        public IActionResult Add(AddTopicVM topic)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return PartialView("_Add", topic);
            }
            Topic _topic = new Topic()
            {
                Theme = topic.Theme,
                Description = topic.Description,
                CreatedDate = DateTime.Now,
                CreatorUserName = User.Identity?.Name
            };
            _db.Topics.Add(_topic);
            _db.SaveChanges();
            return Ok();
        }
        [HttpGet]
        public IActionResult Index(int Id)
        {
            Topic _topic = _db.Topics.Include(i=>i.Posts).Where(i=>i.Id==Id).FirstOrDefault();
            if (_topic == null)
            {
                return NotFound();
            }
            TopicsVM topicVM = new TopicsVM(_topic); 
            return View(topicVM);
        }
    }
}
