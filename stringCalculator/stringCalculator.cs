using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using String = System.String;

namespace stringCalculator
{
    public class stringCalculator
    {
        bool ownDelimiter;
        private bool lessThanOneThousand(int number)
        {

            return number <= 1000;
        }
            

        private void ThrowExceptionForNegativesNumbers(String[] numbersArray)
        {
            var negativeNumbers = numbersArray.Select(n => Int32.Parse(n)).Where( n => n < 0).ToArray();
            if (negativeNumbers.Any())
            {
                throw new Exception($"Negatives not allowed: {string.Join(" ", negativeNumbers)}");
            }
        }

        private (char[], bool,String) selectDelimiter(String numbers)
        {
            char[] delimiters = { ',', '\n' };
            bool ownDelimiter = false;

            if(numbers.StartsWith("//")) 
            {
               
                ownDelimiter = true;
                
                delimiters = new[] { numbers[2] , ',' , '\n' };
                numbers = numbers.Substring(4);
               
            }
            
            return (delimiters, ownDelimiter,numbers);

        }
     

        private IEnumerable<int> calculateResult(bool ownDelimiter, String[] numbersArray)
        {

            return numbersArray.Where(n => ownDelimiter || lessThanOneThousand(Int32.Parse(n))).Select(n => Int32.Parse(n));
        }

        private (bool, string[]) parsearString(string numbers)
        {
            var (delimiters, ownDelimiter, cadenaNormalizada) = selectDelimiter(numbers);
            string[] numbersArray = cadenaNormalizada.Split(delimiters);
            ThrowExceptionForNegativesNumbers(numbersArray);
           return (ownDelimiter, numbersArray);
        }

         
        public int add(String numbers)
        {
           
           if(isEmpty(numbers)) return 0;

           var (delimiterUsed, array) = parsearString(numbers);

            return calculateResult(delimiterUsed, array).Sum();

        }

        public bool isEmpty(String numbers)
        {
            return string.IsNullOrEmpty(numbers);
        }


    }
}