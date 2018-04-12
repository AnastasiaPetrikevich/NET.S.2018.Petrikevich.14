using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Logic
{
    public sealed class Queue<T> 
    {
        #region Fields

        private T[] values;
        private int tail;
        private int head;
        private int capacity = 15;
        private int count;

        #endregion

        #region Properties

        public int Count => count;

        #endregion
        
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public Queue()
        {
            values = new T[capacity];
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="capacity">Capacity of values array.</param>
        public Queue(int capacity)
        {
            values = new T[capacity];
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="elements">List of elements.</param>
        public Queue(IEnumerable<T> elements) : this()
        {
            if (elements == null)
            {
                throw new ArgumentNullException($"{nameof(elements)} mustn't be null.");
            }

            foreach (var i in elements)
            {
                Enqueue(i);
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Add element to queue.
        /// </summary>
        /// <param name="element">Element to be added.</param>
        /// <exception cref="ArgumentNullException">Argument mustn't be null.</exception>
        public void Enqueue(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException($"{nameof(element)} mustn't be null");
            }

            if (count >= capacity)
            {
                Resize();
            }

            values[tail] = element;
            tail = count;
            count++;
        }

        /// <summary>
        /// Find and delete first element in queue.
        /// </summary>
        /// <returns>First element in queue.</returns>
        public T Dequeue()
        {
            T element = values[head];
            values[head] = default(T);
            head += 1;
            count--;
            return element;
        }

        /// <summary>
        /// Find first element in queue.
        /// </summary>
        /// <returns>First element in queue.</returns>
        public T Peek() => values[head];

        /// <summary>
        /// Check if the queue contains the element.
        /// </summary>
        /// <param name="element">element to be checked</param>
        /// <returns>True if queue contains the element.</returns>
        public bool Contains(T element)
        {
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            for (int i = 0; i < count; i++)
            {
                if (comparer.Equals(values[i], element))
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerator GetEnumerator()
        {
            return new Iterator(this);
        }
        #endregion

        #region Private methods

        /// <summary>
        /// Changes the size of values.
        /// </summary>
        private void Resize()
        {
            capacity *= 2;
            T[] tempValues = new T[capacity];

            for (int i = 0; i < values.Length; i++)
            {
                tempValues[i] = values[i];
            }

            values = tempValues;
        }

        #endregion

        #region Iterator
        private class Iterator : IEnumerator<T>
        {
            private Queue<T> queue = new Queue<T>();
            private int current = -1;

            public T Current => queue.values[current];

            object IEnumerator.Current => Current;

            public Iterator(Queue<T> queue)
            {
                this.queue = queue;
            }

            public bool MoveNext()
            {
                current++;

                if (current < queue.Count)
                {
                    return true;
                }

                return false;
            }

            public void Reset()
            {
                current = -1;
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }

        #endregion

    }

}
