using StartShip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StartShip
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.WindowHeight = 40;
            Console.WindowWidth = 80;


            Helper.PintarLimites();

            Nave nave1 = new Nave(37, 30, 3, 3);
            nave1.Pintar();
            nave1.PintarCorazones();


            Random rand = new Random();
            Boolean gameOver = false;
            Int32 puntos = 0;

            List<Asteroide> asteroides = new List<Asteroide>();

            for (int i = 0; i < 5; i++)
            {
                asteroides.Add(new Asteroide(rand.Next(3, 74), rand.Next(4, 5)));
            }

            while (!gameOver)
            {
                Console.SetCursorPosition(4, 2);
                Console.Write("Puntos {0}", puntos);

                //nave1.Mover();
                //nave1.Disparar();


                for (int i = 0; i < asteroides.Count; i++)
                {
                    asteroides[i].Mover();
                    asteroides[i].Choque(nave1);
                }

                for (int i = 0; i < asteroides.Count; i++)
                {
                    for (int j = 0; j < nave1.balas.Count; j++)
                    {
                        if (asteroides[i].X == nave1.balas[j].X && asteroides[i].Y + 1 == nave1.balas[j].Y || asteroides[i].Y == nave1.balas[j].Y)
                        {
                            Console.SetCursorPosition(nave1.balas[j].X, nave1.balas[j].Y);
                            Console.WriteLine(" ");
                            nave1.balas.Remove(nave1.balas[j]);

                            asteroides.Add(new Asteroide(rand.Next(3, 74), 4));
                            Console.SetCursorPosition(asteroides[i].X, asteroides[i].Y);
                            Console.WriteLine(" ");
                            asteroides.Remove(asteroides[i]);

                            puntos += 5;
                        }
                    }
                }

                if (nave1.Vidas == 0)
                    gameOver = true;

                nave1.Morir();
                //nave1.Mover();

                Thread.Sleep(30);
            }

            Console.Read();
        }
    }
}
