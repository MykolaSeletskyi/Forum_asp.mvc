using FluentValidation;
using Forum.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Forum.Data.ViewModels
{
    public class PostVM
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public PostVM()
        {

        }
        public PostVM(Post post)
        {
            Id = post.Id;
            Message = post.Message;
        }
    }
    public class PostVMValidator : AbstractValidator<PostVM>
    {
        public PostVMValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Message).Length(5, 1000).WithMessage("Length message between 5 and 1000 symbols");
        }
    }
}
