using AlgorithmsLeetCodeCSharp.Chapters.BinaryTreeProblems;
using System.Collections.Generic;

namespace AlgorithmsLeetCodeCSharp.Contests.WeeklyContests
{
    // https://leetcode.com/contest/weekly-contest-199
    public class WeeklyContest199
    {
        // https://leetcode.com/contest/weekly-contest-199/problems/number-of-good-leaf-nodes-pairs/
        // 1530. Number of Good Leaf Nodes Pairs
        public int CountPairs(TreeNode root, int distance)
        {
            int answer = 0;
            var results = CountPairsRecursion(root, distance, ref answer);
            return answer;
        }

        public IList<int> CountPairsRecursion(TreeNode root, int distance, ref int answer)
        {
            if (root == null)
            {
                return new List<int>();
            }

            if (root.left == null && root.right == null)
            {
                return new List<int> { 1 };
            }

            var lefts = CountPairsRecursion(root.left, distance, ref answer);
            var rights = CountPairsRecursion(root.right, distance, ref answer);

            foreach (var left in lefts)
            {
                foreach (var right in rights)
                {
                    if (left + right <= distance)
                    {
                        answer++;
                    }
                }
            }

            var returnList = new List<int>(lefts.Count + rights.Count);
            foreach (var left in lefts)
            {
                if (left + 1 < distance)
                {
                    returnList.Add(left + 1);
                }
            }

            foreach (var right in rights)
            {
                if (right + 1 < distance)
                {
                    returnList.Add(right + 1);
                }
            }

            return returnList;
        }

        // https://leetcode.com/contest/weekly-contest-199/problems/bulb-switcher-iv/
        // 1529. Bulb Switcher IV
        public int MinFlips(string target)
        {
            int length = target.Length;
            //char[] chars = new char[length];
            int countOfFlips = 0;
            bool firstOccurenc = false;
            bool secondOccurenc = false;
            for (int i = 0; i < length; i++)
            {
                if (target[i] == '1' && !firstOccurenc)
                {
                    firstOccurenc = true;
                    secondOccurenc = false;
                    countOfFlips++;
                    //Array.Fill<char>(chars, '1', i, length - i);
                }
                else if (target[i] == '0' && firstOccurenc)
                {
                    firstOccurenc = false;
                    secondOccurenc = true;
                    countOfFlips++;
                    //Array.Fill<char>(chars, '0', i, length - i);
                }
                else if (target[i] == '1' && secondOccurenc)
                {
                    secondOccurenc = false;
                    countOfFlips++;
                    //Array.Fill<char>(chars, '1', i, length - i);
                }
            }

            return countOfFlips;
        }

        // https://leetcode.com/contest/weekly-contest-199/problems/shuffle-string/
        // 1528. Shuffle String
        public string RestoreString(string s, int[] indices)
        {
            char[] stringArray = new char[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                stringArray[indices[i]] = s[i];
            }

            return new string(stringArray);
        }
    }
}
