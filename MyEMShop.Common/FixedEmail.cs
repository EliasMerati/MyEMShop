namespace MyEMShop.Common
{
    public class FixedEmail
    {
        public static string Fix(string email)
        {
            return email.Trim().ToLower();
        }
    }
}
