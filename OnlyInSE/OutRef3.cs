public class OutRef3<T, U, V> : OutRef<T, U>
{
    public OutRef(T t, U u, V v) : base(t, u)
    {
        Item3 = v;
    }

    public V Item3 { get; set; }
}