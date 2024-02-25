using RavensburgerSpielewelt;

namespace UnitTest {
    public class Tests {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void NewGameCreate() {
            
            GameOfLife game = new GameOfLife();
            game.NewGame(3, 3);
            
            Assert.AreEqual(9, game.Spielfeld.Count());
        }


        [Test]
        public void ZelleDeath() {

            GameOfLife game = new GameOfLife();
            game.NewGame(3, 3);

            game.Spielfeld[4].Zustand = Status.Life;

            var result = game.NextStatus(game.Spielfeld[4], game.Spielfeld);

            Assert.That(result, Is.EqualTo(Status.Death));
        }



        [Test]
        public void ZelleLife() {

            GameOfLife game = new GameOfLife();
            game.NewGame(3, 3);

            game.Spielfeld[4].Zustand = Status.Life;
            game.Spielfeld[5].Zustand = Status.Life;
            game.Spielfeld[2].Zustand = Status.Life;

            var result = game.NextStatus(game.Spielfeld[4], game.Spielfeld);

            Assert.That(result, Is.EqualTo(Status.Life));
        }



        [Test]
        public void ZelleLifeToDeath() {

            GameOfLife game = new GameOfLife();
            game.NewGame(3, 3);

            game.Spielfeld[4].Zustand = Status.Life;
            game.Spielfeld[5].Zustand = Status.Life;
            game.Spielfeld[2].Zustand = Status.Life;
            game.Spielfeld[1].Zustand = Status.Life;

            var result = game.NextStatus(game.Spielfeld[4], game.Spielfeld);

            Assert.That(result, Is.EqualTo(Status.Death));
        }



        [Test]
        public void DisplaySpielfeld() {

            GameOfLife game = new GameOfLife();
            game.NewGame(3, 3);

            game.Spielfeld[4].Zustand = Status.Life;
            game.Spielfeld[5].Zustand = Status.Life;

            Assert.DoesNotThrow(game.DisplaySpielfeld);
        }



        [Test]
        public void PlayGame() {

            GameOfLife game = new GameOfLife();
            game.NewGame(3, 3);

            game.Spielfeld[0].Zustand = Status.Life;
            game.Spielfeld[3].Zustand = Status.Life;
            game.Spielfeld[6].Zustand = Status.Life;
            //game.Spielfeld[2].Zustand = Status.Life;
            game.DisplaySpielfeld();

            for (int i = 0; i < 10; i++) {
                game.ExecuteNextMove();
                game.DisplaySpielfeld();

            }

            Assert.Pass();
        }

    }
}