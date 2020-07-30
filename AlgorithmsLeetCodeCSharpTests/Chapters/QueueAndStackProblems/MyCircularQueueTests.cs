using AlgorithmsLeetCodeCSharp.Chapters.QueueAndStackProblems;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AlgorithmsLeetCodeCSharpTests.Chapters.QueueAndStackProblems
{
	public class MyCircularQueueTests
	{
		[Test]
		public void Check_MyCircularQueue_BaseCase()
		{
			MyCircularQueue circularQueue = new MyCircularQueue(3); 
			Assert.IsTrue(circularQueue.EnQueue(1));  // return true
			Assert.IsTrue(circularQueue.EnQueue(2));  // return true
			Assert.IsTrue(circularQueue.EnQueue(3));  // return true
			Assert.IsFalse(circularQueue.EnQueue(4));  // return false, the queue is full
			Assert.IsTrue(circularQueue.Rear() == 3);  // return 3
			Assert.IsTrue(circularQueue.IsFull());  // return true
			Assert.IsTrue(circularQueue.DeQueue());  // return true
			Assert.IsTrue(circularQueue.EnQueue(4));  // return true
			Assert.IsTrue(circularQueue.Rear() == 4);  // return 4
		}

        [Test]
        public void Check_MyCircularQueue_SecondFailedCase()
        {
            MyCircularQueue circularQueue = null;
            var methods = new string[] {
                "MyCircularQueue","enQueue","isFull","enQueue","enQueue","isFull","enQueue","enQueue","enQueue","Front","Front","Rear","enQueue","Rear","enQueue","Rear","Front","enQueue","enQueue","Front","enQueue","enQueue","Rear","enQueue","isEmpty","Rear","Front","Rear","enQueue","Front","enQueue","Rear","isEmpty","Rear","enQueue","Front","Front","deQueue","enQueue","Front","enQueue","enQueue","deQueue","enQueue","isFull","Front","enQueue","deQueue","enQueue","isEmpty","isEmpty","enQueue","Front","Front","Rear","deQueue","Front","enQueue","Rear","enQueue","Rear","Rear","Front","deQueue","enQueue","deQueue","Rear","enQueue","Front","enQueue","enQueue","deQueue","enQueue","Front","enQueue","deQueue","enQueue","Front","Front","enQueue","enQueue","enQueue","Front","enQueue","enQueue","Rear","deQueue","enQueue","Front","enQueue","enQueue","Rear","enQueue","enQueue","Rear","isFull","enQueue","Rear","enQueue","deQueue","Rear","enQueue"
            };

            var paramethers = @"[[30],[71],[],[32],[1],[],[32],[8],[6],[],[],[],[8],[],[3],[],[],[56],[41],[],[14],[6],[],[25],[],[],[],[],[44],[],[84],[],[],[],[59],[],[],[],[4],[],[40],[11],[],[94],[],[],[72],[],[19],[],[],[20],[],[],[],[],[],[58],[],[54],[],[],[],[],[65],[],[],[59],[],[26],[10],[],[14],[],[2],[],[37],[],[],[46],[63],[42],[],[84],[30],[],[],[49],[],[79],[46],[],[97],[83],[],[],[76],[],[79],[],[],[44]]";
            var results = @"[null,true,false,true,true,false,true,true,true,71,71,6,true,8,true,3,71,true,true,71,true,true,6,true,false,25,71,25,true,71,true,84,false,84,true,71,71,true,true,32,true,true,true,true,false,1,true,true,true,false,false,true,32,32,20,true,8,true,58,true,54,54,8,true,true,true,65,true,8,true,true,true,true,3,true,true,true,56,56,true,true,true,56,true,true,30,true,true,41,true,false,79,false,false,79,true,false,79,false,true,79,true]";
            AssertEx.NoExceptionThrown<NullReferenceException>(() =>
            {
                ParseWithReflection(circularQueue, methods, paramethers, results);
            });
        }

        private void ParseWithReflection(MyCircularQueue circularQueue, string[] methods, string paramethersJson, string resultsJson)
        {
            var paramethers = JsonConvert.DeserializeObject<List<int[]>>(paramethersJson);
            var results = JsonConvert.DeserializeObject<List<object>>(resultsJson);

            circularQueue = new MyCircularQueue(paramethers[0][0]);
            var thisType = circularQueue.GetType();
            int index = 0;
            foreach (var method in methods)
            {
                if (index == 0)
                {
                    index++;
                    continue;
                }

                char[] arr = method.ToCharArray();
                arr[0] = char.ToUpper(arr[0]);
                var theMethod = thisType.GetMethod(new string(arr));
                var obj = new object?[0] { };
                if (paramethers[index].Length == 1)
                {
                    object firstParam = paramethers[index][0];
                    obj = new object?[1] { firstParam };
                }

                var result = theMethod.Invoke(circularQueue, obj);
                if (results[index] != null)
                {
                    if (results[index].GetType() == typeof(int))
                    {
                        int res = (int)results[index];
                        Assert.AreEqual(res, (int)result);
                        if (res != (int)result)
                        {
                            throw new NullReferenceException("Failed");
                        }
                    }

                    if (results[index].GetType() == typeof(long))
                    {
                        long res = (long)results[index];
                        Assert.AreEqual(res, (int)result);
                        if(res != (int)result)
						{
                            throw new NullReferenceException("Failed");
						}
                    }

                    if (results[index].GetType() == typeof(bool))
                    {
                        bool res = (bool)results[index];
                        Assert.AreEqual(res, (bool)result);
                        if (res != (bool)result)
                        {
                            throw new NullReferenceException("Failed");
                        }
                    }
                }

                index++;
            }
        }
    }
}
