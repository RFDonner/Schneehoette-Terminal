using Schneehoette_Terminal.Texts;
using System.Text;

namespace Schneehoette_Terminal
{
    public class Prisoner
    {
        public readonly string Id;
        public readonly string name;
        public SentenceState sentence;
        public SentenceState extraSentence;

        static readonly Random _R = new Random();
        public Prisoner(string id, string name, SentenceState state)
        {

            Id = id;
            sentence = state;
            this.name = name;
        }
        public Prisoner()
        {
            sentence = PickSentenceState();
            name = PrisonerNameGenerator.GenerateName();
            Id = sentence == SentenceState.Todestrakt ? IdGenerator.GenerateId(true) : IdGenerator.GenerateId(false);
        }

        public SentenceState PickSentenceState(bool isExtraSentence = false)
        {
            var v = Enum.GetValues(typeof(SentenceState));
            SentenceState? extra = (SentenceState?)v.GetValue(_R.Next(v.Length));

            if (!extra.HasValue)
            {
                throw new ArgumentOutOfRangeException();
            }

            if ((extra == SentenceState.Todestrakt || extra == SentenceState.Freigegeben || extra == SentenceState.Tod) && isExtraSentence)
            {
                return PickSentenceState(true);
            }
            if ((extra == SentenceState.Todestrakt || extra == SentenceState.Freigegeben || extra == SentenceState.Tod) && !isExtraSentence)
            {
                extraSentence =  PickSentenceState(true);
            }
            return extra.Value;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{Id} {name}: {sentence}");
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
