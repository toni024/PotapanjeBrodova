using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public class RedFiksneDuljine<T> : Queue<T>
    {
        public RedFiksneDuljine(int maksimalnaDuljina)
        {
            this.maksimalnaDuljina = maksimalnaDuljina;
        }

        public new void Enqueue(T element)
        {
            base.Enqueue(element);
            while (Count > maksimalnaDuljina)
                Dequeue();
        }


        private int maksimalnaDuljina;
    }
}
