using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsLeetCodeCSharp.Contests.MonthlyContests
{
	// https://leetcode.com/explore/challenge/card/july-leetcoding-challenge/
	public class JulyLeetCodingChallenge
	{
		// https://leetcode.com/explore/featured/card/july-leetcoding-challenge/547/week-4-july-22nd-july-28th/3402/
		// Add Digits
		public int AddDigits(int num)
		{
			if (num == 0)
			{
				return 0;
			}

			if (num < 10)
			{
				return num;
			}

			return (1 + (num - 1) % (10 - 1));
		}

		// https://leetcode.com/explore/challenge/card/july-leetcoding-challenge/547/week-4-july-22nd-july-28th/3404/
		// Task Scheduler
		// in all cases we do care only about the biggest count of chars
		public int LeastInterval(char[] tasks, int n)
		{
			int[] counts = new int[26];
			for (int i = 0; i < tasks.Length; i++)
			{
				counts[tasks[i] - 'A']++;
			}

			Array.Sort(counts);
			int maximunItemsShoudlBeIdle = counts[25] - 1;
			int maxIdlePositions = maximunItemsShoudlBeIdle * n;
			for (int i = 24; i >= 0; i--)
			{
				maxIdlePositions -= Math.Min(counts[i], maximunItemsShoudlBeIdle);
			}

			return maxIdlePositions > 0 ? maxIdlePositions + tasks.Length : tasks.Length;

			//IList<KeyValuePair<char, int>> groupped = tasks.GroupBy(item => item)
			//	.Select(item => new KeyValuePair<char, int>(item.Key, item.Count()))
			//	.ToList();
			//int count = 0;
			//if(n == 0)
			//{
			//	return tasks.Length;
			//}

			//string str = string.Empty;

			//int i = 0;
			//while(i < groupped.Count)
			//{
			//	if (groupped[i].Value == 0)
			//	{
			//		i++;
			//		continue;
			//	}

			//	count++;
			//	groupped[i] = new KeyValuePair<char, int>(groupped[i].Key, groupped[i].Value - 1);
			//	str = string.Concat(str, groupped[i].Key, " ");
			//	int numberOfZeros = 0;
			//	if (groupped[i].Value == 0)
			//	{
			//		numberOfZeros = i + 1;
			//	}

			//	int countDown = n;
			//	while (countDown != 0)
			//	{
			//		for (int j = i + 1; j < groupped.Count; j++)
			//		{
			//			if(countDown == 0)
			//			{
			//				break;
			//			}

			//			if (j != i
			//				&& groupped[j].Value != 0)
			//			{
			//				groupped[j] = new KeyValuePair<char, int>(groupped[j].Key, groupped[j].Value - 1);
			//				str = string.Concat(str, groupped[j].Key, " ");

			//				count++;
			//				countDown--;
			//			}

			//			if(i != j && groupped[j].Value == 0)
			//			{
			//				numberOfZeros++;
			//			}
			//		}

			//		if(numberOfZeros == groupped.Count)
			//		{
			//			return count;
			//		}

			//		if(countDown == 0)
			//		{
			//			numberOfZeros = 0;
			//			continue;
			//		}

			//		int c = countDown;
			//		while (c != 0)
			//		{
			//			str = string.Concat(str, "Idle", " ");
			//			c--;
			//		}

			//		count += (i == groupped.Count - 2) && (groupped[i].Value == 0 && groupped[i + 1].Value == 0) 
			//			|| (i == groupped.Count - 2) && (groupped[i].Value == 1 && groupped[i + 1].Value == 1) ? 0 : countDown;
			//		countDown = 0;
			//		numberOfZeros = 0;
			//	}

			//	if(groupped[i].Value == 0)
			//	{
			//		i++;
			//	}
			//}

			//return count;
		}
	}
}
