namespace Schneehoette_Terminal
{
    public class CommandReader
    {
        public static void ReadCommand(string command)
        {
            if(string.IsNullOrEmpty(command))
            {
                ConsWriter.Write("Kein Befehl gegeben, bitte versuchen Sie es nochmal.");
                return;
            }

            command = command.ToLower();
            switch (command)
            {
                case "login":
                    if (TerminalState.LoggedIn) ConsWriter.Write("Sie sind bereits angemeldet.");
                    else Commands.ExecuteLogin();
                    break;
                case "help":
                    ConsWriter.Write("LOGIN - Meldet Sie bei der Anwendung an");
                    ConsWriter.Write("HELP - Ruft dieser schirm an.");
                    ConsWriter.Write("LIST - Zeigt die Kennung jedes Häftlings an");
                    ConsWriter.Write("CHANGE - Ändert die Registrierung des Gefangenen nach Angabe der Identität");
                    ConsWriter.Write("KILL - Zerstört das Terminal und startet das System neu (NOTIFY AN SL IF YOU USE THIS COMMAND)");
                    break;
                case "hilfe":
                        ConsWriter.Write("ERROR EXECUTING hilfe! DID YOU MEAN help?");
                        break;
                case "list":
                    Commands.ExecuteList();
                    break;
                case "kill":
                    Commands.ExecuteKill();
                    break;
                default:
                    ConsWriter.Write($"{command} ist unbekannt, bitte noch einmal versuchen.");
                    break;
            }
        }
    }
}
