using System;

namespace StartShip
{
    public class Asteroide
    {
        public Int32 X { get; set; }
        public Int32 Y { get; set; }

        private Random rand = new Random();

        public Asteroide(Int32 x, Int32 y)
        {
            X = x;
            Y = y;
        }

        public void Pintar()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("Θ");
        }

        public void Mover()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" "); // Primero hay que Borrar
            Y++; // Para que vaya cayendo

            // Para que no se salga de los margenes
            if (Y > 32)
            {
                X = rand.Next(4, 75); // Para que nos de un numero aleatorio entre 4 y 75
                Y = 4; // Para volver a subirlo
            }

            Pintar();
        }

        public void Choque(Nave nave)
        {
            if (X >= nave.X && X < nave.X + 5 && Y >= nave.Y && Y <= nave.Y + 2)
            {
                nave.COR();
                nave.Pintar();
                nave.PintarCorazones();

                X = rand.Next(4, 75); // Para que nos de un numero aleatorio entre 4 y 75
                Y = 4; // Para volver a subirlo
            }
        }
    }
}
