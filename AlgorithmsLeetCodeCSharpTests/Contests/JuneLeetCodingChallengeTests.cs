using AlgorithmsLeetCode.Contests;
using NUnit.Framework;
using System;
using System.Linq;

namespace AlgorithmsLeetCodeCSharpTests.Contests
{
	public class JuneLeetCodingChallengeTests
	{
		private JuneLeetCodingChallenge solution = new JuneLeetCodingChallenge();

		[Test]
		public void Check_AddBinary_BaseCase()
		{
			var addBinaryResult1 = solution.AddBinary("1111111", "1");
			Assert.IsTrue(addBinaryResult1 == "10000000");
		}

		[Test]
		public void Check_AddBinary_SecondFailedCase()
		{
			var addBinaryResult2 = solution.AddBinary("110010", "10111");
			Assert.IsTrue(addBinaryResult2 == "1001001");
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

		[Test]
		public void Check_FindMin_BaseCase()
		{
			int[] oneDimentionalNums = new int[] { 4, 5, 6, 7, 0, 1, 2 };
			var findMin = solution.FindMin(oneDimentionalNums);
			Assert.IsTrue(findMin == 0);
		}

		[Test]
		public void Check_FindMin_SecondCase()
		{
			int[] oneDimentionalNums = new int[] { 2,2,2,0,1 };
			var findMin = solution.FindMin(oneDimentionalNums);
			Assert.IsTrue(findMin == 0);
		}

		[Test]
		public void Check_FindMin_ThirdCase()
		{
			int[] oneDimentionalNums = new int[] { 2, 2, 2, 2, 2 };
			var findMin = solution.FindMin(oneDimentionalNums);
			Assert.IsTrue(findMin == 2);
		}
	}
}
