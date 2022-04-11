using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace ExamApi.Domain.Models
{
    public class TokenModel
    {
        public readonly long TokenNumber;
        public readonly DateTime RegistrationDate;

        public TokenModel(CardModel card)
        {
            TokenNumber = GenerateToken(card);
            RegistrationDate = DateTime.UtcNow;
        }

        public long GenerateToken(CardModel card)
        {
            char[] arrayCardNumbers = card.CardNumber.ToString().ToCharArray();

            for(int i = 0; i < card.Cvv; i++)
            {
                char lastCharNumber = arrayCardNumbers[arrayCardNumbers.Length - 1];
                arrayCardNumbers = arrayCardNumbers.SkipLast(1).ToArray();

                char[] auxArray = new char[arrayCardNumbers.Length + 1];
                for(var j = 0; j < arrayCardNumbers.Length; j++)
                {
                    if(j == 0)
                        auxArray[j] = lastCharNumber;
                    else
                        auxArray[j] = arrayCardNumbers[j - 1];
                }
                auxArray[auxArray.Length - 1] = arrayCardNumbers[arrayCardNumbers.Length - 1];

                arrayCardNumbers = auxArray;

            }
            string response = new string(arrayCardNumbers);

            return Convert.ToInt64(response);
        }
    }
}
