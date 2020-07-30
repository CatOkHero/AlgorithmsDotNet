using AlgorithmsLeetCode;
using NUnit.Framework;

namespace AlgorithmsLeetCodeCSharpTests.Problems
{
	public class EasyProblemsTests
	{
		public EasyProblems solution = new EasyProblems();

		[TestCase("RLRRLLRLRL", 4)]
		[TestCase("RLLLLRRRLR", 3)]
		[TestCase("LLLLRRRR", 1)]
		[TestCase("RLRRRLLRLL", 2)]
		public void Check_BalancedStringSplit_BaseCase(string str, int result)
		{
			var balancedStringSplit = solution.BalancedStringSplit(str);
			Assert.AreEqual(result, balancedStringSplit);
		}
	}
}
