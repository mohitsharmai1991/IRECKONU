using CsvHelper;
using IRECKONU.BLL.Interfaces;
using IRECKONU.Entities;
using System.Globalization;
using System.Text.Json;

namespace IRECKONU.BLL
{
    public class FileOperationService : IFileOperationService
    {
        public async Task<IEnumerable<Article>> ConvertCSVToArticle(IFormFile file)
        {
            try
            {
                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        return csv.GetRecords<Article>().ToList();
                    }
                }
            }
            catch
            {
                return Enumerable.Empty<Article>();
            }
        }

        public async Task<bool> SaveArticlesToJsonFile(IEnumerable<Article> articles, string filePath)
        {
            try
            {
                using (var fileData = File.Create(filePath))
                {
                    JsonSerializer.SerializeAsync(fileData, articles);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
