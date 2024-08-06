using System.ComponentModel.DataAnnotations;

namespace MediaPlanning.Models
{
    public class BudgetViewModel
    {
        [Required]
        public double TotalBudget { get; set; }

        [Required]
        [Range(0, 100)]
        public double AgencyFeePercentage { get; set; }

        [Required]
        [Range(0, 100)]
        public double ThirdPartyFeePercentage { get; set; }

        [Required]
        public double FixedAgencyHoursCost { get; set; }

        [Required]
        public double OtherAdsTotal { get; set; }

        [Required]
        public double InitialGuess { get; set; }
    }
}

