using System.Text;

namespace Schneehoette_Terminal.Texts
{
    public static class PrisonerNameGenerator
    {
        private static Random r = new Random();

        private static List<string> FirstNames;
        private static List<string> MiddleNames;
        private static List<string> Surnames;

        public static string GenerateName()
        {
            int amountOfMiddleNames = r.Next(3);
            StringBuilder sb = new StringBuilder();

            sb.Append(FirstNames[r.Next(FirstNames.Count)] + ' ');

            for (int i = 0; i < amountOfMiddleNames; i++)
            {
                sb.Append(MiddleNames[r.Next(MiddleNames.Count)] + ' ');
            }

            sb.Append(Surnames[r.Next(Surnames.Count)]);

            return sb.ToString();
        }

        public static void InitNameGenerator()
        {
            InitFirstNames();
            InitMiddleNames();
            InitSurnames();
        }

        private static void InitFirstNames()
        {
            FirstNames = new List<string> { "Robert", "Amber", "Mark", "Lukas", "Frank", "Dominik", "David", "Felix", "Felicia", "Jürgen", "Ralf", "Suse", "Bartholomeus", "Martin", "Natascha", "Micha", "Reto", "Agnes", "Heinrich", "Lisbeth", "Camilla", "Jockel", "Hiltraud", "Heidrun", "Leonie", "Arnold", "Bart", "Mark" };
        }
        private static void InitMiddleNames()
        {
            MiddleNames = new List<string> { "Finn", "Tamara", "Friedrich", "Ben", "Elias", "Anna", "Maria", "Hanna", "Leon", "Maximilian", "Nikolas",  "Amadeus", "Friedrich", "Kornelis", "Seraphina", "Richard", "Konrad", "Titus", "Karl", "David", "Jolanthe", "Helene", "Winfried", "Heinrich", "Erwin", "Friedrich", "Ferdinand"};
        }

        private static void InitSurnames()
        {
            Surnames = new List<string> { "Müller", "Abeelen", "Post", "Donner", "Thomas", "Wolfgang", "Grünewald", "Bachmann", "Löwe", "Kruger" , "Plank", "Seppel", "Baumgarten", "Blau", "Baier", "Königsmann", "Gabler", "Spellmayer", "Tiroler", "Schaff", "Schneider", "Weber", "Wagner", "Becker", "Fischer", "Meyer" };
        }

    }
}
