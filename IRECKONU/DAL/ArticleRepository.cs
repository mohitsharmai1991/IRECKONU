using IRECKONU.Context;
using IRECKONU.DAL.Interfaces;
using IRECKONU.Entities;
using EFCore.BulkExtensions;

namespace IRECKONU.DAL
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly IreckonuDbContext _dbContext;

        public ArticleRepository(IreckonuDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Article>> Get()
        {
            return _dbContext.Articles;
        }
        public async Task<bool> BulkInsert(IEnumerable<Article> articles)
        {
            try
            {
                _dbContext.BulkInsertOrUpdate(articles.ToList());
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
