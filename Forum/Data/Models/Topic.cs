using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Principal;
namespace Forum.Models
{
    public class Topic
    {
        public Topic()
        {
            Posts = new SortedSet<Post>(new PostComparer());
        }
        public int Id {  get; set; }
        public string Theme {  get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatorUserName {  get; set;}
        public SortedSet<Post> Posts {  get; set; }
    }
}
