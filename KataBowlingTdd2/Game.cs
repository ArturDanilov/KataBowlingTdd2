namespace KataBowlingTdd2
{
    public class Game : IGame
    {
        //um das frameobject bereits zu haben
        private Frame[] frames = new Frame[11];

        private int currentFrameIndex = 0;
        private int currentRollIndex = 0;

        //Frames();

        public void AddRoll(int pins)
        {
            //max 10 frames
            if (!Over())
            {
                Frames();

                //pins hinzufügen
                frames[currentFrameIndex].PinsRolled[currentRollIndex++] = pins;

                //score hinzufügen
                frames[currentFrameIndex].Score += pins;

                //schritt zum nächsten Frame
                if (currentRollIndex == 2)
                {
                    currentFrameIndex++;
                    currentRollIndex = 0;
                }
            }
            else
            {
                throw new ArgumentException("Game Over!");
            }
        }

        public Frame[] Frames()
        {
            if(frames[currentFrameIndex] == null)
            {
                for (int i = 0; i <= 10; i++)
                {
                    frames[i] = new Frame();
                    frames[i].PinsRolled = new int[2];
                }
            }
            return frames;
        }

        public bool Over()
        {
            if (currentFrameIndex>=11)
            {
                return true;
            }
            return false;
        }

        public int TotalScore()
        {
            int totalScore = 0;

            for (int i = 0; i < 10; i++)
            {
                //if strike
                if (frames[i].PinsRolled[0] == 10)
                {
                    totalScore += 10 + frames[i + 1].PinsRolled[0] + frames[i + 1].PinsRolled[1];
                }
                else if (frames[i].PinsRolled[0] + frames[i].PinsRolled[1] == 10)
                {
                    totalScore += 10 + frames[i + 1].PinsRolled[0];
                }
                else
                {
                    totalScore += frames[i].Score;
                }
            }

            return totalScore;
        }
    }
}
