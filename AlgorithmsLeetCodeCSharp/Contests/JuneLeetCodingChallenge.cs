using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmsLeetCode.Contests
{
	public class SetupJuneLeetCodingChallenge
	{
		public void SetupTestCases()
		{
			var juneLeetCodingChallange = new JuneLeetCodingChallenge();

			// TODO : FIX
			//var addBinaryResult = juneLeetCodingChallange.AddBinary("1111111", "1");
			//if(addBinaryResult != "10000000")
			//{
			//	throw new Exception("Failed");
			//}

			int[][] nums = new int[1][];
			nums[0] = new int[2] { 0, 1 };
			//var findOrder = juneLeetCodingChallange.FindOrder(2, nums);
		}
	}

	public class JuneLeetCodingChallenge
	{
		// https://leetcode.com/explore/challenge/card/july-leetcoding-challenge/546/week-3-july-15th-july-21st/3395/
		//  Add Binary
		public string AddBinary(string a, string b)
		{
			int a1Length = a.Length;
			int b1Length = b.Length;
			int length = a1Length > b1Length ? a1Length : b1Length;
			byte prevCarry = 0;
			IList<byte> sum = new List<byte>();
			for (int i = length - 1; i >= 0; i--)
			{
				int a1 = prevCarry;
				int b1 = prevCarry;
				if (i < a1Length)
				{
					a1 = a[i] == '0' ? 0 : 1;
				}

				if(i < b1Length)
				{
					b1 = b[i] == '0' ? 0 : 1;
				}

				byte carry = (byte)(a1 & b1);
				sum.Add((byte)(a1 ^ b1 ^ prevCarry));
				prevCarry = carry;
			}

			if(a1Length > b1Length)
			{
				int lastCounter = a1Length - (a1Length - b1Length) - 1;
				int a1 = a[lastCounter] == '0' ? 0 : 1;
				byte carry = (byte)(a1 & prevCarry);
				sum.Add((byte)(a1 ^ prevCarry));
				if(carry != 0)
				{
					sum.Add(carry);
				}
			} else if(b1Length > a1Length)
			{
				int lastCounter = b1Length - (b1Length - a1Length) - 1;
				int b1 = b[lastCounter] == '0' ? 0 : 1;
				byte carry = (byte)(b1 & prevCarry);
				sum.Add((byte)(b1 ^ prevCarry));
				if (carry != 0)
				{
					sum.Add(carry);
				}
			}

			return BitConverter.ToString(sum.ToArray());
		}


		public class ListNode
		{
			public int val;
			public ListNode next;
			public ListNode(int val = 0, ListNode next = null)
			{
				this.val = val;
				this.next = next;
			}
		}

		// https://leetcode.com/explore/challenge/card/july-leetcoding-challenge/546/week-3-july-15th-july-21st/3396/
		// Remove Linked List Elements
		public ListNode RemoveElements(ListNode head, int val)
		{
			if (head == null)
			{
				return head;
			}

			if (head.val == val)
				return RemoveElements(head.next, val);

			head.next = RemoveElements(head.next, val);
			return head;
		}

		// Course Schedule II
		// TODO: This silly approach doesn't work)
		public int[] FindOrder(int numCourses, int[][] prerequisites)
		{
			if(prerequisites.Length == 0)
			{
				int[] resultArray = new int[numCourses];
				for (int i = 0; i < numCourses; i++)
				{
					resultArray[i] = i;
				}

				return resultArray;
			}

			IDictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
			List<int> result = new List<int>();
			List<int> dontHaveLeaves = new List<int>();
			for (int i = 0; i < prerequisites.Length; i++)
			{
				if(!dictionary.ContainsKey(prerequisites[i][1]))
				{
					dictionary.Add(prerequisites[i][1], new List<int>() { prerequisites[i][0] });
				}
				else
				{
					dictionary[prerequisites[i][1]].Add(prerequisites[i][0]);
				}
			}

			var first = dictionary.FirstOrDefault().Key;
			result.Add(first);
			for (int i = 0; i < dictionary.Count(); i++)
			{
				for (int j = 0; j < dictionary[i].Count; j++)
				{
					if(dictionary.ContainsKey(dictionary[i][j]))
					{
						result.Add(dictionary[i][j]);
					}
					else
					{
						var value = dictionary.FirstOrDefault(item => item.Value == dictionary[i]).Key;
						if(result.Contains(value))
						{
							result.Add(dictionary[i][j]);
							if (dontHaveLeaves.Contains(dictionary[i][j]))
							{
								dontHaveLeaves.Remove(dictionary[i][j]);
							}
						} else
						{
							dontHaveLeaves.Add(dictionary[i][j]);
						}

					}
				}
			}

			if(dontHaveLeaves.Count > 0)
			{
				return new int[0];
			}
			else
			{
				return result.Distinct().ToArray();
			}
		}


		//  Top K Frequent Elements
		public int[] TopKFrequent(int[] nums, int k)
		{
			int[] result = nums.GroupBy(item => item)
								.OrderByDescending(item => item.Count())
								.Take(k)
								.Select(item => item.Key)
								.ToArray();
			return result;

			//IDictionary<int, int> dictionary = new Dictionary<int, int>();
			//for (int i = 0; i < nums.Length; i++)
			//{
			//	if(dictionary.ContainsKey(nums[i]))
			//	{
			//		dictionary[nums[i]] += 1;
			//	} else
			//	{

			//		dictionary.Add(nums[i], 1);
			//	}
			//}

			//return dictionary.OrderByDescending(item => item.Value).Take(k).Select(item => item.Key).ToArray();
		}

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
