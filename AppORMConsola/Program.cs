using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppORMConsola
{
    class Program
    {
        
        static void Main(string[] args)
        {
            tabla objPersona;
            string respuesta = "";
            DateTime fecha;

            objPersona = new tabla();

            Console.WriteLine("Por favor ingrese el nombre de la persona, fin para finalizar");
            respuesta = Console.ReadLine();
            objPersona.nombre = respuesta;

            while (respuesta != "fin")
            {
                Console.WriteLine("Por favor ingrese la dirección de la persona");
                objPersona.direccion = Console.ReadLine();

                Console.WriteLine("Por favor ingrese el E-Mail de la persona");
                objPersona.email = Console.ReadLine();

                objPersona.fecha_nacimiento = DateTime.Now;

                using (TallerORM_Ejemplo_1Entities db = new TallerORM_Ejemplo_1Entities())
                {
                    db.tabla.Add(objPersona);
                    db.SaveChanges();
                }

                Console.WriteLine("Por favor ingrese el nombre de la persona, fin para finalizar");
                respuesta = Console.ReadLine();
                objPersona.nombre = respuesta;

            }

            listarPersonas();
            
        }

        public static void listarPersonas()
        {
            using (TallerORM_Ejemplo_1Entities db = new TallerORM_Ejemplo_1Entities())
            {
                List <tabla> listaPersonas;

                var lst = from d in db.tabla
                          select d;

                listaPersonas = lst.ToList();

                foreach(tabla persona in listaPersonas)
                {
                    Console.WriteLine("Nombre de la persona: " + persona.nombre);
                }
            }

            Console.ReadLine();

        }
    }
}
