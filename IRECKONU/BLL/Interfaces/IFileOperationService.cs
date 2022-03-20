using IRECKONU.Entities;

namespace IRECKONU.BLL.Interfaces
{
    public interface IFileOperationService
    {
        Task<IEnumerable<Article>> ConvertCSVToArticle(IFormFile file);
        Task<bool> SaveArticlesToJsonFile(IEnumerable<Article> articles,string filePath);
    }
}
