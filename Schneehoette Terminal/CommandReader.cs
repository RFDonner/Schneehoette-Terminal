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
                    if (TerminalState.LoggedIn)
                    {
                        ConsWriter.Write("Sie sind bereits angemeldet.");
                    }
                    else
                    {
                        Commands.ExecuteLogin();
                    }
                    break;
                default:
                    ConsWriter.Write("{command} ist unbekannt, bitte noch einmal versuchen.");
                    break;
            }
        }
    }
}
