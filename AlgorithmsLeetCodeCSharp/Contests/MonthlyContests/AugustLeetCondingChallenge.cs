using System;
using System.Collections.Generic;

namespace AlgorithmsLeetCodeCSharp.Contests.MonthlyContests
{
	// https://leetcode.com/explore/challenge/card/august-leetcoding-challenge/
	public class AugustLeetCondingChallenge
    {
        // https://leetcode.com/explore/challenge/card/august-leetcoding-challenge/549/week-1-august-1st-august-7th/3414/
        // Find All Duplicates in an Array
        public IList<int> FindDuplicates(int[] nums)
        {
            var list = new List<int>();
            if (nums == null || nums.Length == 0)
            {
                return list;
            }

            Array.Sort(nums);
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1])
                {
                    list.Add(nums[i]);
                }
            }

            return list;
        }

        // https://leetcode.com/explore/challenge/card/august-leetcoding-challenge/549/week-1-august-1st-august-7th/3412/
        // Power of Four
        public bool IsPowerOfFour(int num)
        {
            //return (num > 0 && (Math.Log10(num) / Math.Log10(4) % 1 == 0));

            return (num > 0 && ((num & (num - 1)) == 0) && (num & 0x11111111) != 0);

            // O(N)
            //string str = Convert.ToString(num, 2);
            //var results = str.Split('1');
            //if (str[0] != '1' || (str.Length - 1) % 2 != 0 || results.Count() != 2)
            //{
            //    return false;
            //}

            //return true;
        }

        // https://leetcode.com/explore/challenge/card/august-leetcoding-challenge/549/week-1-august-1st-august-7th/3411/
        // Valid Palindrome
        public bool IsPalindrome(string s)
        {
            if (s == null || s == string.Empty)
            {
                return true;
            }

            s = s.ToUpper();
            int i = 0;
            int j = s.Length - 1;
            while (i < j)
            {
                if ((s[i] < 65 || s[i] > 90) && (s[i] > 57 || s[i] < 48))
                {
                        i++;
                        continue;
                }

                if ((s[j] < 65 || s[j] > 90) && (s[j] > 57 || s[j] < 48))
                {
                    j--;
                    continue;
                }

                if (s[i] != s[j])
                {
                    return false;
                }

                i++;
                j--;
            }

            return true;
        }

        // https://leetcode.com/explore/featured/card/august-leetcoding-challenge/549/week-1-august-1st-august-7th/3409/
        // Detect Capital
        public bool DetectCapitalUse(string word)
        {
            bool firstCondition = word[0] < 96;
            bool secondCondition = word[0] > 96;
            bool thirdCondition = word[0] < 96;
            for (int i = 1; i < word.Length; i++)
            {
                if (firstCondition)
                {
                    firstCondition = word[i] < 96;
                }

                if (secondCondition)
                {
                    secondCondition = word[i] > 96;
                }

                if (thirdCondition)
                {
                    thirdCondition = word[i] > 96;
                }
            }

            return firstCondition || secondCondition || thirdCondition;
        }
    }
}
