﻿using Schneehoette_Terminal.Texts;
using System.Text;

namespace Schneehoette_Terminal
{
    internal static class Commands
    {
        internal static void ExecuteLogin()
        {
            ConsWriter.Write("Bitte geben Sie Ihren Benutzernamen ein");
            string? username = Console.ReadLine();
            ConsWriter.Write("Bitte geben Sie Ihren passwort");
            string password = string.Empty;
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                if(key.Key == ConsoleKey.Backspace)
                {
                    password = password[..^1];
                }
                else password += key.KeyChar;
            }

            if (username.ToLower() == "schneehutte" && password == "L3kk3r83kj3!" || password == "Oktoberfest!")
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
            ConsWriter.Write("Id des Gefangenen einfügen");
            var id = Console.ReadLine();
            if (!string.IsNullOrEmpty(id) && IdGenerator.VerifyId(id))
            {
                ConsWriter.Write($"Ändern:");
                var prisoner = ExecuteSearchPrisoner(id);
                if (prisoner == null) { return; }
                while (true)
                {
                    ConsWriter.Write("Sie können die folgenden ändern: SENTENCESTATE, ");
                    ConsWriter.Write("Ändern? Y/N");
                    var confirm = Console.ReadLine();
                    if (!string.IsNullOrEmpty(confirm) && confirm.ToLower() == "y")
                    {
                        while (true)
                        {
                            ConsWriter.Write("neuen Strafmaß eingeben");
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
                                    ConsWriter.WriteError($"ERROR: SENTENCE {sentence} ALREADY {sentence}");
                                    return;
                                }
                                var tempStorage = prisoner.sentence;
                                prisoner.sentence = (SentenceState)result;
                                if (sentence == SentenceState.Todestrakt || sentence == SentenceState.Tod || sentence == SentenceState.Freigegeben)
                                {
                                    prisoner.extraSentence = tempStorage;
                                    ConsWriter.Write($"SUCCESS! {prisoner}");
                                }
                                return;
                            }
                            else
                            {
                                ConsWriter.WriteWarning($"{confirm} ist nicht gültig. Bitte erneut versuchen.");
                            }
                        }
                    }
                    else if (!string.IsNullOrEmpty(confirm) && confirm.ToLower() == "n")
                    {
                        return;
                    }

                    ConsWriter.WriteWarning($"{confirm} ist nicht gültig. Bitte erneut versuchen.");
                }



            }
            else
            {
                ConsWriter.WriteError("INVALID ID!");
            }
        }

        internal static void ExecuteKill()
        {
            if (TerminalState.LoggedIn)
            {
                ConsWriter.Write("Sind Sie sicher? Dies ist nicht wiederherstellbar. Bitte geben Sie ja ein, wenn Sie bestätigen möchten.");
                string? confirm = Console.ReadLine();
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

        internal static Prisoner ExecuteSearchPrisoner(string prisonerId)
        {
            if(TerminalState.LoggedIn)
            {
                try
                {
                    Prisoner prisoner = TerminalState.Prisoners.Single(p => p.Id.Equals(prisonerId));
                    ConsWriter.Write($"{prisoner.Id}: {prisoner}");
                    return prisoner;
                }
                catch (InvalidOperationException)
                {
                    ConsWriter.WriteError("PRISONER DOES NOT EXIST");
                }
            }
            return null;
        }

        internal static void ExecuteProbe()
        {
            if (!TerminalState.Hacked) return;

            Random rand = new();
            ConsWriter.DelayTimer = 1 * (int)(Math.Pow(TerminalState.probeAmount + 1, TerminalState.probeAmount + 1));
            int characterAmount = 400 - (100 * TerminalState.probeAmount);
            if (characterAmount < ProbeText.userText.Length) characterAmount = ProbeText.userText.Length;
            int spacing = (characterAmount / ProbeText.userText.Length) - 1;
            int iterator = 0;
            int charIterator = 0;
            StringBuilder randomCharacters = new();
            while (characterAmount > 0)
            {
                if(iterator == spacing && ProbeText.userText.Length > charIterator)
                {
                    randomCharacters.Append(ProbeText.userText[charIterator]);
                    charIterator++;
                    iterator = 0;
                }
                else
                {
                    iterator++;
                    int index = rand.Next(0, ProbeText.text.Length);
                    randomCharacters.Append(ProbeText.text[index]);
                }
                characterAmount--;
            }
            TerminalState.probeAmount++;
            ConsWriter.WriteError(randomCharacters.ToString());
            ConsWriter.DelayTimer = 10;
        }
    }
}
