using AlgorithmsLeetCodeCSharp.Contests.MonthlyContests;
using NUnit.Framework;

namespace AlgorithmsLeetCodeCSharpTests.Contests.MonthlyContests
{
	public class AugustLeetCondingChallengeTests
	{
		private AugustLeetCondingChallenge solution = new AugustLeetCondingChallenge();

		[TestCase("leetcode", true)]
		[TestCase("USA", true)]
		[TestCase("Google", true)] 
		[TestCase("leetcodE", false)]
		[TestCase("LeetcodE", false)]
		public void Check_DetectCapitalUse_BaseCase(string word, bool result)
		{
			var detectCapitalUse = solution.DetectCapitalUse(word);
			Assert.AreEqual(result, detectCapitalUse);
		}

		[TestCase("A man, a plan, a canal: Panama", true)]
		[TestCase("~!A man, a plan, a canal: Panama", true)]
		[TestCase("race a car", false)]
		[TestCase("0P", false)]
		public void Check_IsPalindrome_BaseCase(string s, bool result)
		{
			var isPalindrome = solution.IsPalindrome(s);
			Assert.AreEqual(result, isPalindrome);
		}
	}
}
