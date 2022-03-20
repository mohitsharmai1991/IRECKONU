using IRECKONU.BLL;
using IRECKONU.BLL.Interfaces;
using IRECKONU.Test.Unit.TestHelper;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Linq;

namespace IRECKONU.Test.Unit
{
    public class Tests
    {
        private IFileOperationService FileOperationService { get; set; }

        private readonly string dummyCSV = @"Key,ArtikelCode,ColorCode,Description,Price,DiscountPrice,DeliveredIn,Q1,Size,Color
2800104, 2, broekey, Gaastra, 8, 0, 1 - 3 werkdagen, baby, 104, grijs";
        private IServiceProvider ServicesProvider { get; set; }
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IFileOperationService, FileOperationService>();
        }

        [SetUp]
        public void Setup()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            ServicesProvider = services.BuildServiceProvider();

            // Use DI to get instances of IFileOperationService
            FileOperationService = ServicesProvider.GetService<IFileOperationService>();
        }

        [Test]
        public void Get_ShouldReturnArticleList_WhenCSVFileIsProvided()
        {
            var result = FileOperationService.ConvertCSVToArticle(Helper.GetFileMock("text/csv", dummyCSV)).Result.ToList();

            var articles = Helper.GetDummyArticles();

            // Check
            Assert.AreEqual(articles.Count, result.Count);
        }
    }
}