using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using DemoQASite;
using System.Collections.ObjectModel;

namespace DemoQAForm_Report
{
    [TestClass]
    public class UnitTest1 : Selenium_Base
    {
        public static ExtentTest Test;

        public static ExtentReports Extent;

        [OneTimeSetUp]
        public void ExtentStart()
        {
            Extent = new ExtentReports();

            var HtmlReporter = new ExtentHtmlReporter(@"E:\TestReportResults\DemoQAElementReport" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");

            Extent.AttachReporter(HtmlReporter);
        }

        [Test, Order(1)]
        public void FormTest()
        {
            Test = null;
            Test = Extent.CreateTest("Form").Info("FormTesting");
            try
            {
                string fname = "Laxmi";
                string lname = "Gorai";
                string email = "laxmi31@gmail.com";
                string phno = "9385174625";
                string cadd = "Durgapur";

                open("https://demoqa.com/automation-practice-form");
                wait(500);

                sendKeys(FindID("firstName"), fname);
                wait(2000);

                sendKeys(FindID("lastName"), lname);
                wait(2000);

                sendKeys(FindID("userEmail"), email);
                wait(2000);

                click(FindXPath("//label[@for='gender-radio-2']"));
                wait(2000);

                sendKeys(FindID("userNumber"), phno);
                wait(2000);

                scrollPage(0, 400);
                wait(2000);

                click(FindID("dateOfBirthInput"));
                wait(2000);

                click(FindClass("react-datepicker__month-select"));
                wait(2000);

                click(FindXPath("//*[text()='August']"));
                wait(2000);

                click(FindClass("react-datepicker__year-select"));
                wait(2000);

                click(FindXPath("//*[text()='2001']"));
                wait(2000);

                scrollPage(0, 200);
                wait(2000);

                click(FindXPath("//div[@aria-label='Choose Friday, August 31st, 2001']"));
                wait(2000);

                click(FindXPath("//div[@class='subjects-auto-complete__value-container subjects-auto-complete__value-container--is-multi css-1hwfws3']"));
                wait(2000);

                click(FindXPath("//label[@for='hobbies-checkbox-3']"));
                wait(2000);

                click(FindXPath("//label[@for='hobbies-checkbox-2']"));
                wait(2000);

                sendKeys(FindID("uploadPicture"), @"C:\picture\crp3 (2).jpeg");
                wait(2000);

                sendKeys(FindID("currentAddress"), cadd);
                wait(2000);

                sendKeys(FindID("userNumber"), Keys.Enter);
                wait(2000);

                Test.Log(Status.Pass, "Test Pass");
            }
            catch (Exception e)
            {
                Test.Log(Status.Fail, "Test Fail");

                throw;
            }
        }

        [OneTimeTearDown]
        public void CloseChrome()
        {
            Driver.Close();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            Extent.Flush();
        }
    }
}
