using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class PostComparer : IComparer<Post>
    {
        public int Compare(Post x, Post y)
        {
            return DateTime.Compare(y.CreatedDate, x.CreatedDate);
        }
    }
    public class Post
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public Nullable<DateTime> EditDate { get; set; }
        public string CreatorUserName { get; set; }
        public Topic Topic { get; set; }
    }
}
