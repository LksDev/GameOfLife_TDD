using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavensburgerSpielewelt {
    public class GameOfLife {
    
        public Zelle[] Spielfeld { get; private set; }

        public GameOfLife() {

        }
        public void NewGame(int x, int y) {
            int count = x * y;
            Spielfeld = new Zelle[count];
            int currentZelle = 0;

            for (int i = 0; i < y; i++) {
                for (int j   = 0; j < x; j++) {

                    Spielfeld[currentZelle] = new Zelle(i, j, Status.Death);
                    currentZelle++;
                        
                }
            }
        }

        public void ExecuteNextMove() {

            Zelle[] nextSpielfeld = new Zelle[Spielfeld.Length];

            for (int currentZelle = 0; currentZelle < Spielfeld.Length; currentZelle++) {
                for (int index = 0; index < Spielfeld.Length; index++) {

                    nextSpielfeld[currentZelle] = (Zelle)Spielfeld[currentZelle].Clone();
                    nextSpielfeld[currentZelle].Zustand = NextStatus(Spielfeld[currentZelle], Spielfeld);
                }
            }

            Spielfeld = nextSpielfeld;
        }

        public Status NextStatus(Zelle currentZelle, Zelle[] spielfeld) {

            int neighbourLife = 0;
            for (int index = 0; index < Spielfeld.Length; index++) {


                if (currentZelle.Spalte.Equals(Spielfeld[index].Spalte)
                    &&
                    currentZelle.Zeile.Equals(Spielfeld[index].Zeile)) {
                    continue;
                }

                if (Math.Abs(currentZelle.Spalte - spielfeld[index].Spalte) <= 1 
                    &&
                    Math.Abs(currentZelle.Zeile - spielfeld[index].Zeile) <= 1
                    && spielfeld[index].Zustand == Status.Life) {

                    ++neighbourLife;

                }

            }

            if(neighbourLife <2 || neighbourLife >3) {
                return Status.Death;
            }
            return Status.Life;


        }

        public void DisplaySpielfeld() {

            for (int index = 0; index < Spielfeld.Length; index++) {

                if (Spielfeld[index].Spalte == 0 && index > 0) {
                    Console.WriteLine();
                }

                if (Spielfeld[index].Zustand == Status.Life) {
                    Console.Write($"[ x ]");

                } else {
                    Console.Write($"[   ]");

                }



            }


            Console.WriteLine();
            Console.WriteLine("".PadRight(30, '*'));
        }
    }



    public enum Status {
        Death,
        Life
    }

    public class Zelle : ICloneable {
        public int Zeile { get; set; }
        public int Spalte { get; set; }

        public Status Zustand { get; set; } = Status.Death;

        public Zelle(int zeile, int spalte, Status zustand) {
            Zeile = zeile;
            Spalte = spalte;
            Zustand = zustand;
        }

        public object Clone() {
            if(Zustand == Status.Life) {
                return new Zelle(this.Zeile, this.Spalte, Status.Life);

            }
            return new Zelle(this.Zeile, this.Spalte, Status.Death);

        }
    }
}
