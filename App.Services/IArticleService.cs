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
    }
}
