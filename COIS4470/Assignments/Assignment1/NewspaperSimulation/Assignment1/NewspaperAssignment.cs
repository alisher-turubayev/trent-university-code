using System;

namespace Assignment1
{
	class NewspaperAssignment
	{
		// Constants for buying, selling and recycling newspapers
		const double priceRecycle = 0.05;
		const double priceSell = 0.50;
		const double priceBuy = 0.33;

		public static void Main ()
		{
			// Variables to hold number of days simulating and the number of papers to buy
			int NUM_DAYS, NUM_BUY;

			// Random number generator
			Random rnd = new Random();

			// Prompt the user to input the number of days to be simulated
			Console.WriteLine("Please, enter the number of days to be simulated:");
			NUM_DAYS = Convert.ToInt32(Console.ReadLine());
			
			Console.WriteLine("The simulation will be run for {0} days\n", NUM_DAYS);
			// Run the simulation for different numbers of bought papers to determine optimal number
			for (NUM_BUY = 40; NUM_BUY <= 100; NUM_BUY += 10)
			{
				// Variable to hold the total profit earned
				double totalProfit = 0.0;

				for (int day = 1; day <= NUM_DAYS; day++)
				{
					// Generate a random number between 1 and 100 to determine the type of day
					int typeProb = rnd.Next(100) + 1;
					// Generate a random number between 1 and 100 to determine the demand for the day
					int demandProb = rnd.Next(100) + 1;

					// Stores the demand for the day
					int dayDemand = 0;

					// Good day
					if (typeProb <= 35)
					{
						// Determine the demand for the day by probability distribution
						if (demandProb <= 3)
							dayDemand = 40;
						else if (demandProb <= 8)
							dayDemand = 50;
						else if (demandProb <= 23)
							dayDemand = 60;
						else if (demandProb <= 43)
							dayDemand = 70;
						else if (demandProb <= 78)
							dayDemand = 80;
						else if (demandProb <= 93)
							dayDemand = 90;
						else
							dayDemand = 100;
					}
					// Fair day
					else if (typeProb <= 80)
					{
						// Determine the demand for the day by probability distribution
						if (demandProb <= 10)
							dayDemand = 40;
						else if (demandProb <= 28)
							dayDemand = 50;
						else if (demandProb <= 68)
							dayDemand = 60;
						else if (demandProb <= 88)
							dayDemand = 70;
						else if (demandProb <= 96)
							dayDemand = 80;
						else
							dayDemand = 90;
					}
					// Poor day
					else
					{
						// Determine the demand for the day by probability distribution
						if (demandProb <= 44)
							dayDemand = 40;
						else if (demandProb <= 66)
							dayDemand = 50;
						else if (demandProb <= 82)
							dayDemand = 60;
						else if (demandProb <= 94)
							dayDemand = 70;
						else
							dayDemand = 80;
					}

					// Add today's profit to the total
					totalProfit += calculateProfit(dayDemand, NUM_BUY);
				}
				// Output the total profit for the selected number of papers bought
				Console.WriteLine("Number of papers bought each day: {0}", NUM_BUY);
				Console.WriteLine("Total profit: {0:C}", totalProfit);
				Console.WriteLine();
			}
			Console.ReadLine();
		}

		public static double calculateProfit (int dayDemand, int numBought)
		{
			// Calculate profit by adding the revenue from selling the papers and subtracting the money spent on buying them
			double profit = (double)dayDemand * priceSell - (double)numBought * priceBuy;

			// If the daily demand is lower than the amount of papers bought, then recycle the rest and add the revenue
			// Else, subtract the lost profit from buying less newspapers than the demand
			if (dayDemand < numBought)
				profit += (double)(numBought - dayDemand) * priceRecycle;
			else
				profit -= (double)(dayDemand - numBought) * (priceSell - priceBuy);
			
			// Return calculated profit
			return profit;
		}
	}
}
