using AlgorithmsLeetCodeCSharp.Contests.WeeklyContests;
using NUnit.Framework;

namespace AlgorithmsLeetCodeCSharpTests.Contests.WeeklyContests
{
    public class WeeklyContest205Tests
    {
        private readonly WeeklyContest205 solution;

        public WeeklyContest205Tests()
        {
            solution = new WeeklyContest205();
        }

        [TestCase(new int[2] { 43024, 99908 }, new int[1] { 1864 }, 0)]
        public void Check_NumTriplets_BaseCase(int[] nums1, int[] nums2, int result)
        {
            var answer = solution.NumTriplets(nums1, nums2);
            Assert.AreEqual(result, answer);
        }

        [TestCase("?", "a")]
        [TestCase("??", "ab")]
        [TestCase("?zs", "yzs")]
        [TestCase("ubv?w", "ubvuw")]
        [TestCase("j?qg??b", "jmqgheb")]
        [TestCase("??yw?ipkj?", "amywpipkji")]
        public void Check_ModifyString_BaseCase(string s, string result)
        {
            var answer = solution.ModifyString(s);
            Assert.AreEqual(result, answer);
        }
    }
}
