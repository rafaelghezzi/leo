using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Leo.Service.Password
{
    public class PasswordService
    {
        public static string New()
        {
            StringBuilder passwd = new StringBuilder();

            var upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var lowerCase = "abcdefghijklmnopqrstuvwxyz";
            var numbers = "0123456789";
            var special = "@#_-!";

            var random = new Random();

            passwd.Append(new string(Enumerable.Repeat(lowerCase, 4).Select(s => s[random.Next(s.Length)]).ToArray()));
            passwd.Append(new string(Enumerable.Repeat(upperCase, 4).Select(s => s[random.Next(s.Length)]).ToArray()));
            passwd.Append(new string(Enumerable.Repeat(numbers, 5).Select(s => s[random.Next(s.Length)]).ToArray()));
            passwd.Append(new string(Enumerable.Repeat(special, 2).Select(s => s[random.Next(s.Length)]).ToArray()));

            return new string(passwd.ToString().ToCharArray().OrderBy(s => (random.Next(2) % 2) == 0).ToArray());
        }

        public static bool Validate(string password)
        {
            Regex rx = new Regex("((?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*?[@#_!-]).{15,20})");
            Match match = rx.Match(password);

            if (match.Success)
                return true;

            return false;
        }
    }
}
