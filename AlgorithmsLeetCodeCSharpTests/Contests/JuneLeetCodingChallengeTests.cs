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
	}
}
