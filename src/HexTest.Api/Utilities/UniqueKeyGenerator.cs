using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Collections;

namespace Utilities
{
	public enum KeyType
    {
        Numeric = 1,
        AlphaNumeric = 2,
        AlphaNumeric_With_Pattern = 3,
		Alpha = 4
    }    
	
	public enum PickType
	{
		Anywhere = 1,
		Left = 2,
		Right = 3
	}
	
    public  class UniqueKeyGenerator
    {
        static Random rnd = new Random();
        public static string GenerateKey(KeyType keyType, int KeyLength, string pattern = "")
        {
            string generatedKey = "";

            if (keyType == KeyType.Numeric)
            {
                generatedKey = GenerateUniqueID(KeyType.Numeric, KeyLength);
            }
            else if (keyType == KeyType.AlphaNumeric)
            {
                generatedKey = GenerateUniqueID(KeyType.AlphaNumeric, KeyLength);
            }
            else if (keyType == KeyType.AlphaNumeric_With_Pattern)
            {
                generatedKey = GenrateKeyforPattern(pattern);
            }
			else if (keyType == KeyType.Alpha)
			{
				generatedKey = GenerateUniqueID(KeyType.Alpha, KeyLength);
			}

            return generatedKey;
        }

        
        private static string GenerateUniqueID(KeyType keyTpe, int KeyLength)
        {
            int maxSize = KeyLength;
            //int minSize = 12;
            char[] chars = new char[10];
            string a;
            if (keyTpe == KeyType.Numeric)
                a = "1234567890";
            else if (keyTpe == KeyType.AlphaNumeric)
                a = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			else if (keyTpe == KeyType.Alpha)
				a = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            else
                a = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            chars = a.ToCharArray();
            int size = maxSize;
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            size = maxSize;
            data = new byte[size];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data) { result.Append(chars[b % (chars.Length)]); }

            return result.ToString();
        }


        private static char GenrateRandomAlphaNumericCharacter()
        {
            bool GenrateNext = true;
            int intGenNumber = 0;

            while (GenrateNext)
            {
                intGenNumber = Convert.ToInt32(Math.Round(Convert.ToDouble(rnd.Next(254))));
                // 0 = 48, 9 = 57, A = 65, Z = 90, a = 97, z = 122
                if (intGenNumber >= 65 && intGenNumber <= 90 || intGenNumber >= 48 && intGenNumber <= 57)
                {
                    GenrateNext = false;
                }
                else
                {
                    GenrateNext = true;
                }

            }

            return Convert.ToChar(intGenNumber);
        }

        private static char GenrateRandomNumericCharacter()
        {
            bool GenrateNext = true;
            int intGenNumber = 0;

            while (GenrateNext)
            {
                intGenNumber = Convert.ToInt32(Math.Round(Convert.ToDouble(rnd.Next(254))));
                // 0 = 48, 9 = 57, A = 65, Z = 90, a = 97, z = 122
                if (intGenNumber >= 48 && intGenNumber <= 57)
                {
                    GenrateNext = false;
                }
                else
                {
                    GenrateNext = true;
                }

            }

            return Convert.ToChar(intGenNumber);
        }

        private static string GenrateKeyforPattern(string strPattern)
        {
            string strNewCDKey = String.Empty;

            foreach (char c in strPattern)
            {
                if (c == 'X' || c == 'x')
                {
                    strNewCDKey += GenrateRandomAlphaNumericCharacter();
                }
                else if (c == '0')
                {
                    strNewCDKey += GenrateRandomNumericCharacter();
                }
                else if (c == '-')
                {
                    strNewCDKey += "-";
                }
                else
                {
                    strNewCDKey += c;
                }
            }

            return strNewCDKey;
        }

        // Random Number Function
        public static string PickChars(string value, int keylength, PickType pickType)
        {
            string pickchars = "";

            if (pickType == PickType.Anywhere)
            {
                pickchars = SelectUniqueCharacters(value, keylength, PickType.Left);
            }
            if (pickType == PickType.Left)
            {
                pickchars = SelectUniqueCharacters(value, keylength, PickType.Left);
            }
            if (pickType == PickType.Right)
            {
                pickchars = SelectUniqueCharacters(value , keylength, PickType.Right);
            }

            return pickchars;
        }

        private static string SelectUniqueCharacters(string value, int KeyLength, PickType pickType)
        {
            string uniqueid = "";
            value = value.Replace(" ", "_");
             if (pickType == PickType.Left)
                    uniqueid = value.Substring(0, KeyLength);
             else if (pickType == PickType.Right)
                    uniqueid = value.Substring(value.Length - KeyLength);
             else if (pickType == PickType.Anywhere)
             {
                 ArrayList al = new ArrayList();
                 string character = "";
                 for (int i = 0; i < KeyLength; i++)
                 {
                    do
                    {
                            int index = rnd.Next(0, value.Length);
                            character = value.ToCharArray()[index].ToString();
                            al.Add(character);

                    }
                    while (uniqueid.IndexOf(character) != -1);
                    uniqueid += character;
                 }

             }

            return uniqueid;

        }
 
    }
}
