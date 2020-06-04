using System;
using System.Collections.Generic;
using System.Text;

namespace miniRPG
{
    public enum TipoDePersonaje
    {
        Arquero,
        Barbaro,
        Bardo,
        Guerrero,
        Mago,
        Orco
    }
    enum ValoresMaximos
    {
        velocidadMax = 10,
        destrezaMax = 5,
        fuerzaMax = 10,
        nivelMax = 10,
        armaduraMax = 10
    }

    public class Personaje
    {
        string[] nombres = new String[5] { "Brock", "Paul", "Marshall", "Lorna", "Armand" };
        string[] apodos = new String[5] { "Br.", "Paul", "Mar", "Lorny", "Army" };

        //Datos
        private TipoDePersonaje tipo;
        private string nombre;
        private string apodo;
        private DateTime fechaNac;
        private int edad; //entre 0 a 300
        private int salud; //100

        //Caracteristicas
        private int velocidad; //1 a 10
        private int destreza; //1 a 5
        private int fuerza; //1 a 10
        private int nivel; //1 a 10  
        private int armadura; //1 a 10

        public Personaje(){}

        public TipoDePersonaje Tipo { get => tipo; set => tipo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apodo { get => apodo; set => apodo = value; }
        public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
        public int Edad { get => edad; set => edad = value; }
        public int Salud { get => salud; set => salud = value; }
        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int Destreza { get => destreza; set => destreza = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Armadura { get => armadura; set => armadura = value; }

        public Personaje CrearPersonaje()
        {
            Random r = new Random();
            Personaje pj = new Personaje();

            Array values = Enum.GetValues(typeof(TipoDePersonaje));

            pj.Tipo = (TipoDePersonaje)values.GetValue(r.Next(values.Length));
            int rNumber = r.Next(0, (values.Length-1));
            pj.nombre = nombres[rNumber];
            pj.apodo = apodos[rNumber];
            pj.fechaNac = new DateTime(DateTime.Now.Year - 300, DateTime.Now.Month, DateTime.Now.Day).AddDays(r.Next(365 * 300));
            //Edad sin compensacion por mes
            pj.edad = DateTime.Now.Year - pj.fechaNac.Year;
            pj.salud = 100;
            pj.velocidad = r.Next((int)ValoresMaximos.velocidadMax) + 1;
            pj.destreza = r.Next((int)ValoresMaximos.destrezaMax) + 1;
            pj.fuerza = r.Next((int)ValoresMaximos.fuerzaMax) + 1;
            pj.nivel = r.Next((int)ValoresMaximos.nivelMax) + 1;
            pj.armadura = r.Next((int)ValoresMaximos.armaduraMax) + 1;

            return pj;
        }

        public void MostrarPersonaje()
        {
            //Datos
            Console.WriteLine("DATOS");
            Console.WriteLine("Tipo: " + Tipo);
            Console.WriteLine("Nombre: " + nombre);
            Console.WriteLine("Apodo: " + apodo);
            Console.WriteLine("FechaNac: " + fechaNac);
            Console.WriteLine("Edad: " + edad);
            Console.WriteLine("Salud: " + salud);

            //Caracteristicas
            Console.WriteLine("\nCARACTERISTICAS");
            Console.WriteLine("Velocidad: " + velocidad);
            Console.WriteLine("Destreza: " + destreza);
            Console.WriteLine("Fuerza: " + fuerza);
            Console.WriteLine("Nivel: " + nivel);
            Console.WriteLine("Armadura: " + armadura);
        }
    }
}
