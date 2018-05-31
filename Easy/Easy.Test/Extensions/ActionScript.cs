using Easy.Test.Decorator;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Test.Extensions
{

    static class ActionScript
    {
        public static Actions Await(this Actions actions, int milliseconds)
        {
            Task.Delay(milliseconds).GetAwaiter().GetResult();
            return actions;
        }

        public static void AwaitAndPerform(this Actions actions, int milliseconds)
        {
            Task.Delay(milliseconds).GetAwaiter().GetResult();
            actions.Build().Perform();
        }

        public static Actions Clear(this Actions actions, IWebElement element)
        {
            element.Clear();
            actions.MoveToElement(element);
            return actions.Await(1000);
        }

        public static void PerformAndAwait(this Actions actions, int milliseconds)
        {
            actions.Perform();
            Task.Delay(milliseconds).GetAwaiter().GetResult();
        }

        public static void SelectRandomItem(this Actions actions, IWebElement selectElement)
        {
            var options = selectElement.FindElements(By.TagName("option"));
            Random random = new Random();
            var item = random.Next(1, options.Count - 1);
            options[item].Click();
            actions.Await(1000);
        }

        public static void TryClear(this Actions actions, IWebElement element)
        {
            try
            {
                element.Clear();
            }
            catch { }
        }

        public static void Value<T>(this EasyAction actions, IWebElement element, PropertyInfo property, T instance)
        {
            var elementAttribute = property.GetCustomAttribute<ElementAttribute>(true);
            elementAttribute?.Map(actions, element, property, instance);
        }
    }
}
