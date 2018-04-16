using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Logic
{
    public sealed class Queue<T> : IEnumerable<T>
    {
        #region Fields

        private T[] values;
        private int tail;
        private int head;
        private int capacity = 15;
        #endregion

        #region Properties

        private int Version { get; set; }
        public int Count { get; private set; }

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

            if (Count >= capacity)
            {
                Resize();
            }

            values[tail] = element;
            tail = Count;
            Count++;
            Version++;
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
            Count--;
            Version++;
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
            for (int i = 0; i < Count; i++)
            {
                if (comparer.Equals(values[i], element))
                {
                    return true;
                }
            }

            return false;
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

        #region Enumerator

        public IEnumerator<T> GetEnumerator()
            => new Enumerator(this);

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private struct Enumerator : IEnumerator<T>
        {
            private readonly Queue<T> queue;
            private readonly int version;
            private int current;

            public T Current
            {
                get
                {
                    if (current == -1)
                    {
                        throw new InvalidOperationException("Iteration do not started!");
                    }

                    return queue.values[current];
                }
            }

            object IEnumerator.Current => Current;

            public Enumerator(Queue<T> queue)
            {
                this.queue = queue;
                this.version = queue.Version;
                this.current = -1;
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
                
            }
        }

        #endregion
        
    }

}
