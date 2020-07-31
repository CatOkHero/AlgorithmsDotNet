using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace AlgorithmsLeetCode.Problems.Easy
{
	public class EasyProblems
	{
		// https://leetcode.com/problems/split-a-string-in-balanced-strings/
		public int BalancedStringSplit(string s)
		{
			int R = 0;
			int L = 0;
			int count = 0;
			foreach (var item in s)
			{
				if(item == 'R')
				{
					R++;
				}
				else
				{
					L++;
				}

				if(R == L)
				{
					count++;
				}
			}

			return count;

			//char? firstCharacter = s[0];
			//char? secondCharacter = null;
			//int overallCount = 0;
			//int repitedCount = 1;
			//for (int i = 1; i < s.Length; i++)
			//{
			//	if(firstCharacter == null)
			//	{
			//		firstCharacter = s[i];
			//		repitedCount = 1;
			//		continue;
			//	}

			//	if (s[i] == firstCharacter)
			//	{
			//		repitedCount++;
			//		continue;
			//	}

			//	if (s[i] == secondCharacter
			//	  && repitedCount != 0)
			//	{
			//		repitedCount--;
			//	}

			//	if (s[i] != firstCharacter
			//	  && secondCharacter == null)
			//	{
			//		secondCharacter = s[i];
			//		repitedCount--;
			//	}

			//	if (repitedCount == 0)
			//	{
			//		overallCount++;
			//		firstCharacter = null;
			//		secondCharacter = null;
			//	}
			//	else if (repitedCount < 0)
			//	{
			//		repitedCount = 1;
			//		firstCharacter = s[i];
			//		secondCharacter = null;
			//	}
			//}

			//return overallCount;
		}


		// 1389. Create Target Array in the Given Order
		public int[] CreateTargetArray(int[] nums, int[] index)
		{
			IList<int> target = new List<int>();
			for (int i = 0; i < nums.Length; i++)
			{
				target.Insert(index[i], nums[i]);
			}

			return target.ToArray();
		}

		// 709. To Lower Case
		public string ToLowerCase(string str)
		{
			byte[] asciiBytes = Encoding.ASCII.GetBytes(str);
			for (int i = 0; i < str.Length; i++)
			{
				if (asciiBytes[i] >= 65 && asciiBytes[i] <= 90)
				{
					asciiBytes[i] = (byte)(asciiBytes[i] + 32);
				}
			}

			return Encoding.ASCII.GetString(asciiBytes);
		}

		// 1281. Subtract the Product and Sum of Digits of an Integer
		/*
		 * Input: n = 234
		 * Output: 15 
		 * Explanation: 
		 * Product of digits = 2 * 3 * 4 = 24 
		 * Sum of digits = 2 + 3 + 4 = 9 
		 * Result = 24 - 9 = 15
		 */
		public int SubtractProductAndSum(int n)
		{
			char[] chars = n.ToString().ToCharArray();
			int[] numbers = Array.ConvertAll(chars, c => (int)Char.GetNumericValue(c));
			int product = 1;
			int sum = 0;
			for (int i = 0; i < numbers.Length; i++)
			{
				product *= numbers[i];
				sum += numbers[i];
			}

			return product - sum;
		}

		// 1313. Decompress Run-Length Encoded List
		/*
		 * Input: nums = [1,2,3,4]
		 * Output: [2,4,4,4]
		 * Explanation: The first pair [1,2] means we have freq = 1 and val = 2 so we generate the array [2].
		 * The second pair [3,4] means we have freq = 3 and val = 4 so we generate [4,4,4].
		 * At the end the concatenation [2] + [4,4,4] is [2,4,4,4].
		 */
		public int[] DecompressRLElist(int[] nums)
		{
			IList<int> decompressed = new List<int>();
			for (int i = 1; i < nums.Length; i = i + 2)
			{
				for (int j = 0; j < nums[i - 1]; j++)
				{
					decompressed.Add(nums[i]);
				}
			}

			return decompressed.ToArray();
		}

		// 1029. Two City Scheduling
		/*Input: [[10,20],[30,200],[400,50],[30,20]]
		 * Output: 110
		 * Explanation: 
		 * The first person goes to city A for a cost of 10.
		 * The second person goes to city A for a cost of 30.
		 * The third person goes to city B for a cost of 50.
		 * The fourth person goes to city B for a cost of 20.
		 * 
		 * The total minimum cost is 10 + 30 + 50 + 20 = 110
		 * to have half the people interviewing in each city.
		 */
		public int TwoCitySchedCost(int[][] costs)
		{
			//int length = costs.Length;
			//int sum = 0;
			//int[] difference = new int[length];
			//for (int i = 0; i < length; i++)
			//{
			//	sum += costs[i][0];
			//	difference[i] = costs[i][1] - costs[i][0];
			//}

			//Array.Sort(difference);
			//for (int i = 0; i < length / 2; i++)
			//{
			//	sum -= Math.Abs(difference[i]);
			//}

			int length = costs.Length / 2;
			Array.Sort(costs, new JaggedArrayComparer());
			int sum = 0;
			for (int i = 0; i < length; i++)
			{
				sum += costs[i][0] + costs[i + length][1];
			}

			return sum;
		}

		private class JaggedArrayComparer : IComparer<int[]>
		{
			public int Compare([AllowNull] int[] x, [AllowNull] int[] y)
			{
				return (x[0] - x[1]) - (y[0] - y[1]);
			}
		}


		// 70. Climbing Stairs
		/*
		 * Input: 2
		 * Output: 2
		 * Explanation: There are two ways to climb to the top.
		 * 1. 1 step + 1 step
		 * 2. 2 steps
		 */
		public int ClimbStairs(int n)
		{
			if (n == 1)
			{
				return 1;
			}

			if (n == 2)
			{
				return 2;
			}

			if (n == 3)
			{
				return 3;
			}

			int previous = 2;
			int sum = 3;
			for (int i = 0; i < n - 3; i++)
			{
				int temp = sum;
				sum += previous;
				previous = temp;
			}

			return sum;
		}

		// 1323. Maximum 69 Number
		/*
		 * Input: num = 9669
		 * Output: 9969
		 * Explanation: 
		 * Changing the first digit results in 6669.
		 * Changing the second digit results in 9969.
		 * Changing the third digit results in 9699.
		 * Changing the fourth digit results in 9666. 
		 * The maximum number is 9969.
		 */
		public int Maximum69Number(int num)
		{
			char[] number = num.ToString().ToCharArray();
			for (int i = 0; i < number.Length; i++)
			{
				if (number[i] == '6')
				{
					number[i] = '9';
					break;
				}
			}

			string result = new string(number);
			return Convert.ToInt32(result);
		}

		// 1365. How Many Numbers Are Smaller Than the Current Number
		/*
		 * Input: nums = [8,1,2,2,3]
		 * Output: [4,0,1,1,3]
		 * Explanation: 
		 * For nums[0]=8 there exist four smaller numbers than it (1, 2, 2 and 3).
		 * For nums[1]=1 does not exist any smaller number than it.
		 * For nums[2]=2 there exist one smaller number than it (1). 
		 * For nums[3]=2 there exist one smaller number than it (1). 
		 * For nums[4]=3 there exist three smaller numbers than it (1, 2 and 2).
		 */
		public int[] SmallerNumbersThanCurrent(int[] nums)
		{
			int length = nums.Length;
			int max = nums[0];
			for (int i = 0; i < length; i++)
			{
				if(max <= nums[i])
				{
					max = nums[i];
				}
			}

			int[] count = new int[max + 1];
			for (int i = 0; i < length; i++)
			{
				count[nums[i]]++;
			}

			for (int i = 1; i <= max; i++)
			{
				count[i] += count[i - 1];
			}

			for (int i = 0; i < length; i++)
			{
				if (nums[i] == 0)
					nums[i] = 0;
				else
					nums[i] = count[nums[i] - 1];
			}

			return nums;

			//int[] result = new int[nums.Length];
			//for (int i = 0; i < nums.Length; i++)
			//{
			//	for (int j = 0; j < nums.Length; j++)
			//	{
			//		if(j == i)
			//		{
			//			continue;
			//		}

			//		if(nums[j] < nums[i])
			//		{
			//			result[i] += 1;
			//		}
			//	}
			//}

			//return result;
		}

		// 1486. XOR Operation in an Array
		/*
		 * Input: n = 5, start = 0
		 * Output: 8
		 * Explanation: Array nums is equal to [0, 2, 4, 6, 8] where (0 ^ 2 ^ 4 ^ 6 ^ 8) = 8.
		 * Where "^" corresponds to bitwise XOR operator.
		 */
		public int XorOperation(int n, int start)
		{
			int[] nums = new int[n];
			int xor = nums[0] = start + 2 * 0;
			for (int i = 1; i < n; i++)
			{
				nums[i] = start + 2 * i;
				xor ^= nums[i];
			}

			return xor;
		}

		// 771. Jewels and Stones
		/*
		 * Input: J = "aA", S = "aAAbbbb"
		 * Output: 3
		 */
		public int NumJewelsInStones(string J, string S)
		{
			if(J.Length == 0)
			{
				return 0;
			}

			int numb = 0;
			for (int i = 0; i < S.Length; i++)
			{
				if(J.Contains(S[i]))
				{
					numb++;
				}
			}

			return numb;
		}

		// 717. 1-bit and 2-bit Characters
		/* 
		 * Input: 
		 * bits = [1, 0, 0]
		 * Output: True
		 * Explanation: 
		 * The only way to decode it is two-bit character and one-bit character. So the last character is one-bit character.
		*/
		public bool IsOneBitCharacter(int[] bits)
		{
			int length = bits.Length;
			if(length < 3)
			{
				return bits[0] == 0;
			}

			if(length < 4)
			{
				if(bits[1] == 1)
				{
					return bits[1] == 1 && bits[0] == 1;
				}

				return bits[1] == 0;
			}

			var prev = bits[length - 2];  // *x0
			var prevprev = bits[length - 3];  // *x00
			if(prev == 0) // *00
			{
				return true;
			} else if(prev == 1 && prevprev == 0) // *010
			{
				return false;
			}

			// ...01110 - false
			// ...011110 - true
			int k = 0;
			for (int i = length - 2; i >= 0 ; i--)
			{
				if(bits[i] == 1)
				{
					k++;
				} else
				{
					break;
				}
			}

			return k % 2 == 0;
		}

		// 1342. Number of Steps to Reduce a Number to Zero
		/*
		 *	Input: num = 14
			Output: 6
			Explanation: 
			Step 1) 14 is even; divide by 2 and obtain 7. 
			Step 2) 7 is odd; subtract 1 and obtain 6.
			Step 3) 6 is even; divide by 2 and obtain 3. 
			Step 4) 3 is odd; subtract 1 and obtain 2. 
			Step 5) 2 is even; divide by 2 and obtain 1. 
			Step 6) 1 is odd; subtract 1 and obtain 0.
		*/
		public int NumberOfSteps(int num)
		{

			int count = 0;
			while (num != 0)
			{
				if (num == 1)
				{
					count++; break;
				}
				if (num % 2 == 0)
					count++;
				else
					count += 2;
				num = num >> 1;
			}
			return count;
			//int result = num;
			//int numberOfSteps = 0;
			//while (result > 0)
			//{
			//	if (result % 2 == 0)
			//	{
			//		result /= 2;
			//		numberOfSteps++;
			//	}
			//	else
			//	{
			//		result -= 1;
			//		numberOfSteps++;
			//	}
			//}

			//return numberOfSteps;
		}

		// 1108. Defanging an IP Address
		/*
		 * Given a valid (IPv4) IP address, return a defanged version of that IP address.
		 * A defanged IP address replaces every period "." with "[.]".
		 * Example 1:
		 * 
		 * Input: address = "1.1.1.1"
		 * Output: "1[.]1[.]1[.]1" 
		 */
		public string DefangIPaddr(string address)
		{
			return address.Replace(".", @"[.]");
		}

		// 1431. Kids With the Greatest Number of Candies
		/* 
		 * Input: candies = [2,3,5,1,3], extraCandies = 3
		 * Output: [true,true,true,false,true] 
		 * Explanation: 
		 * Kid 1 has 2 candies and if he or she receives all extra candies (3) will have 5 candies --- the greatest number of candies among the kids. 
		 * Kid 2 has 3 candies and if he or she receives at least 2 extra candies will have the greatest number of candies among the kids. 
		 * Kid 3 has 5 candies and this is already the greatest number of candies among the kids. 
		 * Kid 4 has 1 candy and even if he or she receives all extra candies will only have 4 candies. 
		 * Kid 5 has 3 candies and if he or she receives at least 2 extra candies will have the greatest number of candies among the kids. 
		*/
		public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
		{
			int max = candies[0];

			for (int i = 1; i < candies.Length; i++)
			{
				if (max < candies[i])
				{
					max = candies[i];
				}
			}

			IList<bool> list = new List<bool>();
			for (int i = 0; i < candies.Length; i++)
			{
				list.Add(candies[i] + extraCandies >= max);
			}

			return list;
		}

		// 1470. Shuffle the Array
		// Input: nums = [2,5,1,3,4,7], n = 3
		// Output: [2,3,5,4,1,7]
		// Explanation: Since x1 = 2, x2 = 5, x3 = 1, y1 = 3, y2 = 4, y3 = 7 then the answer is [2,3,5,4,1,7].
		public int[] Shuffle(int[] nums, int n)
		{
			int i = n - 1;
			for (int j = nums.Length - 1; j >= n; j--)
			{
				nums[j] <<= 10;
				nums[j] |= nums[i];
				i--;
			}

			i = 0;
			for (int j = n; j < nums.Length; j++)
			{
				int num1 = nums[j] & 1023;
				int num2 = nums[j] >> 10;
				nums[i] = num1;
				nums[i + 1] = num2;
				i += 2;
			}

			//int firstItem = nums[0];
			//int lastItem = nums[2 * n - 1];

			//int midNX = n / 2 + 1;
			//int midNY = n + midNX - 1;
			//int j = n;

			//for (int i = 1; i < 2 * n - 1; i++)
			//{
			//	if(i % 2 != 0)
			//	{
			//		int temp = nums[0];
			//		nums[0] = nums[i];
			//		nums[i] = temp;
			//	} else
			//	{
			//		if(i != midNX)
			//		{
			//			nums[0] = nums[i];
			//		}

			//		nums[i] = nums[j];

			//		if (n % 2 != 0)
			//		{
			//			nums[2 * n - 1] = nums[n - 1];
			//			nums[n - 1] = nums[midNX];
			//			nums[j] = nums[midNY];
			//		}
			//		else
			//		{
			//			nums[j] = nums[midNX];
			//		}

			//		j++;
			//	}
			//}

			//nums[0] = firstItem;
			//nums[2 * n - 1] = lastItem;

			return nums;
		}

		// 1480. Running Sum of 1d Array
		// Input: nums = [1,2,3,4]
		// Output: [1,3,6,10]
		// Explanation: Running sum is obtained as follows: [1, 1+2, 1+2+3, 1+2+3+4].
		public int[] RunningSum(int[] nums)
		{
			int sum = nums[0];
			for (int i = 1; i < nums.Length; i++)
			{
				nums[i] += sum;
				sum = nums[i];
			}

			return nums;
		}
	}
}
