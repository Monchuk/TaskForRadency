using System;
using System.Collections.Generic;

namespace Test
{
    public class Part: IComparable<Part>
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

            else
                return this.Sum.CompareTo(comparePart.Sum);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string input = " 45 34 24 108 76 58 64  130 80 ";
                          // " 2022 70 123    3344 13" 
            Order(input);
        }
        static string Order(string input)
        {
            List<Part> collectionNumbers = new List<Part>();  // створюєм колекцію для зберігання чила та його суми
            string[] arrayNumber = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);// строку чисел записуєм в масив з цих чисел
            
            foreach (var item in arrayNumber)
            {
                int num = Int32.Parse(item);
                int SumNumber = 0;
                while (num > 0)// в циклі шукаєм суму числа 
                {
                    int lastDigitNumber = num % 10;
                    num = num / 10;
                    SumNumber += lastDigitNumber;
                }
                collectionNumbers.Add(new Part() { Number = item, Sum = SumNumber });  //записуєм число і його суму в колекцію                                                      
            }
            Console.WriteLine();

            collectionNumbers.Sort(); // сортуєм колекцію по сумі

            foreach (Part aPart in collectionNumbers)
            {
                Console.WriteLine(aPart);
            }

            for (int i = 0; i < arrayNumber.Length; i++) // відсортовані данні переводим в масив чисел
            {
                arrayNumber[i] = collectionNumbers[i].Number;
            }

            Console.WriteLine("\n");

            string outputMessage = String.Join(' ',arrayNumber);// масив чисел переводим в строку типу string
            Console.WriteLine(outputMessage);
            return outputMessage; // вертаєм готову строку відсортованих чисел
        }
    }
}
