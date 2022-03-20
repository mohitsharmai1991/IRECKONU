using IRECKONU.Entities;

namespace IRECKONU.DAL.Interfaces
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> Get();
        Task<bool> BulkInsert(IEnumerable<Article> articles);
    }
}
