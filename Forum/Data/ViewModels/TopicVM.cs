using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Data.ViewModels
{
    public class TopicVM
    {
        public TopicVM(Topic _Topic, PostVM _PostVM)
        {
            Topic = _Topic;
            PostVM = _PostVM;
        }
        public TopicVM(Topic _Topic)
        {
            Topic = _Topic;
            PostVM = new PostVM() { Id=_Topic.Id };
        }
        public Topic Topic { get;set;}
        public PostVM PostVM { get; set; }
    }
}
