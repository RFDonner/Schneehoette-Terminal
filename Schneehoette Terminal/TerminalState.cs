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
                {new Prisoner(Guid.Parse("32fa9e4e-5823-468a-a102-1ab39d12e750"), "Jenna Mignon", SentenceState.Verdachtig) },
                {new Prisoner(Guid.Parse("d21df892-3c41-4397-a206-dc891a5f84ee"), "André Bax", SentenceState.Allgemein) },
                {new Prisoner(Guid.Parse("a7b2ef5a-e639-4e09-a3f8-b3dcdbffb373"), "Clara Doe", SentenceState.Allgemein) },
                {new Prisoner(Guid.Parse("b8a2e83c-9084-4317-82b7-fe36e93a2a20"), "Magnus Oldewater", SentenceState.Allgemein) },
                {new Prisoner(Guid.Parse("b87db37b-7ae5-4e30-b608-33c992720041"), "Julia Parker", SentenceState.Staatsfeind) },
                {new Prisoner(Guid.Parse("d94c1bef-bf46-463e-a3e8-d8b07b67a06f"), "Austin Pacholski", SentenceState.Staatsfeind) },
                {new Prisoner(Guid.Parse("07df9165-7201-4008-a0f8-f87448591d5d"), "Jason Floyd", SentenceState.Allgemein) },
                {new Prisoner(Guid.Parse("be09fbc8-528c-48cd-964b-08a529492ae1"), "Jerry Smith", SentenceState.Allgemein) },
                {new Prisoner(Guid.Parse("18be6270-f892-4103-a73f-b26470139c52"), "Jasper Schaeffer", SentenceState.Politisch) },
                {new Prisoner(Guid.Parse("5d97c470-c696-46ca-8dfe-7fcb678e28e6"), "Jonathan Vulture Doe", SentenceState.Korruption) },
                {new Prisoner(Guid.Parse("e51dfb65-a250-4f5e-921d-b86cf816723a"), "Bass Lennard", SentenceState.Politisch) }
            };

            Prisoners.AddRange(playerPrisoners);
            Prisoners = Prisoners.OrderBy(p => p.Id).ToList();
        }
    }
}
