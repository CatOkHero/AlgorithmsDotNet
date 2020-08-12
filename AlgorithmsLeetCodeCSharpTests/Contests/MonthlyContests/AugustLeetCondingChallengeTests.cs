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

		[TestCase(16, true)]
		[TestCase(256, true)]
		[TestCase(81, false)]
		[TestCase(24, false)]
		[TestCase(32, false)]
		[TestCase(8, false)]
		[TestCase(63, false)]
		public void Check_IsPowerOfFour_BaseCase(int num, bool result)
		{
			var isPowerOfFour = solution.IsPowerOfFour(num);
			Assert.AreEqual(result, isPowerOfFour);
		}

		[TestCase(new int[] { 4, 3, 2, 7, 8, 2, 3, 1 }, new int[] { 2, 3 })]
		[TestCase(new int[] { 1, 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1 })]
		public void Check_FindDuplicates_BaseCase(int[] nums, int[] result)
		{
			var findDuplicates = solution.FindDuplicates(nums);
			Assert.AreEqual(result, findDuplicates);
		}
	}
}
