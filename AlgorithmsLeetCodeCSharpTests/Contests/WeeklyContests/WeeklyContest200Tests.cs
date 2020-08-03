using AlgorithmsLeetCodeCSharp.Contests.WeeklyContests;
using NUnit.Framework;

namespace AlgorithmsLeetCodeCSharpTests.Contests.WeeklyContests
{
	public class WeeklyContest200Tests
	{
		private WeeklyContest200 solution = new WeeklyContest200();


		[TestCase(new int[] { 1, 1, 2, 2, 3 }, 0, 0, 1, 0)]
		[TestCase(new int[] { 3, 0, 1, 1, 9, 7 }, 7, 2, 3, 4)]
		[TestCase(new int[] { 7, 3, 7, 3, 12, 1, 12, 2, 3 }, 5, 8, 1, 12)]
		[TestCase(new int[] { 5, 5, 2, 6, 4 }, 5, 4, 5, 10)]
		public void Check_CountGoodTriplets_Base(int[] arr, int a, int b, int c, int result)
		{
			var countGoodTriplets = solution.CountGoodTriplets(arr, a, b, c);
			Assert.AreEqual(result, countGoodTriplets);
		}


		[TestCase(new int[] { 3, 2, 1 }, 10, 3)]
		[TestCase(new int[] { 2, 1, 3, 5, 4, 6, 7 }, 2, 5)]
		[TestCase(new int[] { 1, 9, 8, 2, 3, 7, 6, 4, 5 }, 7, 9)]
		[TestCase(new int[] { 1, 11, 22, 33, 44, 55, 66, 77, 88, 99 }, 1000000000, 99)]
		[TestCase(new int[] { 1, 25, 35, 42, 68, 70 }, 1, 25)]
		[TestCase(new int[] { 1, 25, 35, 68, 42, 70 }, 3, 70)]
		public void Check_GetWinner_BaseCase(int[] arr, int k, int result)
		{
			var getWinner = solution.GetWinner(arr, k);
			Assert.AreEqual(result, getWinner);
		}
	}
}
