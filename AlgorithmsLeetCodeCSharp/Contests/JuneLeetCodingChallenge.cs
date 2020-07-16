using System;
using System.Linq;

namespace AlgorithmsLeetCode.Contests
{
	public class JuneLeetCodingChallenge
	{
		//  Reverse Words in a String
		public string ReverseWords(string s)
		{
			string[] splittedWords = s.Split(" ");
			for (int i = 0; i < splittedWords.Length / 2; i++)
			{
				if (splittedWords[i].Length > 0)
				{
					var temp = splittedWords[splittedWords.Length - 1];
					splittedWords[splittedWords.Length - 1] = splittedWords[i];
					splittedWords[i] = temp;
				}
			}

			if(splittedWords.Length == 0)
			{
				return string.Empty;
			}

			return splittedWords.Aggregate((first, second) => string.Concat(first, " ", second));
			//if(s == null || s.Length == 0)
			//{
			//	return string.Empty;
			//}

			//var reverseStringArray = s.Split(" ").Where(item => item.Length > 0).Reverse();
			//if(reverseStringArray.Count() == 0)
			//{
			//	return string.Empty;
			//}

			//return reverseStringArray.Aggregate((first, second) => string.Concat(first, " ", second));
		}

		//   Angle Between Hands of a Clock
		/*
		 * Input: hour = 12, minutes = 30
		 * Output: 165
		 */
		public double AngleClock(int hour, int minutes)
		{

			if (hour == 12 && minutes == 0)
			{
				return 0;
			}

			double hourAngle = .0;
			double minutesAngle = (minutes * 360) / 60;
			double hourWithMinutes = Convert.ToDouble(hour) + (Convert.ToDouble(minutes) / 60);
			if (hour == 12 && minutes > 0)
			{
				hourAngle = ((hourWithMinutes * 360) / 12) - 360;
			}
			else
			{
				hourAngle = (hourWithMinutes * 360) / 12;
			}

			double bigAngle = Math.Abs(hourAngle - minutesAngle);
			if(bigAngle > 180)
			{
				if(hourAngle > minutesAngle)
				{
					double newHoursAngle = 360 - hourAngle;
					return newHoursAngle + minutesAngle;
				} else
				{
					double newMinutesAngle = 360 - minutesAngle;
					return newMinutesAngle + hourAngle;
				}
			}

			return bigAngle;
		}

		// Coin Change 2
		/*
		 * Input: amount = 5, coins = [1, 2, 5]
		 * Output: 4
		 * Explanation: there are four ways to make up the amount:
		 * 5=5
		 * 5=2+2+1
		 * 5=2+1+1+1
		 * 5=1+1+1+1+1 
		 */
		public int Change(int amount, int[] coins)
		{
			if(amount == 0)
			{
				return 1;
			}

			int[,] matrix = new int[coins.Length + 1, amount + 1];
			for (int i = 0; i <= coins.Length; i++)
			{
				for (int j = 0; j <= amount; j++)
				{
					if(i == 0 && j != 0)
					{
						matrix[i, j] = 0;
						continue;
					}

					if(j == 0)
					{
						matrix[i, j] = 1;
						continue;
					}

					if(coins[i - 1] <= j)
					{
						matrix[i, j] = matrix[i - 1, j] + matrix[i, j - coins[i - 1]];
					} else
					{
						matrix[i, j] = matrix[i - 1, j];
					}
				}
			}

			return matrix[coins.Length, amount];
		}
	}
}
