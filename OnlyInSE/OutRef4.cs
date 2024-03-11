public class OutRef4<T, U, V, W> : OutRef<T, U, V>
{
    public OutRef(T t, U u, V v, W w) : base(t, u, v)
    {
        Item4 = w;
    }

    public W Item4 { get; set; }
}