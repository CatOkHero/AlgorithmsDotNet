using System;
using System.Collections.Generic;
using System.Linq;
namespace AlgorithmsLeetCodeCSharp.Contests.BiWeeklyContests
{
    // https://leetcode.com/contest/biweekly-contest-32
    public class BiWeeklyContest32
    {

        // https://leetcode.com/contest/biweekly-contest-32/problems/minimum-insertions-to-balance-a-parentheses-string/
        // 1541. Minimum Insertions to Balance a Parentheses String
        public int MinInsertions(string s)
        {
            int count = 0;
            int leftCount = 0;
            int rightCount = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if(i == 0 && s[i] != '(')
				{

				}

                if (s[i] == '(')
                {
                    leftCount++;
                }
                else
                {
                    rightCount++;
                }
            }

            if (leftCount == s.Length)
            {
                return leftCount * 2;
            }

            if (rightCount == s.Length)
            {
                return rightCount % 2 == 0 ? rightCount / 2 : rightCount / 2 + 2;
            }

            if (s[0] != '(')
            {
                int rights = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == ')')
                    {
                        rights++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (rights % 2 == 0)
                {
                    count += rights / 2;
                    rightCount -= rights;
                }
                else
                {
                    rightCount -= rights;
                    count += (rights % 2) + (rights / 2);
                }
            }

            if (s[s.Length - 1] == '(')
            {
                int lefts = 0;
                for (int i = s.Length - 1; i >= 0; i--)
                {
                    if (s[i] == '(')
                    {
                        lefts++;
                    }
                    else
                    {
                        break;
                    }
                }

                count += lefts * 2;
                leftCount -= lefts;
            } else
			{

                int rights = 0;
                for (int i = s.Length - 1; i >= 0; i--)
                {
                    if (s[i] == ')')
                    {
                        rights++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (rights % 2 != 0)
                {
                    count += rights / 2 + 2;
                    rightCount -= rights;
                    leftCount -= 1;
                }
            }

            int left = leftCount * 2;
            int right = rightCount;
            if (left != right)
            {
                int diff = 0;
                if (left > right)
                {
                    diff = left - right;
                    count += diff;
                }
                else
                {
                    diff = right - left;
                    count += diff;
                }
            }

            return count;
        }

        // https://leetcode.com/contest/biweekly-contest-32/problems/kth-missing-positive-number/
        // 1539. Kth Missing Positive Number
        public int FindKthPositive(int[] arr, int k)
        {
            int first = arr[0];
            int last = arr[arr.Length - 1];
            int count = 0;

            if (first != 1)
			{
                count += first - 1;
                if (count >= k)
                {
                    return k;
                }
            }
            
            if(arr.Length == last)
			{
                return last + k;
			}



            int j = 0;
            for (int i = first; i < last; i++)
            {
                if (i != arr[j])
                {
                    count++;
                }
                else if (i == arr[j])
                {
                    j++;
                }

                if (count == k)
                {
                    return i;
                }
            }

            if(count != k)
			{
                return last + (k - count);
			}

            return -1;
        }
    }
}
