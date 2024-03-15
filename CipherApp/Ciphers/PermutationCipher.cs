using System.Text;

namespace CipherApp.Ciphers
{
    public class PermutationCipher
    {

        public static string Encrypt(string plaintext, int[] permutationKey)
        {
            int length = permutationKey.Length;
            int numOfRows = (int)Math.Ceiling((double)plaintext.Length / length);
            char[,] matrix = new char[numOfRows, length];

       
            int index = 0;
            for (int i = 0; i < numOfRows; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (index < plaintext.Length)
                        matrix[i, j] = plaintext[index++];
                    else
                        matrix[i, j] = ' '; 
                }
            }


            string ciphertext = "";
            foreach (int column in permutationKey)
            {
                for (int row = 0; row < numOfRows; row++)
                {
                    ciphertext += matrix[row, column - 1]; 
                }
            }

            return ciphertext;
        }


        public static string Decrypt(string ciphertext, int[] permutationKey)
        {
            int length = permutationKey.Length;
            int numOfRows = ciphertext.Length / length;
            char[,] matrix = new char[numOfRows, length];


            int index = 0;
            foreach (int column in permutationKey)
            {
                for (int row = 0; row < numOfRows; row++)
                {
                    matrix[row, column - 1] = ciphertext[index++]; 
                }
            }


            string plaintext = "";
            for (int i = 0; i < numOfRows; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    plaintext += matrix[i, j];
                }
            }

            return plaintext.Trim(); 
        }
    }
}
