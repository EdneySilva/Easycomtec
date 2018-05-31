using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Easy.Core
{
    public class Candidate
    {
        public Candidate()
        {
            Skills = new List<Skill>();
            Phones = new List<Phone>();
        }
        
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
        //public virtual PaymentInformation PaymentInformation { get; set; }
        public virtual Address Address { get; set; }
        public Account Account { get; set; }        
    }
}
