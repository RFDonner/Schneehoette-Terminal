﻿using Schneehoette_Terminal.Texts;

namespace Schneehoette_Terminal
{
    internal static class Commands
    {
        internal static void ExecuteLogin()
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

        internal static void ExecuteLogout()
        {
            TerminalState.LoggedIn = false;
            Console.Clear();
        }

        internal static void ExecuteChange()
        {
            ConsWriter.Write("Insert id of prisoner");
            var id = Console.ReadLine();
            if (Guid.TryParse(id, out Guid guidId))
            {
                ConsWriter.Write($"Changing:");
                var prisoner = ExecuteSearchPrisoner(guidId);
                if (prisoner == null) { return; }
                ConsWriter.Write("You can change SENTENCESTATE, ");
                ConsWriter.Write("Change? Y/N");
                while (true)
                {
                    ConsWriter.Write("You can change SENTENCESTATE, ");
                    ConsWriter.Write("Change? Y/N");
                    var confirm = Console.ReadLine();
                    if (!string.IsNullOrEmpty(confirm) && confirm.ToLower() == "y")
                    {
                        while (true)
                        {
                            ConsWriter.Write("Enter new sentence");
                            ConsWriter.Write($"0: {SentenceState.Todestrakt}");
                            ConsWriter.Write($"1: {SentenceState.Politisch}");
                            ConsWriter.Write($"2: {SentenceState.Verdachtig}");
                            ConsWriter.Write($"3: {SentenceState.Tod}");
                            ConsWriter.Write($"4: {SentenceState.Freigegeben}");
                            ConsWriter.Write($"5: {SentenceState.Allgemein}");
                            ConsWriter.Write($"6: {SentenceState.Staatsfeind}");
                            ConsWriter.Write($"7: {SentenceState.Korruption}");
                            confirm = Console.ReadLine();
                            var pickedState = int.TryParse(confirm, out int result);

                            if (pickedState && result >= 0 && result < 8)
                            {
                                var sentence = (SentenceState)result;
                                if (sentence == prisoner.sentence)
                                {
                                    ConsWriter.Write($"Sentence of prisoner is already {sentence}");
                                    return;
                                }
                                var tempStorage = prisoner.sentence;
                                prisoner.sentence = (SentenceState)result;
                                if (sentence == SentenceState.Todestrakt || sentence == SentenceState.Tod || sentence == SentenceState.Freigegeben)
                                {
                                    prisoner.extraSentence = tempStorage;
                                    ConsWriter.Write($"Success! {prisoner}");
                                }
                                return;
                            }
                            else
                            {
                                ConsWriter.Write($"{confirm} is not valid. Try again.");
                            }
                        }
                    }
                    else if (confirm.ToLower() == "n")
                    {
                        return;
                    }

                    ConsWriter.Write($"{confirm} is not valid try again");
                }



            }
            else
            {
                ConsWriter.Write("INVALID ID!");
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
                if (Console.ForegroundColor == ConsoleColor.Green) { Console.ForegroundColor = ConsoleColor.White; }

                else { Console.ForegroundColor = ConsoleColor.Green; }
            }

            Console.ForegroundColor = ConsoleColor.Green;
        }

        internal static Prisoner ExecuteSearchPrisoner(Guid prisonerId)
        {
            if(TerminalState.LoggedIn)
            {
                try
                {
                    Prisoner prisoner = TerminalState.Prisoners.Single(p => p.Id == prisonerId);
                    ConsWriter.Write($"{prisoner.Id}: {prisoner}");
                    return prisoner;
                }
                catch (ArgumentNullException)
                {
                    ConsWriter.Write("PRISONER DOES NOT EXIST");
                }
            }
            return null;
        }
    }
}
