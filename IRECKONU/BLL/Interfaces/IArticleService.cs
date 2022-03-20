using IRECKONU.Entities;

namespace IRECKONU.BLL.Interfaces
{
    public interface IArticleService
    {
        Task<IEnumerable<Article>> Get();
        Task<bool> BulkInsert(IEnumerable<Article> articles);
    }
}
