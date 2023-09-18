using System.Collections;
using System.Data;

namespace GenericsDemo;

public static class EnumerableCompositor
{
    public static EnumerableCompositor<T> Create<T>(params IEnumerable<T>[] collections)
    {
        return new EnumerableCompositor<T>(collections);
    }
}

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
        foreach (var collection in _collections)
        {
            foreach(var item in collection)
            {
                yield return item;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public TCollection To<TCollection>() where TCollection : ICollection<T>, new()
    {
        var collection = new TCollection();

        foreach(var item in this)
        {
            collection.Add(item);
        }

        return collection;
    }
}