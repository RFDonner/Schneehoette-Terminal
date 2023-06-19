namespace Schneehoette_Terminal
{
    public static class ConsWriter
    {
        public static int DelayTimer = 10;

        public static void WriteText(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            var charArray = text.ToCharArray();
            for (int i = 0; i < charArray.Length; i++)
            {
                Console.Write(charArray[i]);
                Thread.Sleep(DelayTimer);
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
        }
        public static void Write(string text)
        {
            WriteText(text, ConsoleColor.Green);
        }

        public static void WriteError(string text) {
            WriteText(text, ConsoleColor.Red);
        }

        public static void WriteWarning(string text)
        {
            WriteText(text, ConsoleColor.Yellow);
        }
    }
}
