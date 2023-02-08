using KataBowlingTdd2;

namespace KataBowlingTdd2Tests
{
    public class GameTests
    {

        Game _game;

        [SetUp]
        public void Setup()
        {
            _game = new Game();
        }

        [TearDown]
        public void TearDown()
        {
            _game = null;
        }

        [Test]
        public void AddRoll_Eingabe1_ReturnPins1()
        {
            int pins = 3;

            _game.AddRoll(pins);

            Assert.That(_game.TotalScore(), Is.EqualTo(pins));
        }

        [Test]
        public void AddRoll_Eingabe3und4_ReturnScore7()
        {
            int pins1 = 3;
            int pins2 = 4;

            _game.AddRoll(pins1);
            _game.AddRoll(pins2);

            Assert.That(_game.TotalScore(), Is.EqualTo(7));
        }

        [Test]
        public void AddRoll_Eingabe3446_ReturnScore10()
        {
            int pins1 = 1;
            int pins2 = 2;
            int pins3 = 3;
            int pins4 = 4;

            _game.AddRoll(pins1);
            _game.AddRoll(pins2);
            _game.AddRoll(pins3);
            _game.AddRoll(pins4);

            Assert.That(_game.TotalScore(), Is.EqualTo(10));
        }

        [Test]
        public void AddRoll_Eingabe21Pins_ReturnExeption()
        {
            int pins1 = 1; 

            //add 20 rolls
            _game.AddRoll(pins1);
            _game.AddRoll(pins1);
            _game.AddRoll(pins1);
            _game.AddRoll(pins1);
            _game.AddRoll(pins1);
            _game.AddRoll(pins1);
            _game.AddRoll(pins1);
            _game.AddRoll(pins1);
            _game.AddRoll(pins1);
            _game.AddRoll(pins1);
            _game.AddRoll(pins1);
            _game.AddRoll(pins1);
            _game.AddRoll(pins1);
            _game.AddRoll(pins1);
            _game.AddRoll(pins1);
            _game.AddRoll(pins1);
            _game.AddRoll(pins1);
            _game.AddRoll(pins1);
            _game.AddRoll(pins1);
            _game.AddRoll(pins1);
            
            //AddRoll kill +21
            var myExeption = Assert.Throws<ArgumentException>(() => _game.AddRoll(pins1));

            Assert.That(myExeption.Message, Is.EqualTo("Game Over!"));
        }

        [Test]
        public void AddRoll_Eingabe1Strik_ReturnScore26()
        {
            int strike = 10;

            _game.AddRoll(strike); // strike ++ nächste 2 roll == 30
            _game.AddRoll(0);
            _game.AddRoll(4);
            _game.AddRoll(4);

            Assert.That(_game.TotalScore, Is.EqualTo(26));
        }

        [Test]
        public void AddRoll_EingabeStrikeLost_ReturnScore18()
        {
            int strike = 10;

            _game.AddRoll(4);
            _game.AddRoll(4);
            _game.AddRoll(strike); // strike ++ nächste 2 roll == 30
            _game.AddRoll(0);

            Assert.That(_game.TotalScore, Is.EqualTo(18));
        }

        [Test]
        public void AddRoll_Eingabe1StrikUnd63_ReturnScore35()
        {
            int strike = 10;

            _game.AddRoll(strike); // strike ++ nächste 2 roll == 30
            _game.AddRoll(0);
            _game.AddRoll(4);
            _game.AddRoll(4);
            _game.AddRoll(6);
            _game.AddRoll(3);

            Assert.That(_game.TotalScore, Is.EqualTo(35));
        }

        [Test]
        public void AddRoll_Eingabe2Striks_ReturnScore61()
        {
            int strike = 10;

            _game.AddRoll(strike); // strike ++ nächste 2 roll == 27
            _game.AddRoll(0);
            _game.AddRoll(4);
            _game.AddRoll(4);
            _game.AddRoll(6);
            _game.AddRoll(3); //44
            _game.AddRoll(strike); //62
            _game.AddRoll(0);
            _game.AddRoll(4);
            _game.AddRoll(4);

            Assert.That(_game.TotalScore, Is.EqualTo(61));
        }

        [Test]
        public void AddRoll_Eingabe1StrikeUndSpare_ReturnScore57()
        {
            int strike = 10;
            int spare = 5;

            _game.AddRoll(strike); // strike ++ nächste 2 roll == 30
            _game.AddRoll(0);
            _game.AddRoll(4);
            _game.AddRoll(4);
            _game.AddRoll(6);
            _game.AddRoll(3);
            _game.AddRoll(spare);
            _game.AddRoll(spare);
            _game.AddRoll(4);
            _game.AddRoll(4);

            Assert.That(_game.TotalScore, Is.EqualTo(57));
        }

