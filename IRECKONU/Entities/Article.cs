using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace IRECKONU.Entities
{
    public class Article
    {
        [Key]
        public string Key { get; set; }

        [Name("ArtikelCode")]
        public string ArticleCode { get; set; }

        public string ColorCode { get; set; }

        public string Description { get; set; }

        public long Price { get; set; }

        public long DiscountPrice { get; set; }

        public string DeliveredIn { get; set; }

        [Name("Q1")]
        public string ArticleCategory { get; set; }

        public long Size { get; set; }

        public string Color { get; set; }
    }
}