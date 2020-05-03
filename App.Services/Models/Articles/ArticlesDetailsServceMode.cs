using System;
using System.Collections.Generic;
using System.Text;

namespace App.Services.Models.Articles
{
    public class ArticlesDetailsServceMode
    {
        public int Id { get; set; }

        public string Title { get; set; }
     
        public string Description { get; set; }

        public DateTime? PublishedOn { get; set; }

        public string Author { get; set; }
    }
}
