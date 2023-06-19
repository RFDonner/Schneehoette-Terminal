namespace Schneehoette_Terminal
{
    public static class ConsWriter
    {
        public static int DelayTimer = 10;
        public static void Write(string text)
        {
            var charArray = text.ToCharArray();
            for (int i = 0; i < charArray.Length; i++)
            {
                Console.Write(charArray[i]);
                Thread.Sleep(DelayTimer);
            }

            Console.WriteLine();
        }

        public static void WriteError(string text) {
            Console.ForegroundColor= ConsoleColor.Red;
            var charArray = text.ToCharArray();
            for (int i = 0; i < charArray.Length; i++)
            {
                Console.Write(charArray[i]);
                Thread.Sleep(DelayTimer);
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}
