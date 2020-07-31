using System.Collections.Generic;

namespace AlgorithmsLeetCodeCSharp.Chapters.ArrayAndString
{
	// https://leetcode.com/explore/learn/card/array-and-string/201/introduction-to-array/1143/
	public class IntroductionToArray
    {
        // https://leetcode.com/explore/learn/card/array-and-string/201/introduction-to-array/1148
        // Plus One
        public int[] PlusOne(int[] digits)
        {
            if (digits[digits.Length - 1] < 9)
            {
                digits[digits.Length - 1]++;
                return digits;
            }

            int carry = 0;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] == 9)
                {
                    carry = 1;
                    digits[i] = 0;
                }
                else
                {
                    digits[i]++;
                    carry = 0;
                }

                if (carry == 0)
                {
                    break;
                }
            }

            if (carry == 1)
            {
                var newDigits = new List<int>();
                newDigits.Add(carry);
                newDigits.AddRange(digits);
                return newDigits.ToArray();
            }

            return digits;
        }

        // https://leetcode.com/explore/learn/card/array-and-string/201/introduction-to-array/1147/
        // Largest Number At Least Twice of Others
        public int DominantIndex(int[] nums)
        {
            int maxIndex = 0;
            int max = 0;
            int prevMax = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > max)
                {
                    prevMax = max;
                    max = nums[i];
                    maxIndex = i;
                }
                else if (nums[i] > prevMax)
                {
                    prevMax = nums[i];
                }
            }

            return (max - prevMax >= prevMax) ? maxIndex : -1;
        }

        // https://leetcode.com/explore/learn/card/array-and-string/201/introduction-to-array/1144/
        // Find Pivot Index
        public int PivotIndex(int[] nums)
        {
            //if (nums == null || nums.Length < 2)
            //{
            //    return -1;
            //}

            int total = 0;
			for (int i = 0; i < nums.Length; i++)
			{
                total += nums[i];
			}

            int current = 0;
			for (int i = 0; i < nums.Length; i++)
			{
                if (current == (total - current - nums[i]))
				{
                    return i;
				}

                current += nums[i];
			}

            return -1;
   //         int[] sum = new int[nums.Length];
   //         sum[0] = nums[0];
   //         for (var i = 1; i < nums.Length; i++)
   //         {
   //             sum[i] = sum[i - 1] + nums[i];
   //         }

   //         if(sum[sum.Length - 1] == sum[0])
			//{
   //             return 0;
			//}

   //         for (int i = 1; i < nums.Length; i++)
   //         {
   //             var left = sum[i - 1];
   //             var right = sum[sum.Length - 1] - sum[i];
   //             if (left == right)
   //             {
   //                 return i;
   //             }
   //         }

   //         return -1;
        }
    }
}
