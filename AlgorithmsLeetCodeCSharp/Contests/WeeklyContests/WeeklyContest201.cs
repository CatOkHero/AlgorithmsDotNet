using System.Collections.Generic;

namespace AlgorithmsLeetCodeCSharp.Contests.WeeklyContests
{
	// https://leetcode.com/contest/weekly-contest-201
	public class WeeklyContest201
	{
        // https://leetcode.com/contest/weekly-contest-201/problems/maximum-number-of-non-overlapping-subarrays-with-sum-equals-target/
        // 1546. Maximum Number of Non-Overlapping Subarrays With Sum Equals Target
        public int MaxNonOverlapping(int[] nums, int target)
        {
            int count = 0;
            int sum = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                sum += nums[i];
                for (int j = i; j >= 0; j--)
                {
                    var diff = sum - nums[j];
                    if (diff == target)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        // https://leetcode.com/contest/weekly-contest-201/problems/find-kth-bit-in-nth-binary-string/
        // 1545. Find Kth Bit in Nth Binary String
        public char FindKthBit(int n, int k)
        {
            if (k == 0)
            {
                return '0';
            }

            int count = 1;
            var list = new List<bool>() { false };
            while (count != n)
            {
                list.Add(true);
                var toReverse = list.Take(list.Count - 1);
                var inverted = toReverse.Reverse().Select(item => item ? false : true);
                list.AddRange(inverted);
                count++;
            }

            return list[k - 1] ? '1' : '0';
        }

        // https://leetcode.com/contest/weekly-contest-201/problems/make-the-string-great/
        // 1544. Make The String Great
        public string MakeGood(string s)
        {
            var list = new List<char>(s.ToCharArray());
            int i = 1;
            while (list.Count > 0 && i < list.Count && i > 0)
            {
                if ((list[i] < 96
                   && list[i - 1] > 96
                   && list[i - 1] - 32 == list[i])
                || (list[i - 1] < 96
                   && list[i] > 96
                   && list[i] - 32 == list[i - 1]))
                {
                    list.RemoveAt(i);
                    list.RemoveAt(i - 1);
                    i -= 2;
                }

                i++;
                if (i == 0)
                {
                    i = 1;
                }
            }

            return new string(list.ToArray());
        }
    }
}
