using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class Part : IComparable<Part>
    {
        public string Number { get; set; }

        public long Sum { get; set; }

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
            string input = "3 16 9 38 95 1131268 49455 347464 59544965313 496636983114762 85246814996697";
            // " 2022 70 123    3344 13" 
            // 3 16 9 38 95 1131268 49455 347464 59544965313 496636983114762 85246814996697
            var result = Order(input);
            Console.WriteLine(result);
        }
        static string Order(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return "is null or empty";
            }
            else
            {
                var collectionNumbers = new List<Part>();
                var arrayNumber = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                foreach (var item in arrayNumber)
                {
                    var validNumber = long.TryParse(item, out var num);

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
        }

        static long GetNumberSum(long num)
        {
            long sumNumber = 0;
            while (num > 0)
            {
                long lastDigitNumber = num % 10;
                num = num / 10;
                sumNumber += lastDigitNumber;
            }

            return sumNumber;
        }
    }
}
