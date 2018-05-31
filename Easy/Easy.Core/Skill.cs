using System;

namespace Easy.Core
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Level Level { get; set; }
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
    }
}