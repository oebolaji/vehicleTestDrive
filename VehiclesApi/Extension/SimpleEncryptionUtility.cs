using System.Text;

namespace VehiclesApi.Extension
{
    public static class SimpleEncryptionUtility
    {
        public static string EncryptText(string text)
        {
            try
            {
                var textByteArray = Encoding.UTF8.GetBytes(text);
                var encodedText = Convert.ToBase64String(textByteArray);
                var hashKeyByte = Encoding.UTF8.GetBytes("ydgnskc8472bd");
                var encodedHashKey = Convert.ToBase64String(hashKeyByte);
                //STRIP OFF ALL = SIGN AT THE END
                var cleanHashKeyArray = encodedHashKey.Split("==");
                var strippedOffSymbols = "==";
                encodedText = $"{cleanHashKeyArray[0]}y{encodedText}={strippedOffSymbols}";
                var encodedTextByte = Encoding.UTF8.GetBytes(encodedText);
                var encryptedText = Convert.ToBase64String(encodedTextByte);

                return $"e{encryptedText}=";
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public static string DecryptText(string encryptedText)
        {
            try
            {
                encryptedText = encryptedText.Substring(1, (encryptedText.Length - 2));
                var encryptedTextByte = Convert.FromBase64String(encryptedText);
                encryptedText = Encoding.UTF8.GetString(encryptedTextByte);
                var hashKeyByte = Encoding.UTF8.GetBytes("ydgnskc8472bd");
                var encodedHashKey = Convert.ToBase64String(hashKeyByte);
                var splittedDirtyEncryptedText = encryptedText.Split($"{(encodedHashKey.Split("=="))[0]}y");
                var cleanEncodedText = (splittedDirtyEncryptedText[1]).Substring(0, (splittedDirtyEncryptedText[1]).Length - 3);
                var cleanTextByte = Convert.FromBase64String(cleanEncodedText);
                var cleanText = Encoding.UTF8.GetString(cleanTextByte);

                return cleanText;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

    }
}
