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
      
        public int CompareTo(Part comparePart)
        {
            if (comparePart == null)
                return 1;

            if (Sum == comparePart.Sum)
                return this.Number.CompareTo(comparePart.Number);

            else
                return this.Sum.CompareTo(comparePart.Sum);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string input = "45 34 24 108 76 58 64 130 80";
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
