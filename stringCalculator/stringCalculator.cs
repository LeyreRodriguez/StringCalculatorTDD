using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using String = System.String;

namespace stringCalculator
{
    public class stringCalculator
    {
        public int add(String numbers)
        {
            int result = 0;
            String cadena = "";
            if (numbers.Length == 0) { return 0; }
           
            char delimiter=' ';
            char[] chars = numbers.ToCharArray();
           
            
            if (chars[0].Equals('/') && chars[1].Equals('/'))
            {
                delimiter = chars[2];
              
                
            }

            String[] numbersArray = numbers.Split(',','\n', delimiter);

            
           

            if (chars[0].Equals('/') && chars[1].Equals('/'))
            {
                for (int i = 2; i < numbersArray.Length; i++)
                {
                    

                    if (Int32.Parse(numbersArray[i]) < 0)
                    {
                        cadena += numbersArray[i] + " ";
                    }
                    if (Int32.Parse(numbersArray[i]) <= 1000)
                    {
                        result += Int32.Parse(numbersArray[i]);
                    }
                }
                
            } else
            {
                foreach (String number in numbersArray)
                {
               
                  
                    if (Int32.Parse(number) < 0)
                    {
                        cadena += number + " ";
                    }
                    if (Int32.Parse(number) <= 1000)
                    {
                        result += Int32.Parse(number);
                    }

                }
            }

            if (cadena.Length > 0)
            {
                throw new Exception($"Negatives not allowed: {cadena}");
            }

            
            return result;
        }



      
    }
}