using System;
using System.Threading;

namespace AlgorithmsLeetCodeCSharp.Concurency.MediumProblems
{
    public class ZeroEvenOdd
    {
        private int n;
        private int x;
        private AutoResetEvent zeroEvent = null;
        private AutoResetEvent evenEvent = null;
        private AutoResetEvent oddEvent = null;

        public ZeroEvenOdd(int n)
        {
            this.n = n;
            zeroEvent = new AutoResetEvent(true);
            evenEvent = new AutoResetEvent(false);
            oddEvent = new AutoResetEvent(false);
        }

        // printNumber(x) outputs "x", where x is an integer.
        public void Zero(Action<int> printNumber)
        {
            while (x < n)
            {
                zeroEvent.Reset();
                printNumber(0);
                x++;

                if(x == n)
				{
                    break;
				}

                if (x % 2 == 0)
                {
                    evenEvent.Set();
                }
                else
                {
                    oddEvent.Set();
                }

                zeroEvent.WaitOne();
            }

            evenEvent.Set();
            oddEvent.Set();
        }

        public void Even(Action<int> printNumber)
        {
            evenEvent.WaitOne();
            while (x <= n)
            {
                if (x % 2 == 0)
                {
                    printNumber(x);
                }

                if(x == n)
				{
                    break;
				}

                zeroEvent.Set();
                evenEvent.WaitOne();
            }
        }

        public void Odd(Action<int> printNumber)
        {
            oddEvent.WaitOne();
            while (x <= n)
            {
                if(x % 2 != 0)
                {
                    printNumber(x);
                }

                if (x == n)
                {
                    break;
                }

                zeroEvent.Set();
                oddEvent.WaitOne();
            }
        }
    }
}
