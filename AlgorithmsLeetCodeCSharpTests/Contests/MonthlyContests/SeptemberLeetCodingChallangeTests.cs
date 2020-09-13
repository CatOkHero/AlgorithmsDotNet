using System.Collections.Generic;
using AlgorithmsLeetCodeCSharp.Contests.MonthlyContests;
using NUnit.Framework;

namespace AlgorithmsLeetCodeCSharpTests.Contests.MonthlyContests
{
    public class SeptemberLeetCodingChallangeTests
    {
        private readonly SeptemberLeetCodingChallange solution = new SeptemberLeetCodingChallange();

        private static IEnumerable<TestCaseData> base_test()
        {
            yield return new TestCaseData(
                new int[2][] {
                    new int[2] { 1, 3 },
                    new int[2] { 6, 9 },
                },
                new int[2] { 2, 5 },
                new int[2][] {
                    new int[2] { 1, 5},
                    new int[2] { 6, 9 },
                });
        }

        private static IEnumerable<TestCaseData> first_test()
        {
            yield return new TestCaseData(
                new int[5][] {
                    new int[2] { 1, 2 },
                    new int[2] { 3, 5 },
                    new int[2] { 6, 7 },
                    new int[2] { 8, 10 },
                    new int[2] { 12, 16 },
                },
                new int[2] { 4, 8 },
                new int[3][] {
                    new int[2] { 1, 2 },
                    new int[2] { 3, 10 },
                    new int[2] { 12, 16 }
                });
        }

        private static IEnumerable<TestCaseData> second_test()
        {
            yield return new TestCaseData(
                new int[1][] {
                    new int[2] { 1, 5 },
                },
                new int[2] { 0, 0 },
                new int[2][] {
                    new int[2] { 0, 0 },
                    new int[2] { 1, 5 },
                });
        }

        private static IEnumerable<TestCaseData> third_test()
        {
            yield return new TestCaseData(
                new int[1][] {
                    new int[2] { 1, 5 },
                },
                new int[2] { 0, 6 },
                new int[1][] {
                    new int[2] { 0, 6 },
                });
        }

        private static IEnumerable<TestCaseData> fourth_test()
        {
            yield return new TestCaseData(
                new int[2][] {
                    new int[2] { 3, 5 },
                    new int[2] { 12, 15 }
                },
                new int[2] { 6, 6 },
                new int[3][] {
                    new int[2] { 3, 5 },
                    new int[2] { 6, 6 },
                    new int[2] { 12, 15 }
                });
        }

        [TestCaseSource("base_test")]
        [TestCaseSource("first_test")]
        [TestCaseSource("second_test")]
        [TestCaseSource("third_test")]
        [TestCaseSource("fourth_test")]
        public void Check_Insert_BaseCase(int[][] intervals, int[] newInterval, int[][] result)
        {
            var insert = solution.Insert(intervals, newInterval);
            Assert.AreEqual(result, insert);
        }
    }
}
