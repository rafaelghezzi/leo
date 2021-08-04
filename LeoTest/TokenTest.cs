using Leo.Service.Token;
using Xunit;

namespace LeoTest
{
    public class TokenTest
    {
        [Fact]
        public void Token_Validate_NotEmpty()
        {
            var result = TokenService.GenerateToken();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void Token_Validate_NotNull()
        {
            var result = TokenService.GenerateToken();
            Assert.NotNull(result);
        }

        [Fact]
        public void Token_Validate_DoesNotContainSpace()
        {
            var result = TokenService.GenerateToken();
            Assert.DoesNotContain(" ", result);
        }

    }
}
