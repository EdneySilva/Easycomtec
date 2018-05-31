using Easy.Test.Model.WebDriverModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easy.Test.Factories
{
    static class SkillFactory
    {
        public static SkillViewModel Skill()
        {
            var rand = new Random();
            return new SkillViewModel
            {
                Name = "ValidSkill " + Guid.NewGuid().ToString().Split('-').First(),
                Level = $"{rand.Next(1, 5)}"
            };
        }
    }
}
