using IRECKONU.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRECKONU.Test.Unit.TestHelper
{
    public static class Helper
    {
        public static IFormFile GetFileMock(string contentType, string content)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(content);

            var file = new FormFile(
                baseStream: new MemoryStream(bytes),
                baseStreamOffset: 0,
                length: bytes.Length,
                name: "Data",
                fileName: "dummy.csv"
            )
            {
                Headers = new HeaderDictionary(),
                ContentType = contentType
            };

            return file;
        }

        public static List<Article> GetDummyArticles()
        {
            return new List<Article>(){new Article{
                                        Key="2800104",
                                        ArticleCode="2",
                                        ColorCode="broekey",
                                        Description="Gaastra",
                                        Price=8,
                                        DiscountPrice=0,
                                        DeliveredIn="1 - 3 werkdagen",
                                        ArticleCategory="baby",
                                        Size=104,
                                        Color="grijs"} };
        }
    }
}
