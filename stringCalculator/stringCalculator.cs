namespace stringCalculator
{
    public class stringCalculator
    {
        public int add(String numbers)
        {
            int result = 0;
            if (numbers.Length == 0) { return 0; }

            String[] numbersArray = numbers.Split(',');

            if (numbersArray.Length <= 2)
            {
                foreach (String number in numbersArray)
                {
                    result += Int32.Parse(number);
                }

            }
            
            return result;
        }



      
    }
}