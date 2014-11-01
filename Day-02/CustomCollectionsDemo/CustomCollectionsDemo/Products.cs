using System;
using System.Collections.Generic;

namespace CustomCollectionsDemo
{
    using System.Collections;

    public class MyCollection<T> : IEnumerable, IEnumerator
    {
        private ArrayList _list = new ArrayList();

        public int Count
        {
            get { return _list.Count; }
        }

        public void Add(T item)
        {
            _list.Add(item);
        }

        public T Get(int index)
        {
            return (T) _list[index];
        }

        public T this[int index]
        {
            get
            {
                return (T)_list[index];
            }
        }


        public IEnumerator GetEnumerator()
        {
            return this;
        }

        private int _index = -1;
        public bool MoveNext()
        {
            ++_index;
            if (_index >= _list.Count)
            {
                Reset();
                return false;
            }
            return true;
        }

        public void Reset()
        {
            _index = -1;
        }

        public object Current
        {
            get { return (T) _list[_index]; }
        }

        //public void Sort(IProductComparer productComparer)
        public void Sort(IItemComparer<T> itemComparer)
        {
            for (int i = 0; i < _list.Count-1; i++)
            {
                for (var j = i + 1; j < _list.Count; j++)
                {
                    var left = (T) _list[i];
                    var right = (T) _list[j];
                    
                    if (itemComparer.Compare(left,right) > 0)
                    {
                        var temp = left;
                        _list[i] = _list[j];
                        _list[j] = temp;
                    }
                    
                }
            }
        }

        public void Sort(CompareItemsDelegate<T> compareItems)
        {
            for (int i = 0; i < _list.Count - 1; i++)
            {
                for (var j = i + 1; j < _list.Count; j++)
                {
                    var left = (T)_list[i];
                    var right = (T)_list[j];

                    if (compareItems(left, right) > 0)
                    {
                        var temp = left;
                        _list[i] = _list[j];
                        _list[j] = temp;
                    }

                }
            }
        }

        public MyCollection<T> Filter(IFilterItemsCriteria<T> criteria)
        {
            var result = new MyCollection<T>();
            foreach (var item in _list)
            {
                var tItem = (T) item;
                if (criteria.IsSatisfiedBy(tItem))
                    result.Add(tItem);
            }
            return result;
        }

        public MyCollection<T> Filter(FilterItemCriteriaDelegate<T> criteria)
        {
            var result = new MyCollection<T>();
            foreach (var item in _list)
            {
                var tItem = (T)item;
                if (criteria(tItem))
                    result.Add(tItem);
            }
            return result;
        }

        public IDictionary<TKey, MyCollection<T>> GroupBy<TKey>(KeySelectorDelegate<T, TKey> keySelector)
        {
            var result = new Dictionary<TKey, MyCollection<T>>();
            foreach(var item in _list)
            {
                var tItem = (T) item;
                var key = keySelector(tItem);
                if (!result.ContainsKey(key))
                    result[key] = new MyCollection<T>();
                result[key].Add(tItem);
            }
            return result;
        } 


    }

    public delegate TKey KeySelectorDelegate<in T, out TKey>(T item);
}