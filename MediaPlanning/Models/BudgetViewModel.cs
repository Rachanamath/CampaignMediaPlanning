using System.ComponentModel.DataAnnotations;

namespace MediaPlanning.Models
{
    public class BudgetViewModel
    {
        [Required(ErrorMessage = "Total Campaign Budget is required")]
        [Range(1, double.MaxValue, ErrorMessage = "Total Campaign Budget must be a positive number")]
        public double TotalBudget { get; set; }

        [Required(ErrorMessage = "Agency Fee Percentage is required")]
        [Range(0, 100, ErrorMessage = "Agency Fee Percentage must be between 0 and 99")]
        public double AgencyFeePercentage { get; set; }

        [Required(ErrorMessage = "Third-Party Tool Fee Percentage is required")]
        [Range(0, 100, ErrorMessage = "Third-Party Tool Fee Percentage must be between 0 and 99")]
        public double ThirdPartyFeePercentage { get; set; }

        [Required(ErrorMessage = "Fixed Cost for Agency Hours is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Fixed Cost for Agency Hours must be a positive number")]
        public double FixedAgencyHoursCost { get; set; }

        [Required(ErrorMessage = "Sum of Budgets for Other Ads is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Sum of Budgets for Other Ads must be a positive number")]
        public double OtherAdsTotal { get; set; }

        [Required(ErrorMessage = "Initial Guess for the Specific Ad Budget is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Initial Guess must be a positive number")]
        public double InitialGuess { get; set; }
    }
}
