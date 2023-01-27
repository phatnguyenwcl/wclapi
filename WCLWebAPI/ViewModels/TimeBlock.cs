using WCLWebAPI.Server.Enums;

namespace WCLWebAPI.Server.ViewModels
{
    public class TimeBlock
    {
        public BlockTypes BlockType;
        public TimeLog In;
        public TimeLog Out;

        public TimeSpan Duration
        {
            get
            {
                // TODO: Need error checking
                return Out.EntryDateTime.Subtract(In.EntryDateTime);
            }
        }

        public override string ToString()
        {
            return $"In: {In.EntryDateTime:HH:mm} - Out: {Out.EntryDateTime:HH:mm}";
        }
    }
}
