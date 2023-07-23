namespace Schneehoette_Terminal
{
    public static class TerminalState
    {
        private static bool _loggedIn = false;
        private static bool _hacked = false;
        internal static int probeAmount = 0;
        public static bool LoggedIn
        {
            get
            {
                if (!_loggedIn) { ConsWriter.WriteWarning("Bitte Einloggen."); }
                return _loggedIn;
            }
            set { _loggedIn = value; }
        }

        public static bool NoTextLoggedIn
        {
            get { return _loggedIn; }
        }
        public static bool Hacked
        {
            get
            {
                if (!_hacked) { ConsWriter.WriteWarning("COMMAND UNKNOWN!"); }
                return _hacked;
            }
            set { _hacked = value; }
        }
        public static List<Prisoner> Prisoners { get; set; } = new List<Prisoner>();

        public static void InitPrisoners()
        {
            List<Prisoner> playerPrisoners = new()
            {
                {new Prisoner("083-102-118", "Jenna Mignon", SentenceState.Verdachtig) },
                {new Prisoner("083-102-119", "André Bax", SentenceState.Allgemein) },
                {new Prisoner("083-106-120", "Clara Normal", SentenceState.Allgemein) },
                {new Prisoner("083-102-121", "Magnus Oldewater", SentenceState.Allgemein) },
                {new Prisoner("083-104-122", "Julia Parker", SentenceState.Staatsfeind) },
                {new Prisoner("083-104-123", "Austin Pacholski", SentenceState.Staatsfeind) },
                {new Prisoner("083-102-124", "Jason Floyd", SentenceState.Allgemein) },
                {new Prisoner("083-102-125", "Jerry Smith", SentenceState.Allgemein) },
                {new Prisoner("083-106-126", "Jack Schaeffer", SentenceState.Politisch) },
                {new Prisoner("083-102-127", "Jonathan Vulture Normal", SentenceState.Korruption) }
            };

            List<Prisoner> npcPrisoners = new()
            {
                { new Prisoner("045-104-111", "P. Malloy", SentenceState.Staatsfeind)   },
                { new Prisoner("063-101-111", "P. Merkel", SentenceState.Staatsfeind)   },
                { new Prisoner("073-101-112", "F. Reilch", SentenceState.Politisch)     },
                { new Prisoner("079-204-113", "C. Clarke", SentenceState.Todestrakt)    },
                { new Prisoner("081-101-111", "M. Shoehorn", SentenceState.Allgemein) },
                { new Prisoner("083-206-112", "L. Krasinski", SentenceState.Todestrakt) },
                { new Prisoner("083-101-115", "D. Koch", SentenceState.Staatsfeind)     }
            };
            Prisoners.AddRange(playerPrisoners);
            Prisoners.AddRange(npcPrisoners);

            for (int i = 0; i < 50; i++)
            {
                Prisoners.Add(new Prisoner());
            }

            Prisoners = Prisoners.OrderBy(p => p.Id).ToList();
        }
    }
}
