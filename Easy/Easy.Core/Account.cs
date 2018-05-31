using System;

namespace Easy.Core
{
    public class Account
    {
        public string Email { get; set; }
        public string Password { get; set; } 
        public int CandidateId { get; set; }

        public Candidate Candidate { get; set; }
    }
}