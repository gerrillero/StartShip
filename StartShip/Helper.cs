using System;

namespace StartShip
{
    public static class Helper
    {

        public static void PintarLimites()
        {
            // Lineas horinzontales
            for (int i = 2; i < 78; i++)
            {
                Console.SetCursorPosition(i, 3);
                Console.Write("═");
                Console.SetCursorPosition(i, 33);
                Console.Write("═");
            }

            // Lineas verticales
            for (int i = 4; i < 33; i++)
            {
                Console.SetCursorPosition(2, i);
                Console.Write("║");
                Console.SetCursorPosition(77, i);
                Console.Write("║");
            }

            // Esquinas
            Console.SetCursorPosition(2, 3);
            Console.Write("╔");
            Console.SetCursorPosition(2, 33);
            Console.Write("╚");
            Console.SetCursorPosition(77, 3);
            Console.Write("╗");
            Console.SetCursorPosition(77, 33);
            Console.Write("╝");
        }
    }
}
