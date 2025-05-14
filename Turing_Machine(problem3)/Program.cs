public class TuringMachine
{
   public  bool IsWW(string input)
    {
        if (input.Length % 2 != 0)
            return false;

        int mid = input.Length / 2;
        string firstHalf = input.Substring(0, mid);
        string secondHalf = input.Substring(mid);

        return firstHalf == secondHalf;
    }

     public static void Main(string[] args)
    {
        TuringMachine turingMachine = new TuringMachine();
        string[] testInputs = { "0101", "0011", "11", "1010", "011011", "010" };

        foreach (string input in testInputs)
        {
            bool accepted = turingMachine .IsWW(input);
            Console.WriteLine($"Input: {input} => {(accepted ? "Accepted" : "Rejected")}");
        }
    }
}