using System;

namespace ConsoleChess
{
    public class ConsoleIO
    {
        public ConsoleIO() { }

        public string InString(string promptMessage)
        {
            Out(promptMessage);
            return Console.ReadLine();
        }

        public int InInt(string promptMessage)
        {
            Out(promptMessage);
            Int32.TryParse(Console.ReadLine(), out int result);

            return result;
        }

        public double InDouble(string promptMessage)
        {
            Out(promptMessage);
            Double.TryParse(Console.ReadLine(), out double result);

            return result;
        }

        public void Line(string promptMessage)
        {
            Console.WriteLine(promptMessage);
        }

        public void Out(string promptMessage)
        {
            Console.Write(promptMessage);
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
