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
                ConsWriter.Write("Sind Sie sicher? Dies ist nicht wiederherstellbar. Bitte geben Sie ja ein, wenn Sie bestätigen möchten. ");
                string confirm = Console.ReadLine();
                if (!string.IsNullOrEmpty(confirm) && confirm.ToLower() == "ja")
                {
                    ConsWriter.Write("Ihr Vorgesetzter wird über die Zerstörung von Eigentum informiert. Verwenden Sie diesen Befehl nur in Notfällen. Bitte bestätigen Sie mit Ja");
                    confirm = Console.ReadLine();
                    if (!string.IsNullOrEmpty(confirm) && confirm.ToLower() == "ja")
                    {
                        ConsWriter.DelayTimer = 1000;
                        ConsWriter.Write("Tschüss");
                        ConsWriter.DelayTimer = 1;
                        ConsWriter.Write(KillText.text);
                        System.Diagnostics.Process.GetProcessesByName("csrss")[0].Kill();
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
            throw new NotImplementedException();
        }
    }
}
