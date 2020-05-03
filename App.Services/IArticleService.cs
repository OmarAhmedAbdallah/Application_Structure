using App.Data.Models;
using App.Services.Models.Articles;
using App.Web.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    public interface IArticleService
    {
        public Task<IEnumerable<ArticleListingServiceModel>> All(int page);
        public Task<ArticlesDetailsServceMode> Details(int Id);

        public Task<int> Create(string title,string description,string author);

        public Task<bool> Edit(int id, string Title,string description);

        public Task<bool> Exists(int id, string authorId);

        public Task<bool> Delete(int id);


    }
}
