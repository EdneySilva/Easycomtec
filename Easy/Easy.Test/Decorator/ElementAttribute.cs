using Easy.Test.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Easy.Test.Decorator
{
    [System.AttributeUsage(System.AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    internal abstract class ElementAttribute : Attribute
    {
        public short Order { get; set; }
        public abstract void Map(EasyAction actions, IWebElement element, PropertyInfo property, object instance);
    }

    [System.AttributeUsage(System.AttributeTargets.Property, Inherited = true, AllowMultiple = true)]
    sealed class TextInputAttribute : ElementAttribute
    {
        public override void Map(EasyAction actions, IWebElement element, PropertyInfo property, object instance)
        {
            actions.TryClear(element);
            actions.MoveToElement(element).Click(element).AwaitAndPerform(10);
            var value = property.GetValue(instance)?.ToString() ?? string.Empty;
            actions.SendKeys(value);
            actions.Build().Perform();
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Property, Inherited = true, AllowMultiple = true)]
    sealed class SelectAttribute : ElementAttribute
    {
        public bool UseRandomValue { get; set; }
        private void SelectRandom(Actions actions, IWebElement element)
        {
            var options = element.FindElements(By.TagName("option"));
            options.FirstOrDefault(s => s.FindElements(By.XPath("")).Any());
            Random random = new Random();
            var item = random.Next(1, options.Count - 1);
            options[item].Click();
            actions.Await(100);
        }

        private void SelectByValue(Actions actions, IWebElement element, string value)
        {
            var options = element.FindElements(By.XPath("option[@value = '" + value + "']"));
            options.FirstOrDefault()?.Click();
            actions.Await(1000);
        }

        public override void Map(EasyAction actions, IWebElement element, PropertyInfo property, object instance)
        {
            if (UseRandomValue)
            {
                SelectRandom(actions, element);
                return;
            }
            var value = property.GetValue(instance)?.ToString() ?? string.Empty;
            SelectByValue(actions, element, value);
        }
    }
}
