using System;
using VectorLib;

namespace Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new Vector<int>();
            numbers.PushBack(12);
            numbers.PushBack(13);
            numbers.PushBack(11);
            numbers.PushBack(19);
            numbers.PopBack();

            Console.WriteLine(numbers);

            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
