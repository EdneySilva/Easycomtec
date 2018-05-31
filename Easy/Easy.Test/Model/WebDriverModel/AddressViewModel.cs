using Easy.Test.Decorator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Test.Model.WebDriverModel
{
    class AdrressViewModel : IViewModel
    {
        [TextInput()]
        public string Country { get; set; }
        [TextInput()]
        public string State { get; set; }
        [TextInput()]
        public string City { get; set; }
        [TextInput()]
        public string Number { get; set; }
        [TextInput()]
        public string PostalCode { get; set; }
    }
}
