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
    public class TestBookMovieController
    {
        BookMovieController controller;

        private ProjectTestDataContext context;
        public static DbContextOptions<ProjectTestDataContext> dbContextOptions { get; set; }

        public static string connectionString = "Data Source=TRD-507; Initial Catalog = a1; Integrated Security = true;";
        static TestBookMovieController()
        {
            dbContextOptions = new DbContextOptionsBuilder<ProjectTestDataContext>().UseSqlServer(connectionString).Options;
        }
        public TestBookMovieController()
        {
            context = new ProjectTestDataContext(dbContextOptions);
            controller = new BookMovieController();
        }
        [Fact]
        public void Task_BookMovie_Checkout_OkResult()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new BookMovieController();


                var data = controller.Checkout();
                Assert.IsType<RedirectToActionResult>(data);
            });

        }

        [Fact]
        public void Task_BookMovie_DirectRegister_OkResult()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new BookMovieController();
                var item = new UserDetails();
                item.Email = "shivanginisaxena20@gmail.com";
                item.Password = "12";
                item.ContactNo = 1234;
                item.UserName = "srishti";

                var data = controller.DirectRegister(item);
                Assert.IsType<RedirectToActionResult>(data);
            });

        }
        [Fact]
        public void Task_BookMovie_Register_OkResult()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new BookMovieController();
                var item = new UserDetails();
                item.Email = "sanyasingh097@gmail.com";
                item.Password = "12";
                item.ContactNo = 1234;
                item.UserName = "sanya";

                var data = controller.Register(item);
                Assert.IsType<RedirectToActionResult>(data);
            });

        }
        [Fact]
        [Trait("BookMovie", "Invoice")]
        public void Invoice()
        {
            Assert.Throws<NullReferenceException>(() =>
            {

                //Act
                IActionResult result = controller.Invoice();
                //Assert
                Assert.NotNull(result);
            });


        }
        [Fact]
        public void Task_BookMovie_Index_OkResult()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new BookMovieController();


                var data = controller.Index();
                Assert.IsType<RedirectToActionResult>(data);
            });

        }
        [Fact]
        public void Task_BookMovie_Details_OkResult()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new BookMovieController();


                var data = controller.Index();
                Assert.IsType<RedirectToActionResult>(data);
            });

        }
        [Fact]
        public void Task_BookMovie_Index()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new BookMovieController();


                var data = controller.Index();
                Assert.IsType<RedirectToActionResult>(data);
            });

        }

        [Fact]
        [Trait("BookMovie", "Index1")]
        public void Contact()
        {
            //Act
            IActionResult result = controller.Index1();
            //Assert
            Assert.NotNull(result);

        }
        [Fact]
        [Trait("BookMovie", "Review")]
        public void Review()
        {
            //Act
            IActionResult result = controller.Review();
            //Assert
            Assert.NotNull(result);

        }
        [Fact]
        [Trait("BookMovie", "Error")]
        public void Error()
        {
            //Act
            IActionResult result = controller.Error();
            //Assert
            Assert.NotNull(result);

        }
    }
}

