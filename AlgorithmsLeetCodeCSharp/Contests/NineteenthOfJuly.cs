using System;

namespace AlgorithmsLeetCodeCSharp.Contests
{
	// https://leetcode.com/contest/weekly-contest-198/
	public class NineteenthOfJuly
	{
		// 1519. Number of Nodes in the Sub-Tree With the Same Label
		//public int[] CountSubTrees(int n, int[][] edges, string labels)
		//{
		//	Dictionary<KeyValuePair<int, int>, char> keyValuePairs = new Dictionary<KeyValuePair<int, int>, string>();
		//	keyValuePairs.Add(new KeyValuePair<int, int>(0, 0), labels[0]);

		//	for (int i = 0; i < edges.Length; i++)
		//	{
		//		keyValuePairs.Add(new KeyValuePair<int, int>(edges[i][0], edges[i][1]), labels[i]);
		//	}

		//	var result = keyValuePairs.GroupBy(item => item.Value).Count();
		//	foreach (var item in result)
		//	{
		//		foreach (var keyValuePair in item.Value)
		//		{

		//		}
		//	}
		//}

		// 1518. Water Bottles
		/* 
		 * Input: numBottles = 9, numExchange = 3
		 * Output: 13
		 * Explanation: You can exchange 3 empty bottles to get 1 full water bottle.
		 * Number of water bottles you can drink: 9 + 3 + 1 = 13.
		 */
		public int NumWaterBottles(int numBottles, int numExchange)
		{
			int sum = numBottles;
			double leftToExchange = numBottles;
			double left = 0;
			while (leftToExchange != 0)
			{
				leftToExchange = (double)((leftToExchange + left) / numExchange);
				left = (leftToExchange - Math.Truncate(leftToExchange));
				leftToExchange -= left;
				left *= numExchange;
				sum += (int)leftToExchange;
			}

			return sum;
		}
	}
}
