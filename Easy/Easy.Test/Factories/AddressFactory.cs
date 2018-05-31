using Easy.Test.Model.WebDriverModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easy.Test.Factories
{
    static class AddressFactory
    {
        public static AdrressViewModel Address()
        {
            return new AdrressViewModel
            {
                Country = "Brazil",
                State = "ValidState " + Guid.NewGuid().ToString().Split('-').First(),
                City = "ValidCity" + Guid.NewGuid().ToString().Split('-').First(),
                Number = Guid.NewGuid().ToString().Split('-').First(),
                PostalCode = "83660-000"
            };
        }
    }
}
