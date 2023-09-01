using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab.EF.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Data.Entity;
using Lab.EF.Entities.Entities;
using Lab.EF.Data.Context;

namespace Lab.EF.Logic.Services.Tests
{
    [TestClass()]
    public class CategoriesServiceTests
    {
        [TestMethod]
        public void CategoriesServiceTestMoq()
        {
            var mockSet = new Mock<DbSet<Categories>>();

            var mockContext = new Mock<NorthwindContext>();
            mockContext.Setup(m => m.Categories).Returns(mockSet.Object);

            CategoriesService categoriesService = new CategoriesService(mockContext.Object);

            categoriesService.Add(new Categories
            {
                CategoryID = 9,
                CategoryName = "TestTest",
                Description = "Description Test"
            });

            mockSet.Verify(m => m.Add(It.IsAny<Categories>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}