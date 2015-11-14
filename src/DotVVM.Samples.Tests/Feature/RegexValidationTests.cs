﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Riganti.Utils.Testing.SeleniumCore;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace DotVVM.Samples.Tests.Feature
{
    [TestClass]
    public class RegexValidationTests : SeleniumTestBase
    {
        [TestMethod]
        public void Feature_RegexValidation()
        {
            RunInAllBrowsers(browser =>
            {
                browser.NavigateToUrl("FeatureSamples/Validation/RegexValidation");

                browser.ElementAt("input", 0).SendKeys("25");
                browser.Wait();
                browser.ElementAt("input[type=button]", 0).Click().Wait();

                browser.ElementAt("span", 0).CheckIfIsNotDisplayed();
                browser.ElementAt("span", 1).CheckIfInnerTextEquals("25");

                browser.ElementAt("input", 0).SendKeys("a");
                browser.Wait();
                browser.ElementAt("input[type=button]", 0).Click().Wait();

                browser.ElementAt("span", 0).CheckIfIsDisplayed();
                browser.ElementAt("span", 1).CheckIfInnerTextEquals("25");
            });
        }
    }
}