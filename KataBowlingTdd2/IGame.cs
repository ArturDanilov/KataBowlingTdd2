namespace KataBowlingTdd2
{
    public interface IGame
    {
        void AddRoll(int pins);
        Frame[] Frames();
        int TotalScore();
        bool Over();
    }
}
