using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UserProject1.Controllers;
using UserProject1.Models;
using Xunit;

namespace XUserSideTestingProject
{
    public class TestHomeController
    {
        HomeController controller;

        private ProjectTestDataContext context;
        public static DbContextOptions<ProjectTestDataContext> dbContextOptions { get; set; }

        public static string connectionString = "Data Source=TRD-507; Initial Catalog = a1; Integrated Security = true;";
        static TestHomeController()
        {
            dbContextOptions = new DbContextOptionsBuilder<ProjectTestDataContext>().UseSqlServer(connectionString).Options;
        }
        public TestHomeController()
        {
            context = new ProjectTestDataContext(dbContextOptions);
            controller = new HomeController();
        }
        [Fact]
        [Trait("Home", "Index1")]
        public void Test1()
        {
            //Act
            IActionResult result = controller.Index1();
            //Assert
            Assert.NotNull(result);

        }
        [Fact]
        [Trait("Home", "About")]
        public void About()
        {
            //Act
            IActionResult result = controller.About();
            //Assert
            Assert.NotNull(result);

        }
        [Fact]
        [Trait("Home", "Contact")]
        public void Contact()
        {
            //Act
            IActionResult result = controller.Contact();
            //Assert
            Assert.NotNull(result);

        }
        [Fact]
        [Trait("Home", "Upcoming")]
        public void Upcoming()
        {
            //Act
            IActionResult result = controller.Upcoming();
            //Assert
            Assert.NotNull(result);

        }
        [Fact]
        [Trait("Home", "Movies")]
        public void Movies()
        {
            //Act
            IActionResult result = controller.Movies();
            //Assert
            Assert.NotNull(result);

        }
        [Fact]
        [Trait("Home", "Index")]
        public void Index()
        {
            //Act
            IActionResult result = controller.Index();
            //Assert
            Assert.NotNull(result);

        }
       

    }
}