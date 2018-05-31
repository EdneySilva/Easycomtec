using Easy.Test.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Test.Cases
{

    using static Factories.CandidateFactory;
    using static Factories.AddressFactory;
    using static Factories.PhoneFactory;
    using Easy.Test.Model;
    using static Factories.SkillFactory;
    using Xunit;

    class ValidCandidateCase
    {
        public ValidCandidateCase OpenSite(IWebDriver webDriver, string url)
        {
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl(url);
            return this;
        }

        public ValidCandidateCase FillValidProfile(EasyAction action, ViewModelMapper mapper)
        {
            mapper.Map(Candidate(), action);
            mapper.Map(Address(), action);
            return this;
        }

        public ValidCandidateCase OpenContactTab(IWebDriver webDriver)
        {
            var contactLink = webDriver.FindElement(By.CssSelector("a[href='#contactData']"));
            contactLink.Click();
            return this;
        }

        public ValidCandidateCase FillValidPhone(IWebDriver webDriver, EasyAction action, ViewModelMapper mapper)
        {
            mapper.Map(Phone(), action);
            var btnAddPhone = webDriver.FindElement(By.CssSelector("button[ng-click='$ctrl.add();']"));
            btnAddPhone.Click();
            return this;
        }

        public ValidCandidateCase OpenSkillTab(IWebDriver webDriver)
        {
            var skillLink = webDriver.FindElement(By.CssSelector("a[href='#skillData']"));
            skillLink.Click();
            return this;
        }

        public ValidCandidateCase FillValidSkill(IWebDriver webDriver, EasyAction action, ViewModelMapper mapper)
        {
            mapper.Map(Skill(), action);
            var btnAddSkill = webDriver.FindElements(By.XPath("//select[contains(@id, 'Level')]/following-sibling::span//button"))[0];
            btnAddSkill.Click();
            return this;
        }

        public ValidCandidateCase SaveProfile(IWebDriver webDriver, EasyAction action)
        {
            var btnSave = webDriver.FindElement(By.XPath("//button[contains(@ng-click, 'controller.saveProfile')]"));
            return this;
        }
    }
}
