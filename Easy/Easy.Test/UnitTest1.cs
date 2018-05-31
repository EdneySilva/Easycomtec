using Easy.Test.Extensions;
using Easy.Test.Model;
using Easy.Test.Model.WebDriverModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using Xunit;

namespace Easy.Test
{
    public class UnitTest1
    {
        [Fact]
        public void When_run_a_valid_candidate_case_save_with_success()
        {
            IWebDriver webDriver = new ChromeDriver(@"C:\Users\a288461\Downloads\chromedriver_win32\");
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            EasyAction commands = new EasyAction(webDriver);
            ViewModelMapper mapper = new ViewModelMapper(webDriver);

            Cases.ValidCandidateCase candidateCase = new Cases.ValidCandidateCase();
            candidateCase
                .OpenSite(webDriver, "http://localhost:56484")
                .FillValidProfile(commands, mapper)
                .OpenContactTab(webDriver)
                .FillValidPhone(webDriver, commands, mapper)
                .OpenSkillTab(webDriver)
                .FillValidSkill(webDriver, commands, mapper)
                .SaveProfile(webDriver, commands);
            webDriver.Quit();
        }
    }
}
