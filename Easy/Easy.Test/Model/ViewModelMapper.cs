using Easy.Test.Extensions;
using OpenQA.Selenium;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

namespace Easy.Test.Model
{
    class ViewModelMapper
    {
        IWebDriver WebDriver { get; }

        public ViewModelMapper(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        public void Map<T>(T viewModel, EasyAction action)
        {
            var type = typeof(T);
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                var element = WebDriver.TryFindElement(By.Id(type.ViewPropertyName(property)));
                //WebDriver.SwitchTo().ActiveElement();
                if (element != null)
                {
                    var js = String.Format("window.scrollTo({0}, {1})", 0, element.Location.Y - 100);
                    ((OpenQA.Selenium.IJavaScriptExecutor)WebDriver).ExecuteScript(js);
                    action.Value(element, property, viewModel);
                }
            }
        }
    }
}
