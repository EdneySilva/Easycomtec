using Easy.Test.Model.WebDriverModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Test.Factories
{
    static class PhoneFactory
    {
        public static PhoneViewModel Phone()
        {
            var rand = new Random();
            return new PhoneViewModel
            {
                Number = $"(41) 9{rand.Next(8, 9)}{rand.Next(0, 9)}{rand.Next(0, 9)}{rand.Next(0, 9)}{rand.Next(0, 9)}{rand.Next(0, 9)}{rand.Next(0, 9)}{rand.Next(0, 9)}"
            };
        }
    }
}
