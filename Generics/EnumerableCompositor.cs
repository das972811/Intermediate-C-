using System.Collections;

namespace GenericsDemo;

public class EnumerableCompositor<T> : IEnumerable<T>
{
    private List<IEnumerable<T>> _collections = null!;

    public EnumerableCompositor()
    {
        _collections = new List<IEnumerable<T>>();
    }

    public EnumerableCompositor(IEnumerable<IEnumerable<T>> collections)
    {
        _collections = collections.ToList();
    }

    public void Add(IEnumerable<T> collection)
    {
        _collections.Add(collection);
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}