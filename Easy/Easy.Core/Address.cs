
namespace Easy.Core
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public int CandidateId { get; set; }

        public virtual Candidate Candidate { get; set; }

        public Address()
        {

        }        
    }
}