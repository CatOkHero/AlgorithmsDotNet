using AlgorithmsLeetCodeCSharp.Chapters.LinkedListProblems;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AlgorithmsLeetCodeCSharpTests.Chapters.LinkedListProblems
{
	public class DoublyLinkedListTests
    {
        private DoublyLinkedList doublyLinkedList = new DoublyLinkedList();

        [Test]
        public void Check_DoublyLinkedList_BaseCase()
        {
            doublyLinkedList = new DoublyLinkedList();

            /* 
             * ["MyLinkedList","addAtHead","addAtTail","addAtIndex","get","deleteAtIndex","get"]
             * [[],[1],[3],[1,2],[1],[1],[1]]
            */
            //first failing case
            doublyLinkedList.addAtHead(1);
            doublyLinkedList.addAtTail(3);
            doublyLinkedList.addAtIndex(1, 2);
            var firstResult = doublyLinkedList.get(1);
            doublyLinkedList.deleteAtIndex(1);

            Assert.IsTrue(firstResult == 2);
            Assert.IsTrue(doublyLinkedList.get(0) == 1);
            Assert.IsTrue(doublyLinkedList.get(1) == 3);
        }

        [Test]
        public void Check_DoublyLinkedList_SecondFailingCase()
        {
            //second failing case
            doublyLinkedList = new DoublyLinkedList();

            AssertEx.NoExceptionThrown<NullReferenceException>(() =>
            {
                doublyLinkedList.addAtHead(1);
                doublyLinkedList.deleteAtIndex(0);
            });
        }

        [Test]
        public void Check_DoublyLinkedList_ThirdFailingCase()
        {
            /*
             * ["MyLinkedList",
             * "addAtHead",
             * "addAtHead",
             * "addAtHead",
             * "addAtIndex",
             * "deleteAtIndex",
             * "addAtHead",
             * "addAtTail",
             * "get",
             * "addAtHead",
             * "addAtIndex",
             * "addAtHead"]
             * [[],[7],[2],[1],[3,0],[2],[6],[4],[4],[4],[5,0],[6]]
             * 
             * should be
             * 6 - 4 - 6 - 1 - 2 - 0 - 0 - 4
            */
            //third failing case
            doublyLinkedList = new DoublyLinkedList();
            doublyLinkedList.addAtHead(7);
            doublyLinkedList.addAtHead(2);
            doublyLinkedList.addAtHead(1);
            doublyLinkedList.addAtIndex(3, 0);
            doublyLinkedList.deleteAtIndex(2);
            doublyLinkedList.addAtHead(6);
            doublyLinkedList.addAtTail(4);
            var thirdResult = doublyLinkedList.get(4);
            doublyLinkedList.addAtHead(4);
            doublyLinkedList.addAtIndex(5, 0);
            doublyLinkedList.addAtHead(6);
            Assert.IsTrue(thirdResult == 4);
            Assert.IsTrue(doublyLinkedList.get(0) == 6);
            Assert.IsTrue(doublyLinkedList.get(7) == 4);
        }

        [Test]
        public void Check_DoublyLinkedList_FourthFailingCase()
        {             
            /*
             * ["MyLinkedList",
             * "addAtIndex",
             * "addAtIndex",
             * "addAtIndex",
             * "get"]
             * [[],[0,10],[0,20],[1,30],[0]]
             * 
             * should be
             * 20 - 30 - 10
            */
            //fourth failing case
            doublyLinkedList = new DoublyLinkedList();
            doublyLinkedList.addAtIndex(0, 10);
            doublyLinkedList.addAtIndex(0, 20);
            doublyLinkedList.addAtIndex(1, 30);
            var fourthResult = doublyLinkedList.get(0);
            Assert.IsTrue(fourthResult == 20);
            Assert.IsTrue(doublyLinkedList.get(1) == 30);
            Assert.IsTrue(doublyLinkedList.get(2) == 10);
        }

        [Test]
        public void Check_DoublyLinkedList_FifthFailingCase()
        {
            /*
              * ["MyLinkedList",
              * "addAtHead",
              * "deleteAtIndex",
              * "addAtHead",
              * "addAtHead",
              * "addAtHead",
              * "addAtHead",
              * "addAtHead",
              * "addAtTail",
              * "get",
              * "deleteAtIndex",
              * "deleteAtIndex"]
              * [[],[2],[1],[2],[7],[3],[2],[5],[5],[5],[6],[4]]
              * 
              * should be
              * 5 - 3 - 2 - 7 - 2
              */
            //fifth failed case
            doublyLinkedList = new DoublyLinkedList();
            doublyLinkedList.addAtHead(2);
            doublyLinkedList.deleteAtIndex(1);
            doublyLinkedList.addAtHead(2);
            doublyLinkedList.addAtHead(7);
            doublyLinkedList.addAtHead(3);
            doublyLinkedList.addAtHead(2);
            doublyLinkedList.addAtHead(5);
            doublyLinkedList.addAtTail(5);
            var fifthResult = doublyLinkedList.get(5);
            doublyLinkedList.deleteAtIndex(6);
            doublyLinkedList.deleteAtIndex(4);
            Assert.IsTrue(fifthResult == 2);
            Assert.IsTrue(doublyLinkedList.get(0) == 5);
            Assert.IsTrue(doublyLinkedList.get(4) == 2);
        }

        [Test]
        public void Check_DoublyLinkedList_SixthFailingCase()
        {
               /*
            * ["MyLinkedList",
            * "addAtHead",
            * "get",
            * "addAtIndex",
            * "addAtIndex",
            * "deleteAtIndex",
            * "addAtHead",
            * "addAtHead",
            * "deleteAtIndex",
            * "addAtIndex",
            * "addAtHead",
            * "deleteAtIndex"]
            * [[],[9],[1],[1,1],[1,7],[1],[7],[4],[1],[1,4],[2],[5]]
            * 
            * should be
            * 2 - 4 - 4 - 9 - 1
            */
            //sixth failed case
            doublyLinkedList = new DoublyLinkedList();
            doublyLinkedList.addAtHead(9);
            var sixResult = doublyLinkedList.get(1);
            doublyLinkedList.addAtIndex(1, 1);
            doublyLinkedList.addAtIndex(1, 7);
            doublyLinkedList.deleteAtIndex(1);
            doublyLinkedList.addAtHead(7);
            doublyLinkedList.addAtHead(4);
            doublyLinkedList.deleteAtIndex(1);
            doublyLinkedList.addAtIndex(1, 4);
            doublyLinkedList.addAtHead(2);
            doublyLinkedList.deleteAtIndex(5);
            Assert.IsTrue(sixResult == -1);
            Assert.IsTrue(doublyLinkedList.get(0) == 2);
            Assert.IsTrue(doublyLinkedList.get(4) == 1);
        }

        [Test]
        public void Check_DoublyLinkedList_LastFailedCase()
		{
            /*
             * ["MyLinkedList",
             * "addAtHead",
             * "get",
             * "addAtTail",
             * "deleteAtIndex",
             * "get",
             * "addAtTail",
             * "get",
             * "deleteAtIndex",
             * "addAtHead",
             * "addAtHead",
             * "addAtHead",
             * "addAtHead",
             * "addAtTail",
             * "addAtTail",
             * "addAtTail",
             * "deleteAtIndex",
             * "addAtIndex",
             * "addAtHead",
             * "addAtIndex",
             * "addAtTail",
             * "addAtHead",
             * "get",
             * "addAtHead",
             * "addAtTail",
             * "addAtHead",
             * "addAtHead",
             * "get",
             * "addAtHead",
             * "addAtHead",
             * "addAtTail",
             * "addAtHead",
             * "addAtTail",
             * "addAtTail",
             * "deleteAtIndex",
             * "addAtTail",
             * "deleteAtIndex",
             * "addAtHead",
             * "addAtTail",
             * "addAtIndex",
             * "addAtHead",
             * "addAtTail",
             * "addAtHead",
             * "deleteAtIndex",
             * "deleteAtIndex",
             * "addAtHead",
             * "addAtTail",
             * "addAtTail",
             * "addAtHead",
             * "addAtHead",
             * "get",
             * "deleteAtIndex",
             * "addAtHead",
             * "addAtTail",
             * "deleteAtIndex",
             * "addAtTail",
             * "addAtTail",
             * "addAtTail",
             * "addAtIndex",
             * "addAtIndex",
             * "get",
             * "addAtTail",
             * "addAtTail",
             * "addAtHead",
             * "addAtTail",
             * "addAtTail",
             * "addAtHead",
             * "get",
             * "addAtTail",
             * "get",
             * "deleteAtIndex",
             * "addAtHead",
             * "addAtHead",
             * "addAtHead",
             * "addAtIndex",
             * "addAtIndex",
             * "deleteAtIndex",
             * "get",
             * "addAtTail",
             * "addAtTail",
             * "addAtHead",
             * "get",
             * "addAtHead",
             * "addAtTail",
             * "addAtIndex",
             * "deleteAtIndex",
             * "addAtHead",
             * "addAtHead",
             * "addAtTail",
             * "get",
             * "deleteAtIndex",
             * "addAtHead",
             * "addAtTail",
             * "addAtTail",
             * "addAtHead",
             * "addAtHead",
             * "deleteAtIndex",
             * "get",
             * "addAtHead",
             * "addAtTail",
             * "addAtHead",
             * "addAtTail"]
             * [[],[24],[1],[18],[1],[1],[30],[2],[1],[3],[3],[33],[97],[43],[12],[10],[1],[1,56],[30],[8,83],[57],[74],[5],[98],[72],[34],[61],[6],[70],[24],[91],[99],[13],[10],[17],[84],[16],[73],[88],[4,19],[59],[41],[57],[10],[18],[2],[12],[25],[1],[77],[1],[7],[34],[87],[13],[4],[12],[11],[10,92],[21,55],[11],[38],[31],[45],[4],[21],[38],[4],[88],[12],[22],[40],[22],[23],[13,96],[24,50],[8],[14],[25],[53],[42],[6],[58],[55],[18,72],[13],[30],[97],[59],[47],[24],[37],[26],[31],[93],[66],[11],[43],[70],[36],[31],[28]]
            */
            doublyLinkedList = new DoublyLinkedList();
            var sixMethods = new string[] {
                "DoublyLinkedList","addAtHead","get","addAtTail","deleteAtIndex","get","addAtTail","get","deleteAtIndex","addAtHead","addAtHead","addAtHead","addAtHead","addAtTail","addAtTail","addAtTail","deleteAtIndex","addAtIndex","addAtHead","addAtIndex","addAtTail","addAtHead","get","addAtHead","addAtTail","addAtHead","addAtHead","get","addAtHead","addAtHead","addAtTail","addAtHead","addAtTail","addAtTail","deleteAtIndex","addAtTail","deleteAtIndex","addAtHead","addAtTail","addAtIndex","addAtHead","addAtTail","addAtHead","deleteAtIndex","deleteAtIndex","addAtHead","addAtTail","addAtTail","addAtHead","addAtHead","get","deleteAtIndex","addAtHead","addAtTail","deleteAtIndex","addAtTail","addAtTail","addAtTail","addAtIndex","addAtIndex","get","addAtTail","addAtTail","addAtHead","addAtTail","addAtTail","addAtHead","get","addAtTail","get","deleteAtIndex","addAtHead","addAtHead","addAtHead","addAtIndex","addAtIndex","deleteAtIndex","get","addAtTail","addAtTail","addAtHead","get","addAtHead","addAtTail","addAtIndex","deleteAtIndex","addAtHead","addAtHead","addAtTail","get","deleteAtIndex","addAtHead","addAtTail","addAtTail","addAtHead","addAtHead","deleteAtIndex","get","addAtHead","addAtTail","addAtHead","addAtTail"
            };

            var sixParamethers = @"[[],[24],[1],[18],[1],[1],[30],[2],[1],[3],[3],[33],[97],[43],[12],[10],[1],[1,56],[30],[8,83],[57],[74],[5],[98],[72],[34],[61],[6],[70],[24],[91],[99],[13],[10],[17],[84],[16],[73],[88],[4,19],[59],[41],[57],[10],[18],[2],[12],[25],[1],[77],[1],[7],[34],[87],[13],[4],[12],[11],[10,92],[21,55],[11],[38],[31],[45],[4],[21],[38],[4],[88],[12],[22],[40],[22],[23],[13,96],[24,50],[8],[14],[25],[53],[42],[6],[58],[55],[18,72],[13],[30],[97],[59],[47],[24],[37],[26],[31],[93],[66],[11],[43],[70],[36],[31],[28]]";

            AssertEx.NoExceptionThrown<NullReferenceException>(() =>
            {
                ParseWithReflection(doublyLinkedList, sixMethods, sixParamethers);
            });
        }

        private void ParseWithReflection(DoublyLinkedList doublyLinkedList, string[] methods, string paramethersJson)
        {
            //var paramethersJson = @"[[],[84],[2],[39],[3],[1],[42],[1,80],[14],[1],[53],[98],[19],[12],[2],[16],[33],[4,17],[6,8],[37],[43],[11],[80],[31],[13,23],[17],[4],[10,0],[21],[73],[22],[24,37],[14],[97],[8],[6],[17],[50],[28],[76],[79],[18],[30],[5],[9],[83],[3],[40],[26],[20,90],[30],[40],[56],[15,23],[51],[21],[26],[83],[30],[12],[8],[4],[20],[45],[10],[56],[18],[33],[2],[70],[57],[31,24],[16,92],[40],[23],[26],[1],[92],[3,78],[42],[18],[39,9],[13],[33,17],[51],[18,95],[18,33],[80],[21],[7],[17,46],[33],[60],[26],[4],[9],[45],[38],[95],[78],[54],[42,86]]";
            var paramethers = JsonConvert.DeserializeObject<List<int[]>>(paramethersJson);

            var thisType = doublyLinkedList.GetType();
            int index = 0;
            foreach (var method in methods)
            {
                if (index == 0)
                {
                    index++;
                    continue;
                }

                var theMethod = thisType.GetMethod(method);
                object firstParam = paramethers[index][0];
                if (paramethers[index].Length > 1)
                {
                    object? secondParam = paramethers[index]?[1];
                    var obj = new object?[2] { firstParam, secondParam };
                    theMethod.Invoke(doublyLinkedList, obj);
                }
                else
                {
                    var obj = new object?[1] { firstParam };
                    var result = theMethod.Invoke(doublyLinkedList, obj);
                    if (result != null)
                    {
                        Console.WriteLine(result);
                    }
                }

                index++;
            }
        }
    }
}
