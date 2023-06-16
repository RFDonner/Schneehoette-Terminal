using Schneehoette_Terminal;

Console.ForegroundColor = ConsoleColor.Green;
while (true)
{
    if (TerminalState.LoggedIn)
    {
        ConsWriter.Write("Wilkommen zu Terminal 442, Schneehütte, Bitte geben Sie einen Befehl ein.");
    }
    else
    {
        ConsWriter.Write("Wilkommen zu Terminal 442, Bitte geben Sie einen Befehl ein.");
    }
    string command = Console.ReadLine();

    CommandReader.ReadCommand(command);
}


