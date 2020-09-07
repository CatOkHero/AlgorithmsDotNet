using System.Collections.Generic;
using AlgorithmsLeetCodeCSharp.Contests.BiWeeklyContests;
using NUnit.Framework;

namespace AlgorithmsLeetCodeCSharpTests.Contests.BiWeeklyContests
{
    public class BiWeeklyContest34Tests
    {
        private readonly BiWeeklyContest34 solution;

        private static IEnumerable<TestCaseData> first_test()
        {
            yield return new TestCaseData(new int[3][] {
                new int[3] { 1,2,3 },
                new int[3] { 4, 5, 6 },
                new int[3] { 7, 8, 9 }
            }, 25);
        }

        public BiWeeklyContest34Tests()
        {
            solution = new BiWeeklyContest34();
        }

        [TestCaseSource("first_test")]
        public void Check_DiagonalSum_BaseCase(int[][] mat, int result)
        {
            var answer = solution.DiagonalSum(mat);
            Assert.AreEqual(result, answer);
        }
    }
}
