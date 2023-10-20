using System.Reflection.Metadata.Ecma335;

namespace stringCalculator
{
    public class stringCalculator
    {
        private bool checkString = false;

        public int add(String numbers)
        {
            List<int> numberArray = GetOnlyValidNumbers(FromStringToIntList(numbers));
            
            

            return numberArray.Sum();
        }
        private List<int> GetOnlyValidNumbers(List<int> numberArray)
        {
            ThrowExceptionForNegativesNumbers(numberArray);

            numberArray.RemoveAll(number => IsGreaterThanOneThousand(number));
            return numberArray;

        }

        private bool IsGreaterThanOneThousand(int number)
        {
            return number >= 1000;
        }
        private bool EmptyString(String numbers)
        {
            if (numbers.Length == 0) return true;
            
            
            return false;
        }

        private List<int> FromStringToIntList(String numbers)
        {
            if (EmptyString(numbers)) return new List<int> { 0 }; 

            String normalizeNumbers = NormalizeString(numbers);

            return normalizeNumbers.Split(getDelimiters(numbers)).Select(int.Parse).ToList();
        }

        private void ThrowExceptionForNegativesNumbers(List<int> numbersList)
        {
            var negativeNumbers = numbersList.Select(n => n).Where(n => n < 0).ToArray();
            if (negativeNumbers.Any())
            {
                throw new Exception($"Negatives not allowed: {string.Join(" ", negativeNumbers)}");
            }
        }

        private char[] getDelimiters(String numbers)
        {
            char[] delimiterChars;

            if (checkString) {
                delimiterChars = new char[] { ',', '\n', numbers[2] };
            }
            else
            {
                delimiterChars = new char[] { ',', '\n' };
            }
            

            return delimiterChars;
        }

       


        private String NormalizeString(String numbers)
        {
            if (numbers.StartsWith("//"))
            {
                checkString = true;
                return numbers.Substring(4);
            }
            return numbers;
        }

    }
}