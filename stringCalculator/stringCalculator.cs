using System;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;
using String = System.String;

namespace stringCalculator
{
    public class stringCalculator
    {
        bool ownDelimiter;

        public int add(String numbers)
        {

            //if (isEmpty(numbers)) return 0;
            return parseListStringToListInt(IsolateNumbers(numbers)).Sum() ;

        }

        private String[] IsolateNumbers(String numbers)
        {
            if (!isEmpty(numbers))
            {
                var (delimiters, ownDelimiter, cadenaNormalizada) = selectDelimiter(numbers);
                string[] numbersArray = cadenaNormalizada.Split(delimiters);
                ThrowExceptionForNegativesNumbers(numbersArray);

                return numbersArray;
            }
            
            return new String[] {"0"};
            
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
     

        private int[] parseListStringToListInt( String[] numbersArray)
        {

            
            return keepJustLessThanOneThousand(numbersArray.Select(int.Parse).ToArray());
        }

        private int[] keepJustLessThanOneThousand(int[] numbersArray)
        {
            
            return numbersArray.Where(number => number <= 1000).ToArray();
        }






        private bool isEmpty(String numbers)
        {
            return string.IsNullOrEmpty(numbers);
        }


    }
}