using System;

namespace AlgorithmsLeetCodeCSharp.Contests.WeeklyContests
{
    // https://leetcode.com/contest/weekly-contest-200
    public class WeeklyContest200
	{
        // https://leetcode.com/contest/weekly-contest-200/problems/count-good-triplets/
        // 1534. Count Good Triplets
        public int CountGoodTriplets(int[] arr, int a, int b, int c)
        {
            int count = 0;
            int i = 0;
            int j = 1;
            int k = 2;
            while (i <= arr.Length - 3)
            {
                if (Math.Abs(arr[i] - arr[j]) <= a
                   && Math.Abs(arr[j] - arr[k]) <= b
                   && Math.Abs(arr[i] - arr[k]) <= c)
                {
                    count++;
                }

                k++;
                if (k >= arr.Length)
                {
                    j++;
                    k = j + 1;
                }

                if (j >= arr.Length - 1)
                {
                    i++;
                    j = i + 1;
                    k = j + 1;
                }
            }

            return count;
        }

        // https://leetcode.com/contest/weekly-contest-200/problems/find-the-winner-of-an-array-game/
        // 1535. Find the Winner of an Array Game
        public int GetWinner(int[] arr, int k)
        {
            int count = 0;
            int maxIndex = 0;
			for (int i = 1; i < arr.Length; i++)
			{
                if(arr[maxIndex] > arr[i])
				{
                    count++;
				} else
				{
                    maxIndex = i;
                    count = 1;
				}

                if(count == k)
				{
                    return arr[maxIndex];
				}
			}

            return arr[maxIndex];
        }
    }
}
