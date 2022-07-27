using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class Part : IComparable<Part>
    {
        public string Number { get; set; }

        public int Sum { get; set; }

        public override string ToString()
        {
            return "Sum: " + Sum + "   Number: " + Number;
        }

        // Default comparer for Part type.
        public int CompareTo(Part comparePart)
        {
            // A null value means that this object is greater.
            if (comparePart == null)
                return 1;

            if (Sum == comparePart.Sum)
                return Number.CompareTo(comparePart.Number);

            else
                return this.Sum.CompareTo(comparePart.Sum);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string input = "2022 70 123    3344 13";
            // " 2022 70 123    3344 13" 
            var result = Order(input);
            Console.WriteLine(result);
        }
        static string Order(string input)
        {
            var collectionNumbers = new List<Part>();
            var arrayNumber = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            foreach (var item in arrayNumber)
            {
                var validNumber = int.TryParse(item, out var num);

                if (!validNumber)
                {
                    throw new Exception("Invalid Number");
                }

                var sumNumber = GetNumberSum(num);

                collectionNumbers.Add(new Part() { Number = item, Sum = sumNumber });
            }

            collectionNumbers.Sort();

            var result = collectionNumbers
                .Select(x => x.Number)
                .ToList();

            string outputMessage = string.Join(' ', result);

            return outputMessage;
        }

        static int GetNumberSum(int num)
        {
            var sumNumber = 0;
            while (num > 0)
            {
                int lastDigitNumber = num % 10;
                num = num / 10;
                sumNumber += lastDigitNumber;
            }

            return sumNumber;
        }
    }
}
