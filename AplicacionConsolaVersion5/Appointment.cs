using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionConsolaVersion2
{
    internal class Appointment
    {
        //Attributes
        public string asunto { get; set; }
        public string lugar { get; set; }
        public int dia { get; set; }
        public int mes { get; set; }
        public int year { get; set; }
        public DateTime fecha { get; set; }

        //Constructor
        public Appointment()
        {
            Console.WriteLine("Ingrese información de su cita\n___________________");

            Console.WriteLine("Ingrese asunto");
            string asuntoAfuera = Console.ReadLine();

            bool estadoAsunto = String.IsNullOrEmpty(asuntoAfuera);

            if (!estadoAsunto) this.asunto = asuntoAfuera;

            while (estadoAsunto)
            {
                Console.WriteLine("El asunto no puede quedar vacio");
                Console.WriteLine("Ingrese asunto de su tarea");
                asuntoAfuera = Console.ReadLine();
                estadoAsunto = String.IsNullOrEmpty(asuntoAfuera);
            }
            this.asunto = asuntoAfuera;



            Console.WriteLine("Ingrese lugar de la cita");
            string lugarAfuera = Console.ReadLine();
            bool estadoLugar = String.IsNullOrEmpty(lugarAfuera);

            if (!estadoLugar) this.lugar = lugarAfuera;

            while (estadoLugar)
            {
                Console.WriteLine("El lugar de la cita no puede quedar vacio");
                Console.WriteLine("Ingrese lugar de la cita");
                lugarAfuera = Console.ReadLine();
                estadoLugar = String.IsNullOrEmpty(lugarAfuera);
             
            }

            this.lugar= lugarAfuera;

            Console.WriteLine("Ingrese el día");
            int tipoFinal;
            string input = Console.ReadLine();
            bool estado = int.TryParse(input, out tipoFinal);
            while (!estado  || tipoFinal >31 || tipoFinal <0    )
            {
                Console.WriteLine("Ingrese el día:");
                string inputWhile = Console.ReadLine();
                estado = int.TryParse(inputWhile, out tipoFinal);
            }
            this.dia = tipoFinal;

            Console.WriteLine("Ingrese el número del mes:");
            int tipoFinal2;
            string input2 = Console.ReadLine();
            bool estado2 = int.TryParse(input2, out tipoFinal2);
            while (!estado2 || tipoFinal2 > 12 || tipoFinal2 < 0)
            {
                Console.WriteLine("Ingrese el número del mes:");
                string inputWhile = Console.ReadLine();
                estado2 = int.TryParse(inputWhile, out tipoFinal2);
            }
            this.mes = tipoFinal2;

            Console.WriteLine("Ingrese el año");
            int tipoFinal3;
            string input3 = Console.ReadLine();
            bool estado3 = int.TryParse(input3, out tipoFinal3);
            while (!estado3 || tipoFinal3 < 0)
            {
                Console.WriteLine("Ingrese el año");
                string inputWhile = Console.ReadLine();
                estado3 = int.TryParse(inputWhile, out tipoFinal3);
            }
            this.year = tipoFinal3;

            this.fecha = new DateTime(this.year, this.mes, this.dia);
            Console.WriteLine(this.year);



        }
        public string info()
        {
            return $"Asunto : {this.asunto} \n Lugar: {this.lugar} \n fecha: {this.fecha.ToShortDateString()}";
        }
    }
}
