using System;

namespace AlgorithmsLeetCode.Problems
{
	public class MediumProblems
	{
		public int ChangeMatrix(int amount, int[] coins)
		{
			if (amount == 0)
			{
				return 1;
			}

			int[,] matrix = new int[coins.Length + 1, amount + 1];
			for (int i = 0; i <= coins.Length; i++)
			{
				for (int j = 0; j <= amount; j++)
				{
					if (i == 0 && j != 0)
					{
						matrix[i, j] = 0;
						continue;
					}

					if (j == 0)
					{
						matrix[i, j] = 1;
						continue;
					}

					if (coins[i - 1] <= j)
					{
						matrix[i, j] = matrix[i - 1, j] + matrix[i, j - coins[i - 1]];
					}
					else
					{
						matrix[i, j] = matrix[i - 1, j];
					}
				}
			}

			return matrix[coins.Length, amount];
		}

		public int ChangeRecursion(int amount, int[] coins)
		{
			int[,] dp = new int[coins.Length, amount + 1];
			for (int i = 0; i < coins.Length; i++)
			{
				for (int j = 0; j < amount + 1; j++)
				{
					dp[i, j] = -1;
				}
			}

			return Recursion(ref coins, 0, amount, dp);
		}

		private int Recursion(ref int[] coins, int index, int amount, int[,] dp)
		{
			if(amount == 0)
			{
				return 1;
			}

			if(index >= coins.Length || amount < 0)
			{
				return 0;
			}

			if(dp[index, amount] != -1)
			{
				return dp[index, amount];
			}

			return dp[index, amount] = Recursion(ref coins, index, amount - coins[index], dp) + Recursion(ref coins, index + 1, amount, dp);
		}
	}
}
