using Easy.Test.Decorator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Test.Model.WebDriverModel
{
    [View(Prefix = "Phone")]
    class PhoneViewModel : IViewModel
    {
        public string Id { get; set; }
        [TextInput()]
        public string Number { get; set; }
    }
}
