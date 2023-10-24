using Stack.Interfaces;

namespace ArrayBasedStack
{
    public class ArrayBasedStack<T> : IStack<T>
    {
        private readonly List<T> _stack;
        private int _indexOfTop;

        public ArrayBasedStack()
        {
            _stack = new List<T>();
            _indexOfTop = -1;
        }

        public ArrayBasedStack(int size)
        {
            if (size < 0)
            {
                throw new InvalidOperationException();
            }
            _stack = new List<T>(size);
            _indexOfTop = -1;
        }

        public void Clear()
        {
            _stack.Clear();
        }

        public bool Empty()
        {
            return _indexOfTop < 0;
        }

        public T Pop()
        {
            if (_stack.Count > 0)
            {
                var item = _stack[_indexOfTop];
                _stack.RemoveAt(_indexOfTop);
                _indexOfTop--;

                return item;
            }

            throw new InvalidOperationException();
        }

        public void Push(T item)
        {
            _stack.Add(item);
            _indexOfTop++;
        }

        public T? Top()
        {
            if (_indexOfTop < 0)
            {
                throw new InvalidOperationException();
            }

            return _stack[_indexOfTop];
        }
    }
}