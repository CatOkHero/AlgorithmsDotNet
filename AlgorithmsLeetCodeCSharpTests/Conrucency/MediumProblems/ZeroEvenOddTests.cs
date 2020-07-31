using AlgorithmsLeetCodeCSharp.Concurency.MediumProblems;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace AlgorithmsLeetCodeCSharpTests.Conrucency.MediumProblems
{
	public class ZeroEvenOddTests
	{
		[TestCase(2, "0102")]
		[TestCase(3, "010203")]
		[TestCase(5, "0102030405")]
		public void Check_ZeroEvenOdd_BaseCase(int n, string result)
		{
			string wholeString = string.Empty;
			var zeroEvenOdd = new ZeroEvenOdd(n);
			var zeroAction = new Action<int>((x) => wholeString = string.Concat(wholeString, x.ToString()));
			var evenAction = new Action<int>((x) => wholeString = string.Concat(wholeString, x.ToString()));
			var oddAction = new Action<int>((x) => wholeString = string.Concat(wholeString, x.ToString()));
			
			Parallel.Invoke
			(
				() => zeroEvenOdd.Zero(zeroAction),
				() => zeroEvenOdd.Even(evenAction),
				() => zeroEvenOdd.Odd(oddAction)
			);

			Assert.AreEqual(result, wholeString);
		}
	}
}
