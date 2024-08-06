using Microsoft.AspNetCore.Mvc;
using MediaPlanning.Models;

namespace MediaPlanning.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Result(BudgetViewModel model)
        {
            if (ModelState.IsValid)
            {
                var optimizedAdBudget = GoalSeek(
                    model.TotalBudget,
                    model.AgencyFeePercentage / 100,
                    model.ThirdPartyFeePercentage / 100,
                    model.FixedAgencyHoursCost,
                    model.OtherAdsTotal,
                    model.InitialGuess,
                    0.01
                );

                ViewBag.OptimizedAdBudget = Math.Ceiling(optimizedAdBudget * 100) / 100; // Round up to 2 decimal places
                return View(model);
            }
            return View("Index", model);
        }

        private double GoalSeek(
            double totalBudget,
            double agencyFeePercentage,
            double thirdPartyFeePercentage,
            double fixedAgencyHoursCost,
            double otherAdsTotal,
            double initialGuess,
            double tolerance
        )
        {
            double low = 0.0;
            double high = totalBudget;
            double guess = initialGuess;
            double difference = double.MaxValue;

            while (Math.Abs(difference) > tolerance)
            {
                double totalAdSpend = otherAdsTotal + guess;
                double calculatedBudget = totalAdSpend +
                                          (totalBudget * agencyFeePercentage) +
                                          (thirdPartyFeePercentage * otherAdsTotal) +
                                          fixedAgencyHoursCost;

                difference = totalBudget - calculatedBudget;

                if (difference > 0)
                {
                    low = guess;
                }
                else
                {
                    high = guess;
                }

                guess = (low + high) / 2.0;
            }

            return guess;
        }
    }
}
