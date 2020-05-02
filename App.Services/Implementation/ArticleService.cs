using App.Data.Models;
using App.Services.Models.Articles;
using App.Web.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services.Implementation
{
    public class ArticleService : IArticleService
    {
        private const int PageSize = 10;

        private readonly ApplicationDbContext data;

        public ArticleService(ApplicationDbContext data) => this.data = data;

        public async Task<int> Create(string title, string description, string autherId)
        {
            var article = new Article
            {
                Title = title,
                Description = description,
                AuthorId = autherId 
            };

            this.data.Add(article);
            await data.SaveChangesAsync();
            return article.Id;
        }

        public async Task<IEnumerable<ArticleListingServiceModel>> All(int page)
            => await this.data
                    .Articles
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize)
                    .Select(a => new ArticleListingServiceModel
                    {
                        Id = a.Id,
                        Title = a.Title,
                        AuthorName = a.Author.UserName
                    })
                    .ToListAsync();
    }
}
