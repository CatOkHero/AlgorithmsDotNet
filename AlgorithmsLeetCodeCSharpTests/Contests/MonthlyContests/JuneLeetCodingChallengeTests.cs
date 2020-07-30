using AlgorithmsLeetCode.Contests.MonthlyContests;
using NUnit.Framework;
using System;
using System.Linq;

namespace AlgorithmsLeetCodeCSharpTests.Contests
{
	public class JuneLeetCodingChallengeTests
	{
		private JuneLeetCodingChallenge solution = new JuneLeetCodingChallenge();

		[TestCase("1111111", "1", "10000000")]
		[TestCase("110010", "10111", "1001001")]
		public void Check_AddBinary_BaseCase(string a, string b, string result)
		{
			var addBinary = solution.AddBinary(a, b);
			Assert.AreEqual(addBinary, result);
		}

		[Test]
		public void Check_SingleNumber_BaseCase()
		{
			int[] oneDimentionalNums = new int[] { 1, 2, 1, 3, 2, 5 };
			var singleNumber = solution.SingleNumber(oneDimentionalNums);
			Assert.IsTrue(singleNumber.Count() == 2);
			Assert.IsTrue(singleNumber.Contains(3));
			Assert.IsTrue(singleNumber.Contains(5));
		}

		[TestCase(new int[] { 2, 2, 2, 0, 1 }, 0)]
		[TestCase(new int[] { 2, 2, 2, 2, 2 }, 2)]
		[TestCase(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0)]
		public void Check_FindMin_BaseCase(int[] nums, int result)
		{
			var findMin = solution.FindMin(nums);
			Assert.AreEqual(findMin, result);
		}
	}
}
