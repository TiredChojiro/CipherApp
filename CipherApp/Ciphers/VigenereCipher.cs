namespace CipherApp.Ciphers
{
    public class VigenereCipher
    {
        private string keyword;

        public VigenereCipher(string keyword)
        {
            this.keyword = keyword.ToUpper();
        }

        public static string Encrypt(string text, string keyword)
        {
            string result = "";
            int j = 0;
            int keywordLength = keyword.Length;

            for (int i = 0; i < text.Length; i++)
            {
                char character = text[i];
                if (Char.IsUpper(character))
                {
                    int shift = keyword[j % keywordLength] - 65;
                    result += (char)((character - 65 + shift) % 26 + 65);
                    j++;
                }
                else if (Char.IsLower(character))
                {
                    int shift = keyword[j % keywordLength] - 65;
                    result += (char)((character - 97 + shift) % 26 + 97);
                    j++;
                }
                else
                {
                    result += character;
                }
            }

            return result;
        }

        public static string Decrypt(string text, string keyword)
        {
            string result = "";
            int j = 0;
            int keywordLength = keyword.Length;

            for (int i = 0; i < text.Length; i++)
            {
                char character = text[i];
                if (Char.IsUpper(character))
                {
                    int shift = keyword[j % keywordLength] - 65;
                    result += (char)((character - 65 - shift + 26) % 26 + 65);
                    j++;
                }
                else if (Char.IsLower(character))
                {
                    int shift = keyword[j % keywordLength] - 65;
                    result += (char)((character - 97 - shift + 26) % 26 + 97);
                    j++;
                }
                else
                {
                    result += character;
                }
            }

            return result;
        }
    }
}
