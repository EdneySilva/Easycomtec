using Easy.Test.Model.WebDriverModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easy.Test.Factories
{
    static class CandidateFactory
    {
        public static CandidateViewModel Candidate()
        {
            return new CandidateViewModel()
            {
                Name = "ValidName " + Guid.NewGuid().ToString().Replace("-", string.Empty),
                BirthDate = DateTime.Now.AddYears(-18).ToString("MM/dd/yyyy"),
                Email = "validEmail." + Guid.NewGuid().ToString().Split('-').First() + "@validemail.com"
            };
        }
    }
}
