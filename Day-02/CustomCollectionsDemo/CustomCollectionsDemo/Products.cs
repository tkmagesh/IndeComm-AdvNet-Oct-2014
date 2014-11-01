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

        public void Sort(IProductComparer productComparer)
        {
            for (int i = 0; i < _list.Count-1; i++)
            {
                for (var j = i + 1; j < _list.Count; j++)
                {
                    var left = (Product) _list[i];
                    var right = (Product) _list[j];
                    
                    if (productComparer.Compare(left,right) > 0)
                    {
                        var temp = left;
                        _list[i] = _list[j];
                        _list[j] = temp;
                    }
                    
                }
            }
        }

        public void Sort(CompareProductsDelegate compareProducts)
        {
            for (int i = 0; i < _list.Count - 1; i++)
            {
                for (var j = i + 1; j < _list.Count; j++)
                {
                    var left = (Product)_list[i];
                    var right = (Product)_list[j];

                    if (compareProducts(left, right) > 0)
                    {
                        var temp = left;
                        _list[i] = _list[j];
                        _list[j] = temp;
                    }

                }
            }
        }
    }
}