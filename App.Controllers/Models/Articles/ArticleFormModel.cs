
using System.ComponentModel.DataAnnotations;
using static App.Data.DataConstants.Article;

namespace App.Controllers.Models.Articles
{
    public class ArticleFormModel
    {
        [Required]
        [MaxLength(MaxTitleLength)]
        public string Title { get; set; }


        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }
    }
}
