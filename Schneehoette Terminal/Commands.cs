using Schneehoette_Terminal.Texts;

namespace Schneehoette_Terminal
{
    public static class Commands
    {
        public static void ExecuteLogin()
        {
            ConsWriter.Write("Bitte geben Sie Ihren Benutzernamen ein");
            string username = Console.ReadLine();
            ConsWriter.Write("Bitte geben Sie Ihren passwort");
            string password = string.Empty;
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                password += key.KeyChar;
            }

            if (username == "schneehutte" && password == "Oktoberfest!")
            {
                TerminalState.LoggedIn = true;
            }
            else
            {
                ConsWriter.Write("Falscher Benutzername oder falsches Passwort.");
            }
        }

        internal static void ExecuteKill()
        {
            if (TerminalState.LoggedIn)
            {
                ConsWriter.Write("Sind Sie sicher? Dies ist nicht wiederherstellbar. Bitte geben Sie ja ein, wenn Sie bestätigen möchten.");
                string confirm = Console.ReadLine();
                if (!string.IsNullOrEmpty(confirm) && confirm.ToLower() == "ja")
                {
                    ConsWriter.Write("Ihr Vorgesetzter wird über die Zerstörung von Eigentum informiert. Verwenden Sie diesen Befehl nur in Notfällen. Bitte bestätigen Sie mit Ja");
                    confirm = Console.ReadLine();
                    if (!string.IsNullOrEmpty(confirm) && confirm.ToLower() == "ja")
                    {
                        ConsWriter.DelayTimer = 1000;
                        ConsWriter.Write("Tschüss");
                        ConsWriter.DelayTimer = 0;
                        while (true)
                        {
                            Random rand = new Random();
                            int index = rand.Next(0, KillText.text.Length);
                            Console.Write(KillText.text[index]);
                        }
                    }
                }
            }
            else
            {
                ConsWriter.Write("Bitte anmelden");
            }
        }

        internal static void ExecuteList()
        {
            foreach (var prisoner in TerminalState.Prisoners)
            {
                ConsWriter.Write(prisoner.ToString());
                if (Console.ForegroundColor == ConsoleColor.Green) { Console.ForegroundColor = ConsoleColor.DarkGreen; }

                else { Console.ForegroundColor = ConsoleColor.Green; }
            }

            Console.ForegroundColor = ConsoleColor.Green;
        }

        internal static void ExecuteSearchPrisoner(Guid prisonerId)
        {
            if(TerminalState.LoggedIn)
            {
                try
                {
                    Prisoner prisoner = TerminalState.Prisoners.Single(p => p.Id == prisonerId);
                    ConsWriter.Write($"{prisoner.Id}: {prisoner}");
                }
                catch (ArgumentNullException)
                {
                    ConsWriter.Write("PRISONER DOES NOT EXIST");
                }
            }
        }
    }
}
