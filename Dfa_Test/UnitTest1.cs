
using DFAProject;
using FluentAssertions;
using Xunit;
namespace Dfa_Test
{ 
    public class DfaUnitTests
    {
        private readonly DFa _dfa;

        public DfaUnitTests()
        {
            _dfa = new DFa();
        }

        [Fact]
        public void ProcessString_ShouldResetStateBetweenCalls()
        {
            _dfa.ProcessString("1000").Should().BeFalse();
            _dfa.ProcessString("1001").Should().BeFalse();
            _dfa.ProcessString("010").Should().BeFalse();
            _dfa.ProcessString("10").Should().BeFalse();
            _dfa.ProcessString("1001001").Should().BeTrue();
            _dfa.ProcessString("101110101").Should().BeTrue();
            _dfa.ProcessString("10101").Should().BeTrue();
            _dfa.ProcessString("111").Should().BeTrue();

        }
        [Fact] 
        public void ProcessChar_InvalidCharacter()
        {
            char invalidChar = 'A'; 
            var act = () => _dfa.ProcessChar(invalidChar);

            act.Should().Throw<ArgumentException>()
               .WithMessage("Input must be a binary character ('0' or '1').");
        }
        [Fact]
        public void ProcessString_InvalidCharacter_ShouldThrow()
        {
            string invalidInput = "10123"; 
            var act = () => _dfa.ProcessString(invalidInput);

            act.Should().Throw<ArgumentException>()
               .WithMessage("Input must be a binary character ('0' or '1').");
        }
    }
}