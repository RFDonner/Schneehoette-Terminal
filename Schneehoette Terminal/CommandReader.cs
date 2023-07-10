namespace Schneehoette_Terminal
{
    public class CommandReader
    {
        public static void ReadCommand(string command)
        {
            if (string.IsNullOrEmpty(command))
            {
                ConsWriter.WriteWarning("Kein Befehl gegeben, bitte versuchen Sie es nochmal.");
                return;
            }

            command = command.ToLower();
            switch (command)
            {
                case "login":
                    if (TerminalState.LoggedIn) ConsWriter.WriteWarning("Sie sind bereits angemeldet.");
                    else Commands.ExecuteLogin();
                    break;
                case "logout":
                    Commands.ExecuteLogout();
                    break;
                case "help":
                    ConsWriter.Write("LOGIN - Meldet Sie bei der Anwendung an");
                    ConsWriter.Write("LOGOUT - Meldet den aktuellen Benutzer ab");
                    ConsWriter.Write("HELP - Ruft dieser schirm an.");
                    ConsWriter.Write("LIST - Zeigt die Kennung jedes Häftlings an");
                    ConsWriter.Write("SEARCH - Suche nach einem Häftling anhand der Identität");
                    ConsWriter.Write("CHANGE - Ändert die Registrierung des Häftlings nach Angabe der Identität");
                    ConsWriter.Write("KILL - Zerstört das Terminal (NOTIFY AN SL IF YOU USE THIS COMMAND)");
                    break;
                case "hilfe":
                    ConsWriter.WriteError("ERROR EXECUTING hilfe! DID YOU MEAN help?");
                    break;
                case "search":
                    InitSearch();
                    break;
                case "change":
                    InitChange();
                    break;
                case "list":
                    Commands.ExecuteList();
                    break;
                case "kill":
                    Commands.ExecuteKill();
                    break;
                default:
                    ConsWriter.WriteWarning($"{command} ist unbekannt, bitte noch einmal versuchen.");
                    break;
            }
        }

        private static void InitChange()
        {
            if (!TerminalState.LoggedIn)
            {
                return;
            }

            Commands.ExecuteChange();
        }

        private static void InitSearch()
        {
            if (!TerminalState.LoggedIn)
            {
                return;
            }
            ConsWriter.Write("Id des Gefangenen einfügen");
            var id = Console.ReadLine();
            if (!string.IsNullOrEmpty(id) && IdGenerator.VerifyId(id))
            {
                Commands.ExecuteSearchPrisoner(id);
            }
            else
            {
                ConsWriter.WriteError("INVALID ID!");
            }
        }
    }
}
