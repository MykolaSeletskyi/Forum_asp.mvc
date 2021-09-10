using FluentValidation;
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
    public class PostValidator : AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Message).Length(5, 1000).WithMessage("Length message between 5 and 1000 symbols");
            RuleFor(x => x.CreatorUserName).NotEmpty();
        }
    }
}
