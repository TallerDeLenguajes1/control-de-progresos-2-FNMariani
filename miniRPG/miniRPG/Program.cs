using System;

namespace miniRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Personaje pj1 = new Personaje();
            pj1 = pj1.CrearPersonaje();
            pj1.MostrarPersonaje();
        }
    }
}
