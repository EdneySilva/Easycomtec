using Easy.Test.Decorator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Test.Model.WebDriverModel
{
    [View(Prefix = "Skill")]
    class SkillViewModel : IViewModel
    {
        public string Id { get; set; }
        [TextInput(Order = 1)]
        public string Name { get; set; }
        [Select(Order = 2)]
        public string Level { get; set; }
    }
}
