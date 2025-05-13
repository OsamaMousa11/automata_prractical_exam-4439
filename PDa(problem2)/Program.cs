using System;
using System.Collections.Generic;

namespace PDaProject
{
    public class PDA
    {
        public enum LanguageType
        {
            BalancedParentheses,
            AnBn
        }

        public  bool IsStringAccepted(string input, LanguageType languageType)
        {
            Stack<char> stack = new Stack<char>();

            switch (languageType)
            {
                case LanguageType.BalancedParentheses:
                    return isBalanced(input, stack);

                case LanguageType.AnBn:
                    return CheckAnBn(input, stack);

                default:
                    throw new ArgumentException("Unsupported language type");
            }
        }

        public  bool isBalanced(string input, Stack<char> stack)
        {
            
            foreach (char c in input)
            {
                if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    if (stack.Count == 0 || stack.Pop() != '(')
                    {
                        return false;
                    }
                }
                else
                {
      
                    return false;
                }
            }

            return stack.Count == 0;
        }

        private bool CheckAnBn(string input, Stack<char> stack)
        {
            bool seenB = false;

            foreach (char c in input)
            {
                if (c == 'a')
                {
                    if (seenB)
                    {
                        return false;
                    }
                    stack.Push(c);
                }
                else if (c == 'b')
                {
                    seenB = true;
                    if (stack.Count == 0 || stack.Pop() != 'a')
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return stack.Count == 0 && seenB;
        }

        public static void Main(string[] args)
        {  
            PDA pda=new PDA();
            Console.WriteLine("Testing Balanced Parentheses:");
            string[] Tests = { "()", "(())", "()()", "(()", "())", "(a)", };
            foreach (string test in Tests)
            {
                bool accepted = pda.IsStringAccepted(test, LanguageType.BalancedParentheses);
                Console.WriteLine($"\"{test}\": {(accepted ? "Accepted" : "Rejected")}");
            }

            Console.WriteLine("\nTesting a^n b^n Language:");
            string[] anbnTests = { "ab", "aabb", "aaabbb", "aab", "abb", "a", "b", "aba","" };
            foreach (string test in anbnTests)
            {
                bool accepted = pda.IsStringAccepted(test, LanguageType.AnBn);
                Console.WriteLine($"\"{test}\": {(accepted ? "Accepted" : "Rejected")}");
            }

        }
    }
    }