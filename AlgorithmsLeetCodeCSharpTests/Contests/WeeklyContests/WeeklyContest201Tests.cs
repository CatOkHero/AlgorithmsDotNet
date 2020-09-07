using AlgorithmsLeetCodeCSharp.Contests.WeeklyContests;
using NUnit.Framework;

namespace AlgorithmsLeetCodeCSharpTests.Contests.WeeklyContests
{
	public class WeeklyContest201Tests
	{
		private readonly WeeklyContest201 solution = new WeeklyContest201();

		[TestCase("abBAcC", "")]
		public void Check_MakeGood_BaseCase(string s, string result)
		{
			var findKthPositive = solution.MakeGood(s);
			Assert.AreEqual(result, findKthPositive);
		}

		[TestCase(3, 1, '0')]
		[TestCase(4, 11, '1')]
		[TestCase(1, 1, '0')]
		[TestCase(2, 3, '1')]
		public void Check_FindKthBit_BaseCase(int n, int k, int result)
		{
			var findKthPositive = solution.FindKthBit(n, k);
			Assert.AreEqual(result, findKthPositive);
		}
	}
}
