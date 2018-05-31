
namespace Easy.Core
{
    public class Phone
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
    }
}