using System;

namespace HomeLoanCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Step 1: Get Input from the User
            Console.WriteLine("Enter the purchase price of the home:");
            double purchasePrice = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the market value of the home:");
            double marketValue = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the down payment amount:");
            double downPayment = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the interest rate:");
            double interestRate = double.Parse(Console.ReadLine()) / 100;

            Console.WriteLine("Enter the loan term (15 or 30 years):");
            int loanTerm = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter yearly HOA fees (if any):");
            double yearlyHOAFees = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the buyer's monthly income:");
            double monthlyIncome = double.Parse(Console.ReadLine());

            // Step 2: Calculate the Total Loan Amount
            double originationFee = 0.01 * (purchasePrice - downPayment);
            double totalLoanValue = purchasePrice - downPayment + originationFee + 2500;

            double equityPercentage = downPayment / marketValue * 100;
            double loanInsurance = equityPercentage < 10 ? 0.01 * totalLoanValue : 0;

            // Step 3: Calculate the Monthly Payment
            double monthlyPayment = CalculateMonthlyPayment(totalLoanValue, interestRate, loanTerm);
            double monthlyHOAFees = yearlyHOAFees / 12;
            double propertyTax = marketValue * 0.0125 / 12;
            double homeownersInsurance = marketValue * 0.0075 / 12;
            double totalMonthlyPayment = monthlyPayment + monthlyHOAFees + propertyTax + homeownersInsurance + loanInsurance / 12;

            // Step 4: Determine Approval or Denial of the Loan
            if (totalMonthlyPayment >= 0.25 * monthlyIncome)
            {
                Console.WriteLine("Loan denied. Consider placing more money down or buying a more affordable home.");
            }
            else
            {
                Console.WriteLine("Loan approved!");
            }

            // Step 5: Display the Results
            Console.WriteLine($"Monthly Payment: ${totalMonthlyPayment:F2}");
        }

        // Helper method to calculate the monthly payment
        static double CalculateMonthlyPayment(double principal, double rate, int term)
        {
            double r = rate / 12;
            int n = 12 * term;
            return principal * (r) * Math.Pow(1 + r, n) / (Math.Pow(1 + r, n) - 1);
        }
    }
}