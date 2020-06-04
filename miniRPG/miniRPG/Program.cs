using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace miniRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            int cantidadDeRondas = 3;
            Random r = new Random();
            Personaje primerPJ, segundoPJ;
            int cantidadDePersonajes = 5;

            LinkedList<Personaje> listaDePersonajes = new LinkedList<Personaje>();

            for (int i = 0; i < cantidadDePersonajes; i++)
            {
                Personaje pj = new Personaje();
                pj = pj.CrearPersonaje();
                listaDePersonajes.AddLast(pj);
            }

            while(listaDePersonajes.Count > 1)
            {
                //Personaje 1
                Personaje pj1 = new Personaje();
                //pj1 = pj1.CrearPersonaje();
                //pj1.MostrarPersonaje();

                //Personaje 2
                Personaje pj2 = new Personaje();
                //pj2 = pj2.CrearPersonaje();
                //pj2.MostrarPersonaje();

                //Lista enlazada con los personajes
                pj1 = listaDePersonajes.ElementAt(0);
                pj2 = listaDePersonajes.ElementAt(1);

                //Empieza de manera aleatoria el P1 o el P2
                if (r.Next(2) == 0)
                {
                    primerPJ = pj1;
                    segundoPJ = pj2;
                }
                else
                {
                    primerPJ = pj2;
                    segundoPJ = pj1;
                }

                //Rondas del juego
                for (int i = 1; i <= cantidadDeRondas; i++)
                {
                    Console.WriteLine("Ronda N°" + i);
                    CalcularRonda(primerPJ, segundoPJ);
                    if(segundoPJ.Salud > 0)
                    {
                        CalcularRonda(segundoPJ, primerPJ);
                    }
                    else
                    {
                        Console.WriteLine(segundoPJ.Nombre + " HA MUERTO!");
                    }
                    Console.WriteLine("");

                    //Comprobamos si algun personaje muere
                    if (pj1.Salud <= 0 || pj2.Salud <= 0)
                    {
                        break;
                    }
                }

                //Mostramos la salud final de cada uno
                Console.WriteLine("FINAL");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(pj1.Nombre + " el " + pj1.Tipo + " tiene " + pj1.Salud + " puntos de salud!");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(pj2.Nombre + " el " + pj2.Tipo + " tiene " + pj2.Salud + " puntos de salud!");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                if (pj1.Salud > pj2.Salud)
                {
                    Console.WriteLine("El ganador es: " + pj1.Nombre + " el " + pj1.Tipo);
                    listaDePersonajes.Remove(pj2);
                    pj1.Salud += 10;
                    Console.WriteLine(pj1.Nombre + " recupera 10 de salud: " + " salud actual: " + pj1.Salud);
                }
                else if (pj1.Salud < pj2.Salud)
                {
                    Console.WriteLine("El ganador es: " + pj2.Nombre + " el " + pj2.Tipo);
                    listaDePersonajes.Remove(pj1);
                    pj2.Salud += 10;
                    Console.WriteLine(pj2.Nombre + " recupera 10 de salud." + " Salud actual: " + pj2.Salud);
                }
                else
                {
                    Console.WriteLine("Tenemos un EMPATE");
                }
                Console.ResetColor();
                Console.WriteLine("");
            }

            //Mostramos la Lista
            Console.WriteLine("\nEL GANADOR ES:");
            foreach (Personaje pj in listaDePersonajes)
            {
                pj.MostrarPersonaje();
            }
        }

        static void CalcularRonda(Personaje pjAtaca, Personaje pjDefiende)
        {
            //Poder de Disparo - Efectividad de Disparo - Valor de Ataque - 
            //Poder de Defensa - Maximo daño provocable - Daño provocado
            float pd, ed, va, pdef, mdp, danio = 0;
            Random r = new Random();

            //Valores de ataque
            pd = pjAtaca.Destreza * pjAtaca.Fuerza * pjAtaca.Nivel;
            ed = (r.Next(100) + 1);
            va = pd * ed;

            //Valores de defensa
            pdef = pjDefiende.Armadura * pjDefiende.Velocidad;

            mdp = 50000;

            danio = ((va - pdef) / mdp) * 100;            

            //Restamos el danio a la salud del personaje que se defiende
            pjDefiende.Salud -= (int)danio;

            //Mostramos resultados de la ronda
            Console.WriteLine("\n" + pjAtaca.Nombre + " el " + pjAtaca.Tipo + " ataca!");
            Console.WriteLine("Produce: " + (int)danio + " de daño");
            Console.WriteLine(pjDefiende.Nombre + " tiene " + pjDefiende.Salud + " puntos de salud!");
        }
    }
}
