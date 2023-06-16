namespace Schneehoette_Terminal
{
    public static class ConsWriter
    {
        public static void Write(string text)
        {
            var charArray = text.ToCharArray();
            for (int i = 0; i < charArray.Length; i++)
            {
                Console.Write(charArray[i]);
                Thread.Sleep(2);
            }

            Console.WriteLine();
        }
    }
}
