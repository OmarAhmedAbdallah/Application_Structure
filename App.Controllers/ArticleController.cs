using App.Controllers.Models.Articles;
using App.Data.InfraStructure;
using App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace App.Controllers
{
    class ArticleController : Controller
    {
        private readonly IArticleService articles;

        public ArticleController(IArticleService articles) => this.articles = articles;

        public async Task<IActionResult> Index(int page = 1) => Ok(await this.articles.All(page));

        [HttpGet]
        [Authorize]
        public IActionResult Create() => View();

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(ArticleFormModel model)
        {
            if (ModelState.IsValid)
            {
                var articleId = await this.articles.Create(
                    model.Title, model.Description, this.User.GetUserById());


                return RedirectToAction(nameof(Details), new { articleId });
            }
            return this.View(model);
        }


        public async Task<IActionResult> Details(int id)
        {
            var article = await this.articles.Details(id);

            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int Id)
        {
            if(! await this.articles.Exists(Id, this.User.GetUserById()))
            {
                return NotFound();
            }
            return View();

        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(int Id, ArticleFormModel article)
        {
            if (!await this.articles.Exists(Id, this.User.GetUserById()))
            {
                return NotFound();
            }

           

            if (this.ModelState.IsValid)
            {
                await this.articles.Edit(Id, article.Title, article.Description);

               
                return this.RedirectToAction("Article edited successfully and is waiting for approval!",new { Id });
            }

            return this.View(article);
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete(int Id)
        {
            if (!await this.articles.Exists(Id, this.User.GetUserById()))
            {
                return NotFound();
            }
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ConfirmDelete(int Id)
        {
            if (!await this.articles.Exists(Id, this.User.GetUserById()))
            {
                return NotFound();
            }
            await this.articles.Delete(Id);

            return Redirect(nameof(Index));
        }
    }
}
