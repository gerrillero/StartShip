using System;

namespace StartShip
{
    public class Bala
    {
        public Int32 X { get; set; }
        public Int32 Y { get; set; }

        public Bala(Int32 x, Int32 y)
        {
            X = x;
            Y = y;
        }

        public void Mover()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" "); // Primero hay que Borrar
            // if (y > 4) y--; Ya se encarga el metodo fuera
            Y--;

            Console.SetCursorPosition(X, Y);
            Console.Write("*");
        }

        public Boolean Fuera()
        {
            if (Y == 4)
                return true;
            return false;
        }
    }
}
