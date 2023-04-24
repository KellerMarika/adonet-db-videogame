using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    internal static class Validation
    {

        //devo fare una f di  validazione personalizzata anche per data e numero 
  
        public static bool Validatestring (this string paramToValidate, bool isEmpty, bool toInt, bool toDate, int?  minNum,int? maxNum)
        {

            bool result = true;

            if (!isEmpty && string.IsNullOrWhiteSpace(paramToValidate))
            {
                Console.WriteLine($"'{paramToValidate}' non è un dato valido perchè vuoto  --- FAIL");
                result = false;
            }
            else if (minNum != null && paramToValidate.Length < minNum)
            {
                Console.WriteLine($"'{paramToValidate}' non è un dato valido perchè formato da - di {minNum} caratteri --- FAIL");
                result = false;
            }
            else if (maxNum != null && paramToValidate.Length > maxNum)
            {
                Console.WriteLine($"'{paramToValidate}' non è un dato valido perchè formato da + di {maxNum} caratteri --- FAIL");
                result = false;
            }
            else if (toInt)
            {

                //converte stringa in numero se non è convertibile restituisce 0
                int intValue = int.TryParse(paramToValidate, out intValue) ? intValue : 0;
                //converto il numero in booleano
                bool boolValue = Convert.ToBoolean(intValue);
                if (!boolValue)
                {
                    Console.WriteLine($"'{paramToValidate}' non è un dato valido perchè non è un numero --- FAIL");
                    result = false;
                }
            }else if (toDate)
            {
                DateTime dataValue;
                result = DateTime.TryParse(paramToValidate, out dataValue)? true: false;
                if (!result) Console.WriteLine($"'{paramToValidate}' non è una data valida --- FAIL");
            }
            return result;
        }
    }
}
