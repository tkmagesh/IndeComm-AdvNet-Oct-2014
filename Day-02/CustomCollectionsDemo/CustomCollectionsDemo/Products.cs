using System;
using System.Collections.Generic;

namespace CustomCollectionsDemo
{
    using System.Collections;

    public class Products : IEnumerable, IEnumerator
    {
        private ArrayList _list = new ArrayList();

        public int Count
        {
            get { return _list.Count; }
        }

        public void Add(Product product)
        {
            _list.Add(product);
        }

        public Product Get(int index)
        {
            return (Product) _list[index];
        }

        public Product this[int index]
        {
            get
            {
                return (Product)_list[index];
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
            get { return (Product) _list[_index]; }
        }
    }
}