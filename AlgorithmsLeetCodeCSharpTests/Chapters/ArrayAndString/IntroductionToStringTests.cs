using AlgorithmsLeetCodeCSharp.Chapters.ArrayAndString;
using NUnit.Framework;

namespace AlgorithmsLeetCodeCSharpTests.Chapters.ArrayAndString
{
	public class IntroductionToStringTests
	{
		private IntroductionToString solution = new IntroductionToString();

		[TestCase("hello", "", 0)]
		[TestCase("hello", "ll", 2)]
		[TestCase("hellolol", "ol", 4)]
		[TestCase("mississippi", "issip", 4)]
		[TestCase("mississippi", "issipi", -1)]
		[TestCase("aaa", "aaa", 0)]
		public void Check_StrStr_BaseCase(string haystack, string needle, int result)
		{
			var strStr = solution.StrStr(haystack, needle);
			Assert.AreEqual(result, strStr);
		}
	}
}
