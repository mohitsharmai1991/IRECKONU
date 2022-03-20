using IRECKONU.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace IRECKONU.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;
        private readonly IFileOperationService _fileOperationService;
        private readonly string _folderPath = "./jsonfiles/";
        public ArticleController(IArticleService articleService, IFileOperationService fileOperationService)
        {
            _articleService = articleService;
            _fileOperationService = fileOperationService;
        }

        [HttpPost]
        [Route("Import")]
        public async Task<IActionResult> Import(IFormFile file)
        {
            if (!file.FileName.EndsWith(".csv"))
            {
                return BadRequest("Please upload .csv file.");
            }
            else
            {
                StringBuilder resultMessage = new StringBuilder();
                var records =  await _fileOperationService.ConvertCSVToArticle(file);
                if (await _articleService.BulkInsert(records))
                {
                    resultMessage.Append("CSVData added to database.");
                }
                else
                {
                    resultMessage.Append("Error in processing data to database.");
                }

                if(await _fileOperationService.SaveArticlesToJsonFile(records, _folderPath + file.FileName.Split(".csv")[0] + ".json"))
                {
                    resultMessage.AppendLine("\nJson file created.");
                }
                else
                {
                    resultMessage.AppendLine("\nError in json file creation.");
                }

                return Ok(resultMessage.ToString());
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_articleService.Get().Result);
        }
    }
}