using AlgorithmsLeetCodeCSharp.Chapters.ArrayAndString;
using NUnit.Framework;
using System.Collections.Generic;

namespace AlgorithmsLeetCodeCSharpTests.Chapters.ArrayAndString
{
	public class IntroductionTo2DArrayTests
	{
		private IntroductionTo2DArray solution = new IntroductionTo2DArray();

		private static IEnumerable<TestCaseData> FindDiagonalOrder_first_test()
		{
			yield return new TestCaseData(
				new int[9] { 1, 2, 4, 7, 5, 3, 6, 8, 9},
				new int[3][] {
					new int[3] { 1, 2, 3 },
					new int[3] { 4, 5, 6 },
					new int[3] { 7, 8, 9 }
				});
		}

		private static IEnumerable<TestCaseData> FindDiagonalOrder_second_test()
		{
			yield return new TestCaseData(
				new int[3] { 7, 8, 9 },
				new int[3][] {
					new int[1] { 7 },
					new int[1] { 8 },
					new int[1] { 9 }
				});
		}

		private static IEnumerable<TestCaseData> FindDiagonalOrder_third_test()
		{
			yield return new TestCaseData(
				new int[6] { 2, 5, 4, 0, 8, -1 },
				new int[2][] {
					new int[3] { 2, 5, 8 },
					new int[3] { 4, 0, -1 }
				});
		}

		[Test]
		[TestCaseSource("FindDiagonalOrder_first_test")]
		[TestCaseSource("FindDiagonalOrder_second_test")]
		[TestCaseSource("FindDiagonalOrder_third_test")]
		public void Check_FindDiagonalOrder_BaseCase(int[] result, int[][] matrix)
		{
			var findDiagonal = solution.FindDiagonalOrder(matrix);
			Assert.AreEqual(result, findDiagonal);
		}

		private static IEnumerable<TestCaseData> SpiralOrder_first_test()
		{
			yield return new TestCaseData(
				new int[9] { 1, 2, 3, 6, 9, 8, 7, 4, 5 },
				new int[3][] {
					new int[3] { 1, 2, 3 },
					new int[3] { 4, 5, 6 },
					new int[3] { 7, 8, 9 }
				});
		}

		private static IEnumerable<TestCaseData> SpiralOrder_second_test()
		{
			yield return new TestCaseData(
				new int[3] { 7, 8, 9 },
				new int[3][] {
					new int[1] { 7 },
					new int[1] { 8 },
					new int[1] { 9 }
				});
		}

		private static IEnumerable<TestCaseData> SpiralOrder_third_test()
		{
			yield return new TestCaseData(
				new int[6] { 2, 5, 8, -1, 0, 4 },
				new int[2][] {
					new int[3] { 2, 5, 8 },
					new int[3] { 4, 0, -1 }
				});
		}

		private static IEnumerable<TestCaseData> SpiralOrder_fourth_test()
		{
			yield return new TestCaseData(
				new int[1] { 1 },
				new int[1][] {
					new int[1] { 1 }
				});
		}

		// [[1,2,3,4],[5,6,7,8],[9,10,11,12],[13,14,15,16]]
		// [1,2,3,4,8,12,16,15,14,13,9,5,6,7,11,10]
		private static IEnumerable<TestCaseData> SpiralOrder_fifth_test()
		{
			yield return new TestCaseData(
				new int[16] { 1, 2, 3, 4, 8, 12, 16, 15, 14, 13, 9, 5, 6, 7, 11, 10 },
				new int[4][] {
					new int[4] { 1, 2, 3, 4 },
					new int[4] { 5, 6, 7, 8 },
					new int[4] { 9, 10, 11, 12 },
					new int[4] { 13, 14, 15, 16 }
				});
		}

		// [[1,2,3,4,5],[6,7,8,9,10],[11,12,13,14,15],[16,17,18,19,20],[21,22,23,24,25]]
		// [1,2,3,4,5,10,15,20,25,24,23,22,21,16,11,6,7,8,9,14,19,18,17,12,13]
		private static IEnumerable<TestCaseData> SpiralOrder_six_test()
		{
			yield return new TestCaseData(
				new int[25] { 1, 2, 3, 4, 5, 10, 15, 20, 25, 24, 23, 22, 21, 16, 11, 6, 7, 8, 9, 14, 19, 18, 17, 12, 13 },
				new int[5][] {
					new int[5] { 1, 2, 3, 4, 5 },
					new int[5] { 6, 7, 8, 9, 10 },
					new int[5] { 11, 12, 13, 14, 15 },
					new int[5] { 16, 17, 18, 19, 20 },
					new int[5] { 21, 22, 23, 24, 25 }
				});
		}

		[TestCaseSource("SpiralOrder_first_test")]
		[TestCaseSource("SpiralOrder_second_test")]
		[TestCaseSource("SpiralOrder_third_test")]
		[TestCaseSource("SpiralOrder_fourth_test")]
		[TestCaseSource("SpiralOrder_fifth_test")]
		[TestCaseSource("SpiralOrder_six_test")]
		public void Check_SpiralOrder_BaseCase(int[] result, int[][] matrix)
		{
			var spiralOrder = solution.SpiralOrder(matrix);
			Assert.AreEqual(result, spiralOrder);
		}

		private static IEnumerable<TestCaseData> Generate_first_test()
		{
			yield return new TestCaseData(
				new List<IList<int>>()
				{
					new List<int> { 1 }
				},
				1);
		}

		private static IEnumerable<TestCaseData> Generate_second_test()
		{
			yield return new TestCaseData(
				new List<IList<int>>()
				{
					new List<int> { 1 },
					new List<int> { 1, 1 }
				},
				2);
		}

		private static IEnumerable<TestCaseData> Generate_third_test()
		{
			yield return new TestCaseData(
				new List<IList<int>>()
				{
					new List<int> { 1 },
					new List<int> { 1, 1 },
					new List<int> { 1, 2, 1 },
					new List<int> { 1, 3, 3, 1 },
					new List<int> { 1, 4, 6, 4, 1 }
				},
				5);
		}

		private static IEnumerable<TestCaseData> Generate_fourth_test()
		{
			yield return new TestCaseData(
				new List<IList<int>>(),
				0);
		}

		[TestCaseSource("Generate_first_test")]
		[TestCaseSource("Generate_second_test")]
		[TestCaseSource("Generate_third_test")]
		[TestCaseSource("Generate_fourth_test")]
		public void Check_Generate_BaseCase(IList<IList<int>> result, int numberOfRows)
		{
			var generate = solution.Generate(numberOfRows);
			Assert.AreEqual(result, generate);
		}
	}
}