        [Test]
        public void AddRoll_Eingabe1SpareUnd3_ReturnScore16()
        {
            _game.AddRoll(5);
            _game.AddRoll(5);
            _game.AddRoll(3);

            Assert.That(_game.TotalScore, Is.EqualTo(16));
        }

        [Test]
        public void AddRoll_Eingabe1SpareUnd34_ReturnScore20()
        {
            _game.AddRoll(5);
            _game.AddRoll(5);
            _game.AddRoll(3);
            _game.AddRoll(4);

            Assert.That(_game.TotalScore, Is.EqualTo(20));
        }

        [Test]
        public void AddRoll_FastLostGame_Return61()
        {
            _game.AddRoll(1); // 1
            _game.AddRoll(4); // 5 <-- 0
            _game.AddRoll(4); // 9
            _game.AddRoll(5); // 14 <-- 1
            _game.AddRoll(6); // 20
            _game.AddRoll(4); // 29 <-- spea +5
            _game.AddRoll(5); // 34
            _game.AddRoll(5); // 49 <-- 3
            _game.AddRoll(10); // 60
            _game.AddRoll(0);
            _game.AddRoll(0); // 60
            _game.AddRoll(1); // 61

            Assert.That(_game.TotalScore, Is.EqualTo(61));
        }


        [Test]
        public void AddRoll_LostGame_Return133()
        {
            _game.AddRoll(1); // 1
            _game.AddRoll(4); // 5 <-- 0
            _game.AddRoll(4); // 9
            _game.AddRoll(5); // 14 <-- 1
            _game.AddRoll(6); // 20
            _game.AddRoll(4); // 24 <-- 2
            _game.AddRoll(5); // 34
            _game.AddRoll(5); // 39 <-- 3
            _game.AddRoll(10); // 59
            _game.AddRoll(0);
            _game.AddRoll(0); // 59
            _game.AddRoll(1); // 61
            _game.AddRoll(7); // 68
            _game.AddRoll(3); // 71
            _game.AddRoll(6); // 83
            _game.AddRoll(4); // 87
            _game.AddRoll(10); // 107
            _game.AddRoll(0);
            _game.AddRoll(2); // 111
            _game.AddRoll(8); // 127
            _game.AddRoll(6); // 133

            Assert.That(_game.TotalScore, Is.EqualTo(133));
        }

        //[Test]
        //public void AddRoll_Eingabe10Spare_ReturnScore150()
        //{
        //    _game.AddRoll(5);
        //    _game.AddRoll(5); // spare 5 + 5 = 10 + nächste roll = 15
        //    _game.AddRoll(5); // 15 + 5 == 20
        //    _game.AddRoll(5); // 20 + 5 + nächste roll = 30
        //    _game.AddRoll(5);
        //    _game.AddRoll(5); //45
        //    _game.AddRoll(5);
        //    _game.AddRoll(5); //60
        //    _game.AddRoll(5);
        //    _game.AddRoll(5); //75
        //    _game.AddRoll(5);
        //    _game.AddRoll(5); //90
        //    _game.AddRoll(5);
        //    _game.AddRoll(5); //105
        //    _game.AddRoll(5);
        //    _game.AddRoll(5); //120
        //    _game.AddRoll(5);
        //    _game.AddRoll(5); //135
        //    _game.AddRoll(5);
        //    _game.AddRoll(5); //150
        //    _game.AddRoll(5);

        //    Assert.That(_game.TotalScore, Is.EqualTo(150));
        //}

        //[Test]
        //public void AddRoll_Eingabe10Striks_ReturnScore300()
        //{
        //    int strike = 10;

        //    _game.AddRoll(strike); // strike ++ nächste 2 roll == 30
        //    _game.AddRoll(0);
        //    _game.AddRoll(strike); // strike ++ nächste 2 roll == 60
        //    _game.AddRoll(0);
        //    _game.AddRoll(strike); // 90
        //    _game.AddRoll(0);
        //    _game.AddRoll(strike); // 120
        //    _game.AddRoll(0);
        //    _game.AddRoll(strike); // 150
        //    _game.AddRoll(0);
        //    _game.AddRoll(strike); // 180
        //    _game.AddRoll(0);
        //    _game.AddRoll(strike); // 210
        //    _game.AddRoll(0);
        //    _game.AddRoll(strike); // 240
        //    _game.AddRoll(0);
        //    _game.AddRoll(strike); // 270
        //    _game.AddRoll(0);
        //    _game.AddRoll(strike); // 300

        //    Assert.That(_game.TotalScore, Is.EqualTo(300));
        //}
    }
}