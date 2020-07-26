using AlgorithmsLeetCodeCSharp.Contests.BiWeeklyContests;
using NUnit.Framework;

namespace AlgorithmsLeetCodeCSharpTests.Contests.BiWeeklyContests
{
	public class BiWeeklyContest31Tests
	{
		public BiWeeklyContest31 solution = new BiWeeklyContest31();

		[TestCase(1, 10, 5)]
		[TestCase(8, 10, 1)]
		[TestCase(1, 3, 2)]
		public void Check_CountOdds_BaseCase(int low, int high, int result)
		{
			var countOdds = solution.CountOdds(low, high);
			Assert.IsTrue(countOdds == result);
		}

		[TestCase(new int[] { 7 }, 1)]
		[TestCase(new int[] { 2, 4, 6 }, 0)]
		[TestCase(new int[] { 1, 3, 5 }, 4)]
		[TestCase(new int[] { 100, 100, 99, 99 }, 4)]
		[TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 16)]
		public void Check_NumOfSubarrays_BaseCase(int[] arr, int result)
		{
			var numberOfSubarrays = solution.NumOfSubarrays(arr);
			Assert.IsTrue(numberOfSubarrays == result);
		}
	}
}
