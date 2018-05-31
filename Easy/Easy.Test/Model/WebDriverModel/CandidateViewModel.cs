using Easy.Test.Decorator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Test.Model.WebDriverModel
{
    class CandidateViewModel : IViewModel
    {
        [TextInput()]
        public string Name { get; set; }
        [TextInput()]
        public string BirthDate { get; set; }
        [TextInput()]
        public string Email { get; set; }
    }
}
