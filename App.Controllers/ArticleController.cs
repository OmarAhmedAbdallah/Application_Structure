using App.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Controllers
{
    class ArticleController : Controller
    {
        private readonly IArticleService articles;

        public ArticleController(IArticleService articles) => this.articles = articles;

        public async Task<IActionResult> Index() => this.Ok(await this.articles.All(1));
    }
}
