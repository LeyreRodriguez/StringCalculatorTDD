namespace stringCalculator
{
    public class stringCalculator
    {
        public int add(String numbers)
        {
            int result = 0;
            if (numbers.Length == 0) { return 0; }
            char[] delimitedChars = { ',' , '\n'};

            String[] numbersArray = numbers.Split(delimitedChars);

            
            foreach (String number in numbersArray)
            {
                result += Int32.Parse(number);
            }

            
            
            return result;
        }



      
    }
}