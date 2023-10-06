using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using String = System.String;

namespace stringCalculator
{
    public class stringCalculator
    {
        bool ownDelimiter;
        public bool greaterThanOneThousand(int number)
        {
            if (number <= 1000) { return true; } else { return false; }
        }

        public void throwException(String cadena)
        {
            if (cadena.Length > 0)
            {
                throw new Exception($"Negatives not allowed: {cadena}");
            }

        }

        public (char[],bool) selectDelimiter(String numbers, bool ownDelimiter)
        {
            char[] chars = numbers.ToCharArray();
            char delimiter = ' ';
            if (chars[0].Equals('/') && chars[1].Equals('/'))
            {
                delimiter = chars[2];
                ownDelimiter = true;
            }
            char[] delimeters = {',','\n',delimiter};
            return (delimeters, ownDelimiter);

        }

        public bool negativesNumbers(int number)
        {
            if (number < 0) { return true; } else { return false; }
        }


        public int add(String numbers)
        {
            int result = 0;
            String cadena = "";
            if (numbers.Length == 0) { return 0; }

            var (delimiters, ownDelimiter) = selectDelimiter(numbers, false);

            String[] numbersArray = numbers.Split(delimiters);


            if (ownDelimiter)
            {
                for (int i = 2; i < numbersArray.Length; i++)
                {
                    if (Int32.Parse(numbersArray[i]) < 0) { cadena += numbersArray[i] + " "; }
                    if (greaterThanOneThousand(Int32.Parse(numbersArray[i]))) { result += Int32.Parse(numbersArray[i]); }
                }
            }               
            else
            {
                foreach (String number in numbersArray)
                {
                    if (negativesNumbers(Int32.Parse(number))) { cadena += number + " "; }
                    if (greaterThanOneThousand(Int32.Parse(number))) { result += Int32.Parse(number); }
                }
            }

            throwException(cadena);

            return result;
        }


    }
}