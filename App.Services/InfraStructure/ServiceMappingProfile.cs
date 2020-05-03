using App.Data.Models;
using App.Services.Models.Articles;
using AutoMapper;

namespace App.Services.InfraStructure
{
    class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            this.CreateMap<Article, ArticleListingServiceModel>()
                .ForMember(m => m.AuthorName, cfg => cfg.MapFrom(a => a.Author.UserName));

            this.CreateMap<Article, ArticlesDetailsServceMode>()
                .ForMember(m => m.Author, cfg => cfg.MapFrom(a => a.Author.UserName));
        }
    }
}
