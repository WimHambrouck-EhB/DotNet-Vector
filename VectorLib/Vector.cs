using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace VectorLib
{
    public class Vector<T>: IEnumerable<T>
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
            if(itemCount > 0)
                itemCount--;
        }

        public T GetItem(int index)
        {
            return items[index];
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
            for (int i = 0; i < itemCount; i++)
            {
                yield return items[i];
            }
        }
    }
}
