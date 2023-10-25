using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexersAndProperties
{
    public class SquareArray
    {
        private int[] array;

        public SquareArray(int size)
        {
            array = new int[size];
        }

        // Индексатор для массива, возводит в квадрат передаваемое значение
        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < array.Length)
                {
                    return array[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (index >= 0 && index < array.Length)
                {
                    array[index] = value * value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
    }

}
