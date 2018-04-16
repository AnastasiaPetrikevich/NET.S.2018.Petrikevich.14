using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Queue.Logic.Tests
{
    [TestFixture]
    public class QueueTests
    {
        [Test]
        public void QueueConstructor_WithoutParameters() => Assert.AreEqual(new Queue<int>().Count, 0);

        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void QueueConstructor_FromList(int[] array) => Assert.AreEqual(new Queue<int>(array).Count, 5);

        [TestCase(7)]
        public void QueueConstructor_WithCapacity(int capacity) => Assert.AreEqual(new Queue<int>(capacity).Count, 0);

        [Test]
        public void Queue_WithoutParameters_Enqueue_SomeEllements()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            Assert.AreEqual(queue.Count, 4);
        }

        [TestCase(new int[] {1, 2, 3, 4, 5})]
        public void Queue_FromList_Enqueue_SomeEllements(int[] array)
        {
            Queue<int> queue = new Queue<int>(array);
            queue.Enqueue(6);
            queue.Enqueue(7);
            queue.Enqueue(8);
            Assert.AreEqual(queue.Count, 8);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void Queue_FromList_Dequeue_SomeEllements(int[] array)
        {
            Queue<int> queue = new Queue<int>(array);
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            Assert.AreEqual(queue.Count, 2);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void Queue_FromList_Dequeue_AllEllements(int[] array)
        {
            Queue<int> queue = new Queue<int>(array);
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            Assert.AreEqual(queue.Count, 0);
        }

    }
}
