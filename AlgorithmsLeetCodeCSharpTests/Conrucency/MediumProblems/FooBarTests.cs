using AlgorithmsLeetCodeCSharp.Concurency.MediumProblems;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace AlgorithmsLeetCodeCSharpTests.Conrucency.MediumProblems
{
	public class FooBarTests
	{
		[TestCase(2, "foobarfoobar")]
		[TestCase(0, "")]
		[TestCase(1, "foobar")]
		[TestCase(4, "foobarfoobarfoobarfoobar")]
		[TestCase(16, "foobarfoobarfoobarfoobarfoobarfoobarfoobarfoobarfoobarfoobarfoobarfoobarfoobarfoobarfoobarfoobar")]
		public void Check_FooBar_BaseCase(int n, string result)
		{
			string wholeString = string.Empty;
			var fooBar = new FooBar(n);
			var fooAction = new Action(() => wholeString = string.Concat(wholeString, "foo"));
			var barAction = new Action(() => wholeString = string.Concat(wholeString, "bar"));

			Parallel.Invoke
			(
				() => fooBar.Foo(fooAction),
				() =>  fooBar.Bar(barAction)
			);

			Assert.AreEqual(result, wholeString);
		}
	}
}
