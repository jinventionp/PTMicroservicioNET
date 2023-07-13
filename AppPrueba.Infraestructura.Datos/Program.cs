using System;

using Prueba.Infraestructura.Datos.Contextos;

namespace Prueba.Infraestructura.Datos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creando DB");
            PruebaContexto db = new PruebaContexto();
            db.Database.EnsureCreated();
            Console.WriteLine("DB Creada");
            Console.ReadKey();
        }
    }
}
