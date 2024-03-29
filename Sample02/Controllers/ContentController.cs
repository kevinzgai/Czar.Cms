using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{

    public class ContentController : Controller
    {
        private readonly Content contents;
         public ContentController(IOptions<Content> option)
        {
            contents = option.Value;
        }
        public IActionResult Index()
        {
            // var contents = new List<Content>();
            // for (int i = 0; i < 11; i++)
            // {
            //     contents.Add(new Content
            //     {
            //         Id = i,
            //         title = $"{i}的标题",
            //         status = 1,
            //         content = $"{i}的内容",
            //         add_time = DateTime.Now.AddDays(-1)
            //     });
            // }
            return View(new ContentViewModel { Contents = new List<Content>{contents} });
        }
    }
}