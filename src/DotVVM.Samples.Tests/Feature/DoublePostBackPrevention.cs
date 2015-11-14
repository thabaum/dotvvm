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
    public class DoublePostBackPreventionTests : SeleniumTestBase
    {
        [TestMethod]
        public void Feature_DoublePostBackPrevention()
        {
            RunInAllBrowsers(browser =>
            {
                browser.NavigateToUrl("FeatureSamples/DoublePostBackPrevention/DoublePostBackPrevention");

                // try the long action interrupted by the short one
                browser.ElementAt("input[type=button]", 0).Click().Wait(2000);
                browser.ElementAt("input[type=button]", 1).Click().Wait();

                // the postback index should be 1 now (because of short action)
                browser.ElementAt("span", 0).CheckIfInnerTextEquals("1");
                browser.ElementAt("span", 1).CheckIfInnerTextEquals("short");
                
                // the result of the long action should be canceled, the counter shouldn't increase
                browser.Wait(10000);
                browser.ElementAt("span", 0).CheckIfInnerTextEquals("1");
                browser.ElementAt("span", 1).CheckIfInnerTextEquals("short");
                browser.Wait();

                // test update progress control
                browser.CheckIfIsNotDisplayed("div[data-bind='dotvvmUpdateProgressVisible: true']");
                browser.ElementAt("input[type=button]", 2).Click().Wait();
                browser.CheckIfIsDisplayed("div[data-bind='dotvvmUpdateProgressVisible: true']");
                browser.Wait(6000);
                browser.CheckIfIsNotDisplayed("div[data-bind='dotvvmUpdateProgressVisible: true']");
            });
        }
    }
}