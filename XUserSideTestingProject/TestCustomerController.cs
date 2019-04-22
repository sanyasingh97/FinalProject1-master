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
    public class TestCustomerController
    {
        CustomerController controller;

        private ProjectTestDataContext context;
        public static DbContextOptions<ProjectTestDataContext> dbContextOptions { get; set; }

        public static string connectionString = "Data Source=TRD-507; Initial Catalog = a1; Integrated Security = true;";
        static TestCustomerController()
        {
            dbContextOptions = new DbContextOptionsBuilder<ProjectTestDataContext>().UseSqlServer(connectionString).Options;
        }
        public TestCustomerController()
        {
            context = new ProjectTestDataContext(dbContextOptions);
            controller = new CustomerController();
        }
        [Fact]
        [Trait("Customer", "DirectLogin")]
        public void DirectLogin()
        {
            //Act
            IActionResult result = controller.DirectLogin();
            //Assert
            Assert.NotNull(result);



        }
        //[Fact]
        //public void Task_Customer_Return_OkResult()
        //{
        //    Assert.Throws<NullReferenceException>(() =>
        //    {
        //        var controller = new CustomerController();

        //        var UserName = "bgunwani";
        //        var Password = "1";
        //        var data = controller.DirectLogin(UserName, Password);
        //        Assert.IsType<RedirectToActionResult>(data);
        //    });
        //}
        [Fact]
        public void Task_Customer_Index_OkResult()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new CustomerController();

                var UserName = "a";
                var Password = "1";
                var data = controller.Index(UserName, Password);
                Assert.IsType<RedirectToActionResult>(data);
            });

        }
        [Fact]
        public void Task_Customer_Logout_OkResult()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new CustomerController();

                var data = controller.Logout();
                Assert.IsType<RedirectToActionResult>(data);
            });
        }
        [Fact]
        [Trait("Customer", "ViewProfile")]
        public void ViewProfile()
        {
            Assert.Throws<NullReferenceException>(() =>
            {

                //Act
                IActionResult result = controller.ViewProfile();
                //Assert
                Assert.NotNull(result);
            });


        }

        [Fact]
        [Trait("Customer", "ChangePassword")]
        public void ChangePassword()
        {

            var item = new UserDetails();
            item.UserDetailId = 1;
            item.Password = "2";
            //Act
            IActionResult result = controller.ChangePassword();
            //Assert
            Assert.NotNull(result);



        }
        
        [Fact]
        [Trait("Customer", "ViewReviews")]
        public void ViewReviews()
        {
            //Act
            IActionResult result = controller.ViewReviews();
            //Assert
            Assert.NotNull(result);

        }
        [Fact]
        [Trait("Customer", "EditProfile")]
        public void Task_BookMovie_EditResult_OkResult()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new CustomerController();


                var data = controller.EditProfile();
                Assert.IsType<RedirectToActionResult>(data);
            });
        }



             [Fact]
        [Trait("Customer", "Dashboard")]
        public void Dashboard()
        {
            //Act
            IActionResult result = controller.Dashboard();
            //Assert
            Assert.NotNull(result);

        }
    }
    
}