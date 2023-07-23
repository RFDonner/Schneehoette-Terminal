using Schneehoette_Terminal;
using Schneehoette_Terminal.Texts;

Console.ForegroundColor = ConsoleColor.Green;
PrisonerNameGenerator.InitNameGenerator();
TerminalState.InitPrisoners();
while (true)
{
    if (TerminalState.NoTextLoggedIn)
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


