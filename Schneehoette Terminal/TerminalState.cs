using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schneehoette_Terminal
{
    public static class TerminalState
    {
        public static bool LoggedIn { get; set; } = false;

        public static List<Prisoner> Prisoners { get; set; } = new List<Prisoner>();

        public static void InitPrisoners()
        {
            for (int i = 0; i < 100; i++)
            {
                Prisoners.Add(new Prisoner());
            }

            List<Prisoner> playerPrisoners = new List<Prisoner>
            {
                {new Prisoner("083-102-118", "Jenna Mignon", SentenceState.Verdachtig) },
                {new Prisoner("083-102-119", "André Bax", SentenceState.Allgemein) },
                {new Prisoner("083-106-120", "Clara Doe", SentenceState.Allgemein) },
                {new Prisoner("083-102-121", "Magnus Oldewater", SentenceState.Allgemein) },
                {new Prisoner("083-104-122", "Julia Parker", SentenceState.Staatsfeind) },
                {new Prisoner("083-104-123", "Austin Pacholski", SentenceState.Staatsfeind) },
                {new Prisoner("083-102-124", "Jason Floyd", SentenceState.Allgemein) },
                {new Prisoner("083-102-125", "Jerry Smith", SentenceState.Allgemein) },
                {new Prisoner("083-106-126", "Jack Schaeffer", SentenceState.Politisch) },
                {new Prisoner("083-102-127", "Jonathan Vulture Doe", SentenceState.Korruption) },
                {new Prisoner("083-102-128", "Bass Lennard", SentenceState.Politisch) }
            };

            Prisoners.AddRange(playerPrisoners);
            Prisoners = Prisoners.OrderBy(p => p.Id).ToList();
        }
    }
}
