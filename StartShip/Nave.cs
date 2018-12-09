using System;
using System.Collections.Generic;
using System.Threading;

namespace StartShip
{
    public class Nave
    {
        public Int32 X { get; set; }
        public Int32 Y { get; set; }
        public Int32 Corazones { get; set; }
        public Int32 Vidas { get; set; }
        public List<Bala> balas { get; set; }

        public Nave(Int32 x, Int32 y, Int32 corazones, Int32 vidas)
        {
            X = x;
            Y = y;
            Corazones = corazones;
            Vidas = vidas;
            balas = new List<Bala>();
        }

        public void COR()
        {
            Corazones--;
        }

        public void Pintar()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("  ▲  ");
            Console.SetCursorPosition(X, Y + 1);
            Console.Write(" (╧) ");
            Console.SetCursorPosition(X, Y + 2);
            Console.Write("▲╛ ╛▲");
        }

        public void Borrar()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("        ");
            Console.SetCursorPosition(X, Y + 1);
            Console.Write("        ");
            Console.SetCursorPosition(X, Y + 2);
            Console.Write("        ");
        }

        public void Mover(ConsoleKeyInfo tecla)
        {

            if (tecla.Key == ConsoleKey.Spacebar)
                Disparar();

            Borrar();

            if (tecla.Key == ConsoleKey.LeftArrow && X > 3)
                X--;
            if (tecla.Key == ConsoleKey.UpArrow && Y > 4)
                Y--;
            if (tecla.Key == ConsoleKey.RightArrow && X + 3 < 72)
                X++;
            if (tecla.Key == ConsoleKey.DownArrow && Y + 3 < 33)
                Y++;

            Pintar();
        }

        private void Disparar()
        {
            balas.Add(new Bala(X + 2, Y - 1));
        }

        public void PintarCorazones()
        {
            Console.SetCursorPosition(50, 2);
            Console.Write("VIDAS {0}", Vidas);
            Console.SetCursorPosition(64, 2);
            Console.Write("Salud");
            Console.SetCursorPosition(70, 2);
            Console.Write("      ");

            for (int i = 0; i < Corazones; i++)
            {
                Console.SetCursorPosition(70 + i, 2);
                Console.Write("♥");
            }
        }

        public void Morir()
        {
            if (Corazones == 0)
            {
                Borrar();
                Console.SetCursorPosition(X, Y);
                Console.Write("   **   ");
                Console.SetCursorPosition(X, Y + 1);
                Console.Write("  ****  ");
                Console.SetCursorPosition(X, Y + 2);
                Console.Write("   **   ");

                Thread.Sleep(200);
                Borrar();

                Console.SetCursorPosition(X, Y);
                Console.Write(" * ** *");
                Console.SetCursorPosition(X, Y + 1);
                Console.Write("  **** ");
                Console.SetCursorPosition(X, Y + 2);
                Console.Write(" * ** *");

                Thread.Sleep(200);
                Borrar();

                Vidas--;
                Corazones = 3;
                PintarCorazones();
                Pintar();

            }
        }

    }
}
