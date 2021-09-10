using FluentValidation;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Data.ViewModels
{
    public class TopicsVM
    {
        public TopicsVM(Topic _Topic, PostVM _PostVM)
        {
            Topic = _Topic;
            PostVM = _PostVM;
        }
        public TopicsVM(Topic _Topic)
        {
            Topic = _Topic;
            PostVM = new PostVM() { Id=_Topic.Id };
        }
        public Topic Topic { get;set;}
        public PostVM PostVM { get; set; }
    }
    public class AddTopicVM
    {
        public string Theme { get; set; }
        public string Description { get; set; }
    }
    public class AddTopicVMValidator : AbstractValidator<AddTopicVM>
    {
        public AddTopicVMValidator()
        {
            RuleFor(x => x.Theme).Length(5,50);
            RuleFor(x => x.Description).Length(5, 250).WithMessage("Length description between 5 and 250 symbols");
        }
    }
}
