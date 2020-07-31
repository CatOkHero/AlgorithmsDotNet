using AlgorithmsLeetCodeCSharp.Chapters.QueueAndStackProblems;
using NUnit.Framework;
using System.Collections.Generic;

namespace AlgorithmsLeetCodeCSharpTests.Chapters.QueueAndStackProblems
{
	public class QueueAndBFSTests
	{
		QueueAndBFS solution = new QueueAndBFS();

		private static IEnumerable<TestCaseData> first_test()
		{
			yield return new TestCaseData(1, new char[4][] {
				new char[5] { '1', '1', '1', '1', '0' },
				new char[5] { '1', '1', '0', '1', '0' },
				new char[5] { '1', '1', '0', '0', '0' },
				new char[5] { '0', '0', '0', '0', '0' }
			});
		}

		private static IEnumerable<TestCaseData>  second_test()
		{
			yield return new TestCaseData(1, new char[2][] {
				new char[1] { '1' },
				new char[1] { '1' }
			});
		}

		private static IEnumerable<TestCaseData> third_test()
		{
			yield return new TestCaseData(3, new char[4][] {
				new char[5] { '1', '1', '0', '0', '0' },
				new char[5] { '1', '1', '0', '0', '0' },
				new char[5] { '0', '0', '1', '0', '0' },
				new char[5] { '0', '0', '0', '1', '1' }
			});
		}

		private static IEnumerable<TestCaseData> fourth_test()
		{
			yield return new TestCaseData(0, null);
		}

		[Test]
		[TestCaseSource("first_test")]
		[TestCaseSource("second_test")]
		[TestCaseSource("third_test")]
		[TestCaseSource("fourth_test")]
		public void Check_NumIslandsWithoutQueue_BaseCase(int result, char[][] grid)
		{
			int resultWithoutQueue = solution.NumIslandsWithoutQueue(grid);
			Assert.AreEqual(result, resultWithoutQueue);
		}

		[Test]
		[TestCaseSource("first_test")]
		[TestCaseSource("second_test")]
		[TestCaseSource("third_test")]
		[TestCaseSource("fourth_test")]
		public void Check_NumIslandsWithQueue_BaseCase(int result, char[][] grid)
		{
			int resultWithQueue = solution.NumIslandsWithQueue(grid);
			Assert.AreEqual(result, resultWithQueue);
		}

		[TestCase(3, 12)]
		[TestCase(2, 13)]
		[TestCase(3, 11)]
		[TestCase(4, 7)]
		[TestCase(3, 14)]
		[TestCase(3, 6)]
		[TestCase(2, 10)]
		[TestCase(4, 15)]
		[TestCase(3, 19)]
		[TestCase(2, 20)]
		[TestCase(3, 22)]
		[TestCase(3, 43)]
		public void Check_NumSquares_BaseCase(int result, int num)
		{
			int numSquares = solution.NumSquares(num);
			Assert.AreEqual(result, numSquares);
		}
	}
}
