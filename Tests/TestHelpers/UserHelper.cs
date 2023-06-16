using ReFactor.Models;
using System.Text;
using System;

namespace Tests.TestHelpers
{
    public static class UserHelper
    {

        public static User GetUser()
        {
            return new User("dipesh");
        }

        public static string GenerateRandomString(int length) {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var sb = new StringBuilder(length);

            for (int i = 0; i < length; i++) {
                sb.Append(chars[random.Next(chars.Length)]);
            }

            return sb.ToString();
        }
    }
}
