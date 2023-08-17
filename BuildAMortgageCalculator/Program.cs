class Program
{
    
    static double purchasePrice;
    static double downPayment;
    static double marketValue;
    static double interestRate;
    static double monthlyInterestRate;
    static double yearlyHOAFees;
    static double monthlyIncome;
    static int loanTerm;
    
    //Testing values
    /*
    static double purchasePrice = 250000;
    static double downPayment = 20000;
    static double marketValue = 300000;
    static double interestRate = 7;
    static double monthlyInterestRate;
    static double yearlyHOAFees = 1200;
    static double monthlyIncome = 6000;
    static int loanTerm = 15;
    */

    static double loanInsurance;
    static double propertyTax;
    static double escrow;
    static double monthlyEscrow;
    static double homeOwnersInsurance;
   
    static void Main(string[] args)
    {
        //AskForInput();
        double calcLoanAmount = CalculateLoanAmount();
        Console.WriteLine(calcLoanAmount);
        double monthlyPayment = CalculateMontlyPayment(calcLoanAmount, interestRate, loanTerm);
        Console.WriteLine(monthlyPayment);
        LoanStatus(monthlyPayment);
    }
    
    static void AskForInput()
    {

        //Step 1: Get Input from the loan officer
        Console.WriteLine("Enter the purchase price of the home:");
        purchasePrice = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the down payment from the buyer:");
        downPayment = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the market value:");
        marketValue = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the interest rate:");
        interestRate = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the yearly HOA fees:");
        yearlyHOAFees = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the buyer's monthly income:");
        monthlyIncome = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the loan term (15 or 30):");
        loanTerm = int.Parse(Console.ReadLine());
    }

    //Step 2: Calculate the total loan amount
    static double CalculateLoanAmount()
    {
        double originationFee = 0.01 * (purchasePrice - downPayment) + 2500;
        double totalLoanAmount = purchasePrice - downPayment + originationFee;
        double equity = marketValue - totalLoanAmount;


        if(equity < (marketValue * .1)) 
        {
            loanInsurance = (0.01 * totalLoanAmount) / 12;
        }
        else
        {
            loanInsurance = 0;
        }

        return totalLoanAmount;
    }

    //Step 3: Calculate the monthly payment
    static double CalculateMontlyPayment(double localLoanAmount, double interest, int loanLength)
    {
        double r = (interest / 100) / 12;
        int n = 12 * loanLength;
        double monthlyPayment = localLoanAmount * (r) * Math.Pow(1 + r, n) / (Math.Pow(1 + r, n) - 1);

        propertyTax = marketValue * 0.0125 / 12;
        homeOwnersInsurance = marketValue * 0.0075 / 12;
        double monthlyHOA = yearlyHOAFees / 12;
        escrow = propertyTax + monthlyHOA + homeOwnersInsurance;

        double totalMonthlyPayment = monthlyPayment + loanInsurance + escrow;

        Console.WriteLine("Test");
        return totalMonthlyPayment;

    }
    
    //Step 4: Loan approval/denial
    static bool LoanStatus(double monthlyPayment)
    {
        //loan is approved if the buyers monthly payment is greater than their monthly income * .25
        if(monthlyPayment <= monthlyIncome * .25)
        {
            Console.WriteLine("Loan Approved!");
            return true;
        }
        else
        {
            Console.WriteLine("Loan Denied, ur poor!");
            return false;
        }
    }
};


