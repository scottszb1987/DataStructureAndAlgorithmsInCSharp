﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Yu.DataStructure.Generic;


namespace Yu.DataStructure.GenericTest
{
    [TestClass]
    public class UnitTestLList
    {
        [TestMethod]
        public void LListConstructor()
        {
            var lListString = new LList<string>();
            var lListInt = new LList<int>();
            var lListBool = new LList<bool>();
        }

        [TestMethod]
        public void LListFirst()
        {
            var listVoid = new LList<int>();
            var listNotVoid = new LList<int>();
            listNotVoid.AddFirst(2000);

            Assert.ReferenceEquals(listVoid.First, null);
            Assert.AreEqual(listNotVoid.First.Value, 2000);
        }

        [TestMethod]
        public void LListLast()
        {
            var listVoid = new LList<int>();
            var listOne = new LList<int>();
            listOne.AddFirst(100);
            var listTwo = new LList<int>();
            listTwo.AddFirst(10);
            listTwo.AddFirst(20);

            Assert.ReferenceEquals(listVoid.Last, null);
            Assert.AreEqual(listOne.Last.Value, 100);
            Assert.AreEqual(listTwo.Last.Value, 10);
        }

        [TestMethod]
        public void LListAddFirst()
        {
            var list1 = new LList<string>();
            var list2 = new LList<string>();

            var node1 = new LListNode<string>("node1");
            var node2 = new LListNode<string>("node2");

            list1.AddFirst("111");
            list1.AddFirst("222");

            list2.AddFirst(node1);
            list2.AddFirst(node2);

            Console.WriteLine("List1: " + list1.ToString());
            Console.WriteLine("List2: " + list2.ToString());
        }

        [TestMethod]
        public void LListAddLast()
        {
            var list1 = new LList<int>();
            list1.AddLast(1);
            list1.AddLast(2);
            Console.WriteLine("list1: " + list1.ToString());

            var list2 = new LList<int>();
            var node1 = new LListNode<int>(1);
            var node2 = new LListNode<int>(2);
            list2.AddLast(node1);
            list2.AddLast(node2);
            Console.WriteLine("list2: " + list2.ToString());
        }

        [TestMethod]
        public void LListFind()
        {
            var list = new LList<int>();
            for (int i = 0; i < 10; i++)
                list.AddLast(i);
            var node = list.Find(3);
            Assert.AreEqual(node.Value, 3);

            var list2 = new LList<string>();
            list2.AddFirst("a");
            list2.AddFirst("b");
            list2.AddFirst("c");
            var node2 = list2.Find("b");
            Assert.AreEqual(node2.Value, "b");

            var list3 = new LList<int>();
            var node3 = list3.Find(2);
            Assert.AreEqual(node3, null);
        }

        [TestMethod]
        public void LListFindLast()
        {
            var list = new LList<int>();
            list.AddLast(1);
            list.AddLast(1);
            list.AddLast(2);
            var node = list.FindLast(1);
            Assert.AreEqual(node.Next.Value, 2);

            var list2 = new LList<int>();
            list2.AddFirst(1);
            Assert.AreEqual(list2.FindLast(1).Value, 1);
        }

        [TestMethod]
        public void LListAddAfter()
        {
            var list = new LList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            var node = list.Find(2);
            list.AddAfter(node, new LListNode<int>(4));
            list.AddAfter(list.Find(3), 5);
            Console.WriteLine(list.ToString() + "the _tail pointer is now: " + list.Last.Value);
        }

        [TestMethod]
        public void LListAddBefore()
        {
            var list = new LList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddBefore(list.Find(2), new LListNode<int>(4));
            list.AddBefore(list.First, 5);
            Console.WriteLine(list.ToString() + "the _head pointer is now: " + list.First.Value);
        }
        
        [TestMethod]
        public void LListRemove()
        {
            var list = new LList<int>();
            Console.WriteLine("test void");
            Console.WriteLine(list.RemoveFirst());
            Console.WriteLine(list.RemoveLast());
            Console.WriteLine(list.ToString());

            list.AddFirst(10);
            Console.WriteLine("test 1 item list remove first");
            Console.WriteLine(list.RemoveFirst());
            Console.WriteLine(list.ToString());

            list.AddFirst(10);
            Console.WriteLine("test 1 item list remove last");
            Console.WriteLine(list.RemoveLast());

            list.AddFirst(10);
            Console.WriteLine("test 1 item list remove value");
            Console.WriteLine(list.Remove(10));
            Console.WriteLine(list.ToString());

            list.AddFirst(10);
            list.AddFirst(11);
            list.AddFirst(11);
            Console.WriteLine("test multi item list remove first item using remove(T) and remove first");
            Console.WriteLine(list.Remove(11));
            Console.WriteLine(list.ToString());
            Console.WriteLine(list.RemoveFirst());
            Console.WriteLine(list.ToString());

            for (int i = 0; i < 10; i++)
                list.AddLast(i);

            list.Remove(0);
            list.Remove(10);
            Console.WriteLine(list.First.Value + ";" + list.Last.Value);
        }

        [TestMethod]
        public void LListCount()
        {
            var list = new LList<int>();
            list.AddLast(1);
            list.AddLast(2);
            Assert.AreEqual(list.Count(), 2);
            list.RemoveLast();
            Assert.AreEqual(list.Count(), 1);
            list.RemoveLast();
            Assert.AreEqual(list.Count(), 0);
        }

