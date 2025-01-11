namespace DoAnNhom6.Utilities
{
    public class Function
    {
        public static string TitleSlugGenerationAlias(string title)
        {
            return SlugGenerator.SlugGenerator.GenerateSlug(title);
        }
        public static int _UserId = 0;
        public static string _Username = String.Empty;
        public static string _Email = String.Empty;
        public static string _Message = string.Empty;
        public static string _MessageEmail = string.Empty;
        public static string SHA256Hash(string text)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] result = sha256.ComputeHash(Encoding.ASCII.GetBytes(text));
                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < result.Length; i++)
                {
                    strBuilder.Append(result[i].ToString("x2"));
                }
                return strBuilder.ToString();
            }
        }
        public static string MD5Password(string? text)
        {
            string str = MD5Hash(text);
            for (int i = 0; i <= 5;  i++) 
                str = MD5Hash(str + "-" + str);
            return str;
        }
        public static bool IsLogin()
        {
            if (string.IsNullOrEmpty(Functions._Username) || string.IsNullOrEmpty(Functions._Email) || (Functions._UserId <= 0))
                return false;
            return true; 
        }
    }
}
