using System.ComponentModel.DataAnnotations;

namespace TAICodingExercise.DTO
{
    public class Policy
    {
        public string? PolicyNumber {  get; set; }
        [Required]
        public decimal FaceAmount { get; set; }
        [Required] 
        public decimal CashValue {  get; set; }
    }
}
