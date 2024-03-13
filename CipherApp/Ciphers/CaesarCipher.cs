using System.Text;

namespace CipherApp.Ciphers
{
    public class CaesarCipher
    {
        private int shift;

        public CaesarCipher(int shift)
        {
            this.shift = shift;
        }

        public static string Encrypt(string text, int shift)
        {

            if (shift < 1 || shift > 25)
            {
                throw new ArgumentException("Shift value must be between 1 and 25.");
            }

            StringBuilder result = new StringBuilder();

            foreach (char character in text)
            {
                if (char.IsUpper(character))
                {
                    result.Append((char)(((character - 'A') + shift) % 26 + 'A'));
                }
                else if (char.IsLower(character))
                {
                    result.Append((char)(((character - 'a') + shift) % 26 + 'a'));
                }
                else
                {
                    result.Append(character);
                }
            }

            return result.ToString();
        }

        public static string Decrypt(string text, int shift)
        {

            if (shift < 1 || shift > 25)
            {
                throw new ArgumentException("Shift value must be between 1 and 25.");
            }

            StringBuilder result = new StringBuilder();

            foreach (char character in text)
            {
                if (char.IsUpper(character))
                {
                    result.Append((char)(((character - 'A') - shift + 26) % 26 + 'A'));
                }
                else if (char.IsLower(character))
                {
                    result.Append((char)(((character - 'a') - shift + 26) % 26 + 'a'));
                }
                else
                {
                    result.Append(character);
                }
            }

            return result.ToString();
        }
    }
}
