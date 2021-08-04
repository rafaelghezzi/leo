using Leo.Service.Password;
using System.Text.RegularExpressions;
using Xunit;

namespace LeoTest
{
    public class PasswordTest
    {
        [Fact]
        public void Password_Validate_NotEmpty()
        {
            var result = PasswordService.New();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void Password_Validate_NotNull()
        {
            var result = PasswordService.New();
            Assert.NotNull(result);
        }

        [Fact]
        public void Password_Use_LowerCase()
        {
            var result = PasswordService.New();

            Regex rx = new Regex("(?=.*[a-z])");
            Match match = rx.Match(result);

            Assert.True(match.Success);
        }

        [Fact]
        public void Password_Use_UpperCase()
        {
            var result = PasswordService.New();

            Regex rx = new Regex("(?=.*[A-Z])");
            Match match = rx.Match(result);

            Assert.True(match.Success);
        }
    }
}
