using IRECKONU.BLL.Interfaces;
using IRECKONU.DAL.Interfaces;
using IRECKONU.Entities;

namespace IRECKONU.BLL
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<IEnumerable<Article>> Get()
        {
            return await _articleRepository.Get();
        }
        public async Task<bool> BulkInsert(IEnumerable<Article> articles)
        {
            return await _articleRepository.BulkInsert(articles);
        }
    }
}
