
using PDaProject;

namespace PDATests
{
    public class PDATests
    {
        private readonly PDA _pda;
        public PDATests()
        {
            _pda = new PDA();
        }
        [Theory]
        [InlineData("()", true)]
        [InlineData("(())", true)]
        [InlineData("()()", true)]
        [InlineData("((()()))", true)]
        [InlineData("", true)]
        [InlineData("(", false)]
        [InlineData(")", false)]
        [InlineData("(()", false)]
        [InlineData("())", false)]
        [InlineData("(a)", false)]
        [InlineData(")(", false)]
        public void Test_Balanced(string input, bool expected)
        {
            var result = _pda.IsStringAccepted(input, PDA.LanguageType.BalancedParentheses);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("ab", true)]
        [InlineData("aabb", true)]
        [InlineData("aaabbb", true)]
        [InlineData("a", false)]
        [InlineData("b", false)]
        [InlineData("aab", false)]
        [InlineData("abb", false)]
        [InlineData("aba", false)]
        [InlineData("ba", false)]
        [InlineData("", false)]
        [InlineData("aabbb", false)]
        [InlineData("aaabb", false)]
        [InlineData("abc", false)]
        public void Test_AnBn(string input, bool expected)
        {
            var result = _pda.IsStringAccepted(input, PDA.LanguageType.AnBn);
            Assert.Equal(expected, result);
        }
    }
}