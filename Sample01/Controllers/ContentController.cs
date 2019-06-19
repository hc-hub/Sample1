using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using Sample01.Models;

namespace Sample01.Controllers
{
    /// <summary>
    /// 2019.6.18
    /// hc
    /// Content控制器
    /// </summary>
    public class ContentController : Controller
    {
        private readonly Content contents;

        public ContentController(IOptions<Content> option)
        {
            contents = option.Value;
        }

        /// <summary>
        /// 首页显示
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            //var contents = new List<Content>();
            //for (int i = 0; i < 11; i++)
            //{
            //    contents.Add(new Content { Id = i, Title = $"标题{i}", content = $"内容{i}", states = 1, add_time = DateTime.Now.AddDays(-i) });
            //}
            return View(new ContentViewModel { Contents = new List<Content> { contents } });
        }
    }
}