﻿using App.Data.Models;
using App.Services.Models.Articles;
using App.Web.Data;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services.Implementation
{
    public class ArticleService : IArticleService
    {
        private const int PageSize = 10;
        private readonly IMapper mapper;

        private readonly ApplicationDbContext data;

        public ArticleService(ApplicationDbContext data, IMapper mapper) {
            this.data = data;
            this.mapper = mapper;
        }
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
                    .ProjectTo<ArticleListingServiceModel>(this.mapper.ConfigurationProvider)
                    .ToListAsync();


        public async Task<ArticlesDetailsServceMode> Details(int Id)
                =>await this.data.Articles
                                .Where(a => a.Id == Id)
                                .ProjectTo<ArticlesDetailsServceMode>(this.mapper.ConfigurationProvider)
                                .FirstOrDefaultAsync();

        

        public async Task<bool> Edit(int id, string title, string description)
        {
            var article = await this.data.Articles.FindAsync(id);

            if (article == null)
            {
                return false; 
            }

            
            article.Title = title;
            article.Description = description;

            await this.data.SaveChangesAsync();

            return false;
        }

        public Task<bool> Exists(int id, string authorId)
        {
            return this.data.Articles.AnyAsync(a => a.Id == id && a.AuthorId == authorId);
        }

        public async Task<bool> Delete(int id)
        {
            var article = this.data.Articles.FindAsync(id);

            if(article == null)
            {
                return false;
            }

            this.data.Remove(article);

            await this.data.SaveChangesAsync();

            return true;
        }
    }
}
