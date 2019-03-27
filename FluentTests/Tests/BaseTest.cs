using FluentTests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace FluentTests.Tests
{
    public class BaseTest
    {
        private readonly IWebDriver driver;
        public CanvasPage canvasPage;

        public BaseTest()
        {
            driver = new ChromeDriver(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName);
            canvasPage = new CanvasPage(driver);
        }

        [SetUp]
        public void SetUp()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://www.newart.ru/htm/flash/risovalka_9.php");

            driver.SwitchTo().Frame(1);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

    }
}
