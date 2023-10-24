using Stack.Interfaces;

namespace LinkedListBasedStack
{
    public class LinkedListBasedStack<T> : IStack<T>
    {
        private readonly LinkedList<T> _stack;

        public LinkedListBasedStack()
        {
            _stack = new LinkedList<T>();
        }

        public void Clear()
        {
            _stack.Clear();
        }

        public bool Empty()
        {
            return !_stack.Any();
        }

        public T Pop()
        {
            if (_stack.Any())
            {
                var item = _stack.First();
                _stack.RemoveFirst();

                return item;
            }

            throw new InvalidOperationException();
        }

        public void Push(T item)
        {
            _stack.AddFirst(item);
        }

        public T? Top()
        {
            return _stack.Any() ? _stack.First() : default;
        }
    }
}