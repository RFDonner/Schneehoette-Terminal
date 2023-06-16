using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
