using AlgorithmsLeetCodeCSharp.Chapters.ArrayAndString;
using NUnit.Framework;

namespace AlgorithmsLeetCodeCSharpTests.Chapters.ArrayAndString
{
	public class IntroductionToArrayTests
	{
		public IntroductionToArray solution = new IntroductionToArray();

		[TestCase(new int[] { 1, 7, 3, 6, 5, 6 }, 3)]
		[TestCase(new int[] { 1, 7, 3, 5, 0, 5, 6 }, 3)]
		[TestCase(new int[] { 1, 7, 2, 0, 0, 5, 0, 0, 1, 5, 4 }, 5)]
		[TestCase(new int[] { -1, -1, -1, 0, 1, 1 }, 0)]
		[TestCase(new int[] { 1, 2, 3 }, -1)]
		[TestCase(new int[] { }, -1)]
		public void Check_PivotIndex_BaseCase(int[] nums, int result)
		{
			var pivotIndex = solution.PivotIndex(nums);
			Assert.AreEqual(result, pivotIndex);
		}

		[TestCase(new int[] { 3, 6, 1, 0 }, 1)]
		[TestCase(new int[] { 1, 7, 3, 5, 0, 5, 6 }, -1)]
		[TestCase(new int[] { 0, 0, 0, 1 }, 3)]
		public void Check_DominantIndex_BaseCase(int[] nums, int result)
		{
			var dominantIndex = solution.DominantIndex(nums);
			Assert.AreEqual(result, dominantIndex);
		}

		[TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 4 })]
		[TestCase(new int[] { 1, 7, 3, 5, 0, 5, 6 }, new int[] { 1, 7, 3, 5, 0, 5, 7 })]
		[TestCase(new int[] { 9 }, new int[] { 1, 0 })]
		[TestCase(new int[] { 9, 9, 9, 9 }, new int[] { 1, 0, 0, 0, 0 })]
		public void Check_PlusOne_BaseCase(int[] nums, int[] result)
		{
			var plusOne = solution.PlusOne(nums);
			Assert.AreEqual(result, plusOne);
		}
	}
}
