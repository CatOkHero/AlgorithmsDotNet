using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsLeetCodeCSharp.Contests.WeeklyContests
{
	// https://leetcode.com/contest/weekly-contest-197
	public class WeeklyContest197
	{
		// 5461. Number of Substrings With Only 1s
		/* 
		 *	Input: s = "0110111"
			Output: 9
			Explanation: There are 9 substring in total with only 1's characters.
			"1" -> 5 times.
			"11" -> 3 times.
			"111" -> 1 time.
		*/
		public int NumSub(string s)
		{
			long k = 0;
			if (s[0] == '0')
			{
				s = s.Remove(0, 1);
			}

			string[] splitted = s.Split("0");
			if (!s.Contains("1"))
			{
				return 0;
			}

			Array.Sort<string>(splitted);
			for (int i = 0; i < splitted.Length - 1; i++)
			{
				if (splitted[i] == string.Empty)
				{
					continue;
				}

				if (splitted[i] == splitted[i + 1])
				{
					k += 1;
					continue;
				}

				for (int j = 1; j <= splitted[i].Length; j++)
				{
					k += j;
				}
			}

			int res = (int)(k % 10000000007);
			return res;

			//if (splitted.Length == 1)
			//{
			//	splitted = new string[s.Length];
			//	for (int i = 0; i < s.Length; i++)
			//	{
			//		splitted[i] = s.Substring(0, i + 1);
			//	}

			//	for (int i = 0; i < splitted.Length; i++)
			//	{
			//		k += splitted[splitted.Length - 1].Length - splitted[i].Length + 1;
			//	}

			//	return (int)(k % 100000000007);
			//}

			//splitted[0] = s.Substring(s.IndexOf("1"), s.IndexOf("0"));
			//Array.Sort<string>(splitted);
			//for (int i = 0; i < splitted.Length; i++)
			//{
			//	if(splitted[i] == string.Empty)
			//	{
			//		continue;
			//	}

			//	if (i == 0)
			//	{
			//		for (int j = i + 1; j < splitted.Length; j++)
			//		{
			//			k += splitted[j].Length - splitted[i].Length + 1;
			//		}
			//	}
			//	else
			//	{
			//		for (int j = i; j < splitted.Length; j++)
			//		{
			//			k += splitted[j].Length - splitted[i].Length + 1;
			//		}
			//	}
			//}

			//return (int)(k % 100000000007);
		}

		// 5460. Number of Good Pairs
		/* Input: nums = [1,2,3,1,1,3]
        Output: 4
        Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
        */
		public int NumIdenticalPairs(int[] nums)
		{
			int k = 0;
			for (int i = 0; i < nums.Length; i++)
			{
				for (int j = i + 1; j < nums.Length; j++)
				{
					if (nums[j] == nums[i])
					{
						k++;
					}
				}
			}

			return k;
		}

		// 5446. Minimum Difference Between Largest and Smallest Value in Three Moves
		public int MinDifference(int[] nums)
		{
			if (nums.Length < 5)
			{
				return 0;
			}


			Array.Sort<int>(nums);
			int k = 0;
			for (int i = 1; i < nums.Length; i++)
			{
				if (nums[i] == nums[i - 1])
				{
					k++;
				}
			}

			if (nums.Length - k < nums.Length - 3)
			{

			}

			return nums[3] - nums[4];
		}

		// 5445. Range Sum of Sorted Subarray Sums
		public int RangeSum(int[] nums, int n, int left, int right)
		{

			IList<int> array = new List<int>();
			for (int i = 0; i < n; i++)
			{
				array.Add(nums[i]);
				for (int j = i + 1; j < n; j++)
				{
					int sum1 = array.Last() + nums[j];
					array.Add(sum1);
				}
			}

			int[] sorted = array.ToArray();
			Array.Sort<int>(sorted);

			int sum = 0;
			for (int i = left - 1; i <= right - 1; i++)
			{
				sum += sorted[i];
			}

			var math = Math.Pow(10, 10) + 7;
			var modulo = sum % math;
			return (int)modulo;
		}

		// 5177. Reformat Date
		private IList<string> Months = new List<string> { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

		public string ReformatDate(string date)
		{
			var splittedDate = date.Split(" ");
			var firstDay = splittedDate[0].Replace("th", "").Replace("st", "").Replace("rd", "").Replace("nd", "");
			var month = Months.IndexOf(splittedDate[1]) + 1;
			var dateTime = new DateTime(Convert.ToInt32(splittedDate[2]), month, Convert.ToInt32(firstDay));

			return dateTime.ToString("yyyy-MM-dd");
		}
	}
}
