using AlgorithmsLeetCodeCSharp.Contests.MonthlyContests;
using NUnit.Framework;

namespace AlgorithmsLeetCodeCSharpTests.Contests.MonthlyContests
{
	public class JulyLeetCodingChallengeTests
	{
		private JulyLeetCodingChallenge solution = new JulyLeetCodingChallenge();

		[TestCase(101, 2)]
		[TestCase(15, 6)]
		[TestCase(40, 4)]
		[TestCase(23, 5)]
		[TestCase(38, 2)]
		public void Check_AddDigits_BaseCase(int num, int result)
		{
			var addDigits = solution.AddDigits(num);
			Assert.AreEqual(addDigits, result);
		}

		[TestCase(new char[] { 'A', 'A', 'A', 'B', 'B', 'B' }, 2, 8)]
		[TestCase(new char[] { 'A', 'A', 'A', 'A', 'A', 'A', 'B', 'C', 'D', 'E', 'F', 'G' }, 2, 16)]
		[TestCase(new char[] { 'A', 'A', 'A', 'B', 'B', 'B' }, 0, 6)]
		[TestCase(new char[] { 'A', 'A', 'B', 'B', 'C', 'C', 'D', 'D', 'E', 'E', 'F', 'F', 'G', 'G', 'H', 'H', 'I', 'I', 'J', 'J', 'K', 'K', 'L', 'L', 'M', 'M', 'N', 'N', 'O', 'O', 'P', 'P', 'Q', 'Q', 'R', 'R', 'S', 'S', 'T', 'T', 'U', 'U', 'V', 'V', 'W', 'W', 'X', 'X', 'Y', 'Y', 'Z', 'Z' }, 2, 52)]
		public void Check_LeastInterval_BaseCase(char[] tasks, int n, int result)
		{
			var addDigits = solution.LeastInterval(tasks, n);
			Assert.AreEqual(result, addDigits);
		}
	}
}
