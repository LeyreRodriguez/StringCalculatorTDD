using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using String = System.String;

namespace stringCalculator
{
    public class stringCalculator
    {
        bool ownDelimiter;
        private bool greaterThanOneThousand(int number)
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
     

        private int calculateResult(bool ownDelimiter, String[] numbersArray)
        {
            return numbersArray.Where(n => ownDelimiter || greaterThanOneThousand(Int32.Parse(n))).Select(n => Int32.Parse(n)).Sum();
        }


        public int add(String numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var (delimiters, ownDelimiter, cadenaNormalizada) = selectDelimiter(numbers);
            string[] numbersArray = cadenaNormalizada.Split(delimiters);
            ThrowExceptionForNegativesNumbers(numbersArray);
            return calculateResult(ownDelimiter, numbersArray);
            
        }


    }
}