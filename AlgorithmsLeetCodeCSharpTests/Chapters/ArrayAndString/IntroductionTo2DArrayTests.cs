using AlgorithmsLeetCodeCSharp.Chapters.ArrayAndString;
using NUnit.Framework;
using System.Collections.Generic;

namespace AlgorithmsLeetCodeCSharpTests.Chapters.ArrayAndString
{
	public class IntroductionTo2DArrayTests
	{
		private IntroductionTo2DArray solution = new IntroductionTo2DArray();

		private static IEnumerable<TestCaseData> first_test()
		{
			yield return new TestCaseData(
				new int[9] { 1, 2, 4, 7, 5, 3, 6, 8, 9},
				new int[3][] {
					new int[3] { 1, 2, 3 },
					new int[3] { 4, 5, 6 },
					new int[3] { 7, 8, 9 }
				});
		}

		private static IEnumerable<TestCaseData> second_test()
		{
			yield return new TestCaseData(
				new int[3] { 7, 8, 9 },
				new int[3][] {
					new int[1] { 7 },
					new int[1] { 8 },
					new int[1] { 9 }
				});
		}

		private static IEnumerable<TestCaseData> third_test()
		{
			yield return new TestCaseData(
				new int[6] { 2, 5, 4, 0, 8, -1 },
				new int[2][] {
					new int[3] { 2, 5, 8 },
					new int[3] { 4, 0, -1 }
				});
		}

		[Test]
		[TestCaseSource("first_test")]
		[TestCaseSource("second_test")]
		[TestCaseSource("third_test")]
		public void Check_FindDiagonalOrder_BaseCase(int[] result, int[][] matrix)
		{
			var findDiagonal = solution.FindDiagonalOrder(matrix);
			Assert.AreEqual(result, findDiagonal);
		}
	}
}
