using System;
using System.Threading;

namespace AlgorithmsLeetCodeCSharp.Concurency.MediumProblems
{
	public class FizzBuzzNew
	{
		private readonly AutoResetEvent fizz = new AutoResetEvent(false);
		private readonly AutoResetEvent fizzComplete = new AutoResetEvent(false);
		private readonly AutoResetEvent buzz = new AutoResetEvent(false);
		private readonly AutoResetEvent buzzComplete = new AutoResetEvent(false);
		private readonly AutoResetEvent fizzBuzz = new AutoResetEvent(false);
		private readonly AutoResetEvent fizzBuzzComplete = new AutoResetEvent(false);

		private int n = 0;
		private int x = 1;

		public FizzBuzzNew(int n)
		{
			this.n = n;
		}

		public void Fizz(Action printFizz)
		{
			while (fizz.WaitOne() && x <= n)
			{
				printFizz();
				fizzComplete.Set();
			}
		}

		public void Buzz(Action printBuzz)
		{
			while (buzz.WaitOne() && x <= n)
			{
				printBuzz();
				buzzComplete.Set();
			}
		}

		public void Fizzbuzz(Action printFizzBuzz)
		{
			while (fizzBuzz.WaitOne() && x <= n)
			{
				printFizzBuzz();
				fizzBuzzComplete.Set();
			}
		}

		// printNumber(x) outputs "x", where x is an integer.
		public void Number(Action<int> printNumber)
		{
			for (; x <= n; x++)
			{
				if (x % 5 == 0 && x % 3 == 0)
				{
					fizzBuzz.Set();
					fizzBuzzComplete.WaitOne();
				}
				else if (x % 3 == 0)
				{
					fizz.Set();
					fizzComplete.WaitOne();
				}
				else if (x % 5 == 0)
				{
					buzz.Set();
					buzzComplete.WaitOne();
				} else
				{
					printNumber(x);
				}
			}

			fizz.Set();
			buzz.Set();
			fizzBuzz.Set();
		}
	}
}
