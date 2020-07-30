using System;
using System.Threading;
using System.Threading.Tasks;

namespace AlgorithmsLeetCodeCSharp.Concurency.MediumProblems
{
    public class FizzBuzzOld
    {
        private int n;
        private static int x;
        private EventWaitHandle firstTask = null;
        private EventWaitHandle secondTask = null;
        private EventWaitHandle thirdTask = null;
        private EventWaitHandle fourthTask = null;

        public FizzBuzzOld(int n)
        {
            firstTask =  new AutoResetEvent(false);
            secondTask = new AutoResetEvent(false);
            thirdTask = new AutoResetEvent(false);
            fourthTask = new AutoResetEvent(false);

            this.n = n;
            x = 1;
        }

        // printFizz() outputs "fizz".
        public void Fizz(Action printFizz)
        {
            while (x <= n)
            {
                firstTask.WaitOne();
                if (x > n)
                {
                    firstTask.Set();
                    secondTask.Set();
                    thirdTask.Set();
                    fourthTask.Set();
                    break;
                }

                while (x % 3 == 0 && x <= n)
                {
                    printFizz();
                    x++;
                }

                firstTask.Reset();
                if (x % 5 != 0 && x % 3 != 0)
                {
                    fourthTask.Set();
                }
                else if (x % 5 == 0)
                {
                    secondTask.Set();
                }
                else
                {
                    thirdTask.Set();
                }
            }
        }

        // printBuzzz() outputs "buzz".
        public void Buzz(Action printBuzz)
        {
            while (x <= n)
            {
                secondTask.WaitOne();
                if (x > n)
                {
                    firstTask.Set();
                    secondTask.Set();
                    thirdTask.Set();
                    fourthTask.Set();
                    break;
                }

                while (x % 5 == 0 && x <= n)
                {
                    printBuzz();
                    x++;
                }

                secondTask.Reset();
                if (x % 5 != 0 && x % 3 != 0)
                {
                    fourthTask.Set();
                }
                else if (x % 5 == 0 && x % 3 == 0)
                {
                    thirdTask.Set();
                }
                else
                {
                    firstTask.Set();
                }
            }
        }

        // printFizzBuzz() outputs "fizzbuzz".
        public void Fizzbuzz(Action printFizzBuzz)
        {
            while (x <= n)
            {
                thirdTask.WaitOne();
                if (x > n)
                {
                    firstTask.Set();
                    secondTask.Set();
                    thirdTask.Set();
                    fourthTask.Set();
                    break;
                }
                while (x % 5 == 0 && x % 3 == 0 && x <= n)
                {
                    printFizzBuzz();
                    x++;
                }

                thirdTask.Reset();
                if (x % 5 != 0 && x % 3 != 0)
                {
                    fourthTask.Set();
                }
                else if (x % 5 == 0)
                {
                    secondTask.Set();
                }
                else
                {
                    firstTask.Set();
                }
            }
        }

        // printNumber(x) outputs "x", where x is an integer.
        public void Number(Action<int> printNumber)
        {
            fourthTask.Set();
            while (x <= n)
            {
                fourthTask.WaitOne();
                if (x > n)
                {
                    firstTask.Set();
                    secondTask.Set();
                    thirdTask.Set();
                    fourthTask.Set();
                    break;
                }

                while (x % 5 != 0 && x % 3 != 0 && x <=n)
                {
                    printNumber(x);
                    x++;
                }

                fourthTask.Reset();
                if (x % 5 == 0 && x % 3 == 0)
                {
                    thirdTask.Set();
                }
                else if (x % 5 == 0)
                {
                    secondTask.Set();
                }
                else
                {
                    firstTask.Set();
                }
            }
        }
    }
}
