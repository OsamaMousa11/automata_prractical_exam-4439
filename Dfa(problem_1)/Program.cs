using System;

namespace DFAProject
{
    public class DFa
    {
        // States of the DFA
        private enum State
        {
            S0, 
            S1, 
            S2  
        }

        private State currentState;

   
        public DFa()
        {
            currentState = State.S0;
        }

        // Reset the DFA to its initial state
        public void Reset()
        {
            currentState = State.S0;
        }

        // Process a single character input
        public void ProcessChar(char input)
        {
            if (input != '0' && input != '1')
            {
                throw new ArgumentException("Input must be a binary character ('0' or '1').");
            }

            switch (currentState)
            {
                case State.S0:
                    if (input == '1')
                    {
                        currentState = State.S1;
                    }
                    // If input is '0', stay in S0
                    break;

                case State.S1:
                    if (input == '1')
                    {
                        currentState = State.S2;
                    }
                    // If input is '0', stay in S1
                    break;

                case State.S2:
                    if (input == '1')
                    {
                        currentState = State.S0;
                    }
                    // If input is '0', stay in S2
                    break;
            }
        }

        // Check if the current state is an accepting state
        public bool IsAccepted()
        {
            return currentState == State.S0;
        }

        // Process an entire binary string and return if it's accepted
        public bool ProcessString(string binaryString)
        {
            Reset(); // Start from the initial state for each new string
            foreach (char c in binaryString)
            {
                ProcessChar(c);
            }
            return IsAccepted();
        }

        // Main method for standalone execution (optional, can be removed if this is purely a library)
        public static void Main(string[] args)
        {
            DFa dfa = new DFa();

            string[] testStrings =
            {
                "111",      // 3 ones -> Accept
                "010101",   // 3 ones -> Accept
                "101",      // 2 ones -> Reject
                "000",      // 0 ones -> Accept
                "1",        // 1 one  -> Reject
                "11",       // 2 ones -> Reject
                "1111",     // 4 ones -> Reject (4 % 3 = 1)
                "111111",   // 6 ones -> Accept (6 % 3 = 0)
                "",         // 0 ones -> Accept (empty string)
                "0",        // 0 ones -> Accept
                "010",      // 1 one  -> Reject
                "1001001"   // 3 ones -> Accept
            };

            Console.WriteLine("Testing DFA for binary strings where the number of 1s is divisible by 3:");
            foreach (string testStr in testStrings)
            {
                bool accepted = dfa.ProcessString(testStr);
                Console.WriteLine($"Input: \"{testStr}\" -> {(accepted ? "Accepted" : "Rejected")}");
            }
        }
    }
}

