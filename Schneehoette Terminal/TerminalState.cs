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

            };
        }
    }
}
