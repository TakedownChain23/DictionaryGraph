using System.Collections;

namespace DictionaryGraph
{
    internal class OrderedSet<T> : ISet<T> where T : notnull
    {
        readonly OrderedDictionary<T, bool> setDictionary = [];
        
        public int Count => setDictionary.Keys.Count;

        public bool IsReadOnly => false;

        public bool Add(T item)
        {
            var result = !Contains(item);
            setDictionary[item] = true;
            return result;
        }

        public void Clear()
        {
            setDictionary.Clear();
        }

        public bool Contains(T item)
        {
            return setDictionary.ContainsKey(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach (var item in this)
            {
                array[arrayIndex] = item;
                arrayIndex++;
            }
        }

        public void ExceptWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return setDictionary.Keys.GetEnumerator();
        }

        public void IntersectWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsSubsetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsSupersetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool Overlaps(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            var result = Contains(item);
            setDictionary.Remove(item);
            return result;
        }

        public bool SetEquals(IEnumerable<T> other)
        {
            if (Count != other.Distinct().Count()) return false;

            return other.All(Contains);
        }

        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public void UnionWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        void ICollection<T>.Add(T item)
        {
            Add(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
