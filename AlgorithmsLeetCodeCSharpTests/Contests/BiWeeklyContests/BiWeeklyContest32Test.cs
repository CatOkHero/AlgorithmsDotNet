using AlgorithmsLeetCodeCSharp.Contests.BiWeeklyContests;
using NUnit.Framework;

namespace AlgorithmsLeetCodeCSharpTests.Contests.BiWeeklyContests
{
	public class BiWeeklyContest32Test
	{
		private readonly BiWeeklyContest32 solution = new BiWeeklyContest32();

		[TestCase(new int[] { 2, 3, 4, 7, 11 }, 5, 9)]
		[TestCase(new int[] { 1, 2, 3, 4 }, 2, 6)]
		[TestCase(new int[] { 7, 13, 21, 25, 29, 32, 38, 45 }, 4, 4)]
		[TestCase(new int[] { 1, 13, 18 }, 17, 20)]
		public void Check_FindKthPositive_BaseCase(int[] arr, int k, int result)
		{
			int findKthPositive = solution.FindKthPositive(arr, k);
			Assert.AreEqual(result, findKthPositive);
		}

		[TestCase("))())(", 3)]
		[TestCase("(()))", 1)]
		[TestCase("())", 0)]
		[TestCase("((((((", 12)]
		[TestCase(")))))))", 5)]
		[TestCase("()()()()()(", 7)]
		[TestCase("()())))()", 3)]
		public void Check_MinInsertions_BaseCase(string s, int result)
		{
			int minInsertions = solution.MinInsertions(s);
			Assert.AreEqual(result, minInsertions);
		}
	}
}
