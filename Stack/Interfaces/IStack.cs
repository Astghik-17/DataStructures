namespace Stack.Interfaces
{
    public interface IStack<T>
    {
        public T? Top();
        public T Pop();
        public void Push(T item);
        public bool Empty();
        public void Clear();
    }
}
