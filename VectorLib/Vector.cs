using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace VectorLib
{
    public class Vector<T> : IEnumerable<T>
    {
        private int itemCount;
        private T[] items;

        public Vector(int capaciteit = 1)
        {
            itemCount = 0;
            items = new T[capaciteit];
        }

        public void PushBack(T item)
        {
            if (itemCount == items.Length)
            {
                Grow();
            }

            items[itemCount] = item;
            itemCount++;
        }

        public void PopBack()
        {
            if (itemCount > 0)
                itemCount--;
        }

        public T GetItem(int index)
        {
            if (index < itemCount)
            {
                return items[index];
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        private void Grow()
        {
            // Array voorziet zelf een methode om capaciteit te veranderen
            Array.Resize(ref items, items.Length * 2);

            // Of, als je het manueel wilt doen:
            //T[] tmp = new T[items.Length * 2];
            //for (int i = 0; i < itemCount; i++)
            //{
            //    tmp[i] = items[i];
            //}
            //items = tmp;
        }

        public override string ToString()
        {
            return string.Join(", ", items.Take(itemCount));
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Enumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Enumerator();
        }

        private IEnumerator<T> Enumerator()
        {
            // je kan een eigen Enumerator schrijven voor je vector, maar je kan ook de compiler het werk voor je laten doen met yield return
            for (int i = 0; i < itemCount; i++)
            {
                yield return items[i];
            }
        }

        //// Ter referentie; het is mogelijk je eigen Enumerator te schrijven die IEnumerator<T> implementeert.
        //// Om deze te gebruiken, schrijf je return new VectorEnumerator<T>(this); in GetEnumerator van Vector
        //// Code deels gebaseerd op de implementatie van Enumeration in de List<T> klasse van C#
        //// https://github.com/dotnet/corefx/blob/master/src/Common/src/CoreLib/System/Collections/Generic/List.cs
        //public class VectorEnumerator<T> : IEnumerator<T>
        //{
        //    private readonly Vector<T> _vector;
        //    private int _index;
        //    private T _current;
        //    public VectorEnumerator(Vector<T> vector)
        //    {
        //        _vector = vector;
        //        Reset();
        //    }
        //    public T Current => _current;

        //    object IEnumerator.Current => _current;

        //    public void Dispose()
        //    {
        //        // niets om te disposen
        //    }

        //    public bool MoveNext()
        //    {
        //        try
        //        {
        //            _current = _vector.GetItem(_index);
        //            _index++;
        //            return true;
        //        }
        //        catch (ArgumentOutOfRangeException)
        //        {
        //            return false;
        //        }
        //    }

        //    public void Reset()
        //    {
        //        _index = 0;
        //        _current = default;
        //    }
        //}
    }
}
