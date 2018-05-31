using Easy.Test.Decorator;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Easy.Test.Extensions
{

    static class ViewInfo
    {

        public static string ViewPropertyName(this Type type, PropertyInfo property)
        {
            var viewAttribute = type.GetCustomAttribute<ViewAttribute>();
            if (viewAttribute == null || (!viewAttribute.Prefix?.Any() ?? true))
                return property.Name;
            return viewAttribute.Prefix + "_" + property.Name;
        }

        public static IWebElement TryFindElement(this IWebDriver webDriver, By by)
        {
            try
            {
                return webDriver.FindElement(by);
            }
            catch (Exception ex)
            {
                return default(IWebElement);
            }
        }
    }
}