        [TestMethod]
        public void LListContains()
        {
            var list = new LList<int>();
            list.AddLast(10);
            if (list.Contains(10))
                Console.WriteLine("list contains 10");
            else
                Console.WriteLine("list does not contain 10");

            var list2 = new LList<string>();
            list2.AddLast("asdf");
            if(list2.Contains("asdf"))
                Console.WriteLine("list contains asdf");
            else
                Console.WriteLine("list does not contain asdf");
            if (list2.Contains("aaa"))
                Console.WriteLine("list contains aaa");
            else
                Console.WriteLine("list does not contain aaa");
        }

        [TestMethod]
        public void LListToString()
        {
            var list = new LList<int>();
            Console.WriteLine(list.ToString());
            list.AddLast(10);
            Console.WriteLine(list.ToString());
            for (int i = 0; i < 10; i++)
            {
                list.AddLast(i);
            }
            Console.WriteLine(list.ToString());
        }

        [TestMethod]
        public void LListClear()
        {
            var list = new LList<int>();
            for (int i = 0; i < 10; i++)
                list.AddLast(i);
            list.Clear();
            Assert.ReferenceEquals(list, null);
            Assert.AreEqual(list.Count(), 0);
        }

        [TestMethod]
        public void LListIsEmpty(){
            var list = new LList<int>();
            Assert.AreEqual(list.IsEmpty(), true);
            Assert.ReferenceEquals(list.First, list.Last);
            list.AddFirst(10);
            Assert.AreEqual(list.IsEmpty(), false);
            Assert.ReferenceEquals(list.First, list.Last);
            list.Remove(10);
            Assert.ReferenceEquals(list.IsEmpty(), true);
        }

        [TestMethod]
        public void LListConcatenate()
        {
            var list1 = new LList<int>();
            for (int i = 0; i < 5; i++)
            {
                list1.AddLast(i);
            }
            var list2 = new LList<int>();
            for (int i = 10; i < 15; i++)
            {
                list2.AddLast(i);
            }

            LList<int>.Concatenate(ref list1, ref list2);
            Console.WriteLine(list1.ToString());
            Assert.AreEqual(list1.First.Value, 0);
            Assert.AreEqual(list1.Last.Value, 14);
            Assert.AreEqual(list2.First.Value, 10);
            Assert.AreEqual(list2.Last.Value, 14);

            //Console.WriteLine("---list1 empty state---");
            var listEmpty = new LList<int>();
            LList<int>.Concatenate(ref listEmpty, ref list1);
            Assert.AreEqual(listEmpty.First.Value, 0);
            Assert.AreEqual(listEmpty.Last.Value, 14);
        }

        [TestMethod]
        public void LListReverse1()
        {
            var list = new LList<int>();
            for (int i = 0; i < 5; i++)
            {
                list.AddLast(i);
            }
            LList<int>.Reverse1(ref list);
            Assert.AreEqual(list.ToString(),"4,3,2,1,0");

            var list1 = new LList<int>();
            LList<int>.Reverse1(ref list1);
            Assert.AreEqual(list1.IsEmpty(), true);

            list1.AddLast(1);
            LList<int>.Reverse1(ref list1);
            Assert.AreEqual(list1.ToString(), "1");
        }

        [TestMethod]
        public void LListFindByPosition()
        {
            var list = new LList<string>();
            Assert.ReferenceEquals(list.FindByPosition(1), null);
            list.AddLast("zero");
            list.AddLast("one");
            list.AddLast("two");
            Console.WriteLine(list.Count());
            Assert.ReferenceEquals(list.FindByPosition(3), null);
            Assert.AreEqual(list.FindByPosition(0).Value, "zero");
            Assert.AreEqual(list.FindByPosition(1).Value, "one");
            Assert.AreEqual(list.FindByPosition(2).Value, "two");
        }

        [TestMethod]
        public void LListReverse2()
        {
            var list = new LList<int>();
            for (int i = 0; i < 5; i++)
            {
                list.AddLast(i);
            }
            LList<int>.Reverse2(list);
            Assert.AreEqual(list.ToString(), "4,3,2,1,0");

            list.RemoveFirst();
            LList<int>.Reverse2(list);
            Assert.AreEqual(list.ToString(), "0,1,2,3");

            var list2 = new LList<int>();
            list2.AddLast(1);
            Assert.AreEqual(list2.ToString(), "1");
        }

        [TestMethod]
        public void LListReverse3()
        {
            var list = new LList<int>();
            list.AddLast(-1);
            LList<int>.Reverse3(list);
            Assert.AreEqual(list.ToString(), "-1");
            for (int i = 0; i < 10; i++)
            {
                list.AddLast(i);
            }
            LList<int>.Reverse3(list);
            Assert.AreEqual(list.ToString(), "9,8,7,6,5,4,3,2,1,0,-1");
        }

        [TestMethod]
        public void LListSplit()
        {
            var list = new LList<int>();
            LList<int> result =LList<int>.Split(list, 1);
            Assert.ReferenceEquals(result, null);

            for (int i = 0; i < 10; i++)
            {
                list.AddLast(i);
            }
            result = LList<int>.Split(list, 100);
            Assert.ReferenceEquals(result, null);

            result = LList<int>.Split(list, 5);
            Assert.AreEqual(list.ToString(), "0,1,2,3,4,5");
            Assert.AreEqual(result.ToString(), "6,7,8,9");
        }
    }
}
