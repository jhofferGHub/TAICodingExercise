using System.ComponentModel.DataAnnotations;

namespace TAICodingExercise.DTO
{
    public class Insured
    {
        public Insured() {
            PolicyList = new List<Policy>();
        }
        [Required]
        public string ID { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required] 
        public string FirstName { get; set; }
        [Required] 
        public string Gender { get; set; }
        [Required] 
        public DateTime DateOfBirth { get; set; }

        public decimal RiskAmount { get; set; }
        private List<Policy> PolicyList { get; set; }
        public void AddPolicy(Policy policy)
        {
            PolicyList.Add(policy);
            CalculateRisk();
        }
        private void CalculateRisk()
        {
            RiskAmount = PolicyList.Sum(x => x.FaceAmount) - PolicyList.Sum(x => x.CashValue);
        }
    }
}
