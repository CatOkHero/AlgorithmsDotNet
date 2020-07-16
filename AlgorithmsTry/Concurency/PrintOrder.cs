using System;
using System.Threading;
using System.Threading.Tasks;

namespace AlgorithmsLeetCode.Concurency
{
    // 1114. Print in Order
    public class PrintOrder
    {
        private TaskCompletionSource<bool> firstTask = new TaskCompletionSource<bool>(false);
        private TaskCompletionSource<bool> secondTask = new TaskCompletionSource<bool>(false);

        public void First(Action printFirst)
        {
            // printFirst() outputs "first". Do not change or remove this line.
            printFirst();
            firstTask.SetResult(true);
        }

        public async void Second(Action printSecond)
        {
            await firstTask.Task.ConfigureAwait(true);

            // printSecond() outputs "second". Do not change or remove this line.
            printSecond();
            secondTask.SetResult(true);
        }

        public async void Third(Action printThird)
        {
            await secondTask.Task.ConfigureAwait(true);

            // printThird() outputs "third". Do not change or remove this line.
            printThird();
        }
    }
}
