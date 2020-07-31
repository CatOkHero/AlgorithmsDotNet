using System;
using System.Threading;

namespace AlgorithmsLeetCodeCSharp.Concurency.MediumProblems
{
	public class FooBar
    {
        private AutoResetEvent firstEvent = null;
        private AutoResetEvent secondEvent = null;
        private int n;

        public FooBar(int n)
        {
            this.n = n;
            firstEvent = new AutoResetEvent(false);
            secondEvent = new AutoResetEvent(false);
        }

        public void Foo(Action printFoo)
        {
            firstEvent.Set();
            for (int i = 0; i < n; i++)
            {
                firstEvent.WaitOne();
                // printFoo() outputs "foo". Do not change or remove this line.
                printFoo();
                secondEvent.Set();
            }
        }

        public void Bar(Action printBar)
        {
            for (int i = 0; i < n; i++)
            {
                secondEvent.WaitOne();
                // printBar() outputs "bar". Do not change or remove this line.
                printBar();
                firstEvent.Set();
            }
        }
    }
}
