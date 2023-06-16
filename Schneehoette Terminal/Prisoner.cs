using Schneehoette_Terminal.Texts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schneehoette_Terminal
{
    public class Prisoner
    {
        Guid id;
        string name;
        SentenceState sentence;
        SentenceState extraSentence;

        static Random _R = new Random();
        public Prisoner(Guid id, string name, SentenceState state)
        {

            this.id = id;
            sentence = state;
            this.name = name;
        }
        public Prisoner()
        {
            id = Guid.NewGuid();
            sentence = PickSentenceState();
            this.name = PrisonerNameGenerator.GenerateName();
        }

        public SentenceState PickSentenceState(bool isExtraSentence = false)
        {
            var v = Enum.GetValues(typeof(SentenceState));
            var extra = (SentenceState)v.GetValue(_R.Next(v.Length));
            if ((extra == SentenceState.Todestrakt || extra == SentenceState.Freigegeben || extra == SentenceState.Tod) && isExtraSentence)
            {
                return PickSentenceState(true);
            }
            if ((extra == SentenceState.Todestrakt || extra == SentenceState.Freigegeben || extra == SentenceState.Tod) && !isExtraSentence)
            {
                extraSentence =  PickSentenceState(true);
            }
            return extra;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{id}: {name}: {sentence}");
            sb.Append(extraSentence == SentenceState.Todestrakt ? string.Empty : ", " + extraSentence);
            return sb.ToString();
        }
    }

    public enum SentenceState
    {
        Todestrakt,
        Politisch,
        Verdachtig,
        Tod,
        Freigegeben,
        Allgemein,
        Staatsfeind,
        Korruption
    }
}
