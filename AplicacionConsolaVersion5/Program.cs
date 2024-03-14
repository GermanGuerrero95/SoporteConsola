using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Xml.Schema;


namespace AplicacionConsolaVersion2
{
    internal class Program
    {
        static List<Appointment> appointmentsList = new List<Appointment>();
        static List<MyTask> taskList = new List<MyTask>();
        static void Main(string[] args)
        {
            Console.WriteLine("\n\t\r\n░█████╗░░██████╗░███████╗███╗░░██╗██████╗░░█████╗░\r\n██╔══██╗██╔════╝░██╔════╝████╗░██║██╔══██╗██╔══██╗\r\n███████║██║░░██╗░█████╗░░██╔██╗██║██║░░██║███████║\r\n██╔══██║██║░░╚██╗██╔══╝░░██║╚████║██║░░██║██╔══██║\r\n██║░░██║╚██████╔╝███████╗██║░╚███║██████╔╝██║░░██║\r\n╚═╝░░╚═╝░╚═════╝░╚══════╝╚═╝░░╚══╝╚═════╝░╚═╝░░╚═╝\n");

            Console.WriteLine("██╗░░░██╗███████╗██████╗░░██████╗██╗░█████╗░███╗░░██╗  ███████╗░░░░█████╗░");
            Console.WriteLine("██║░░░██║██╔════╝██╔══██╗██╔════╝██║██╔══██╗████╗░██║  ██╔════╝░░░██╔══██╗");
            Console.WriteLine("╚██╗░██╔╝█████╗░░██████╔╝╚█████╗░██║██║░░██║██╔██╗██║  ██████╗░░░░██║░░██║");
            Console.WriteLine("░╚████╔╝░██╔══╝░░██╔══██╗░╚═══██╗██║██║░░██║██║╚████║  ╚════██╗░░░██║░░██║");
            Console.WriteLine("░░╚██╔╝░░███████╗██║░░██║██████╔╝██║╚█████╔╝██║░╚███║  ██████╔╝██╗╚█████╔╝");
            Console.WriteLine("░░░╚═╝░░░╚══════╝╚═╝░░╚═╝╚═════╝░╚═╝░╚════╝░╚═╝░░╚══╝  ╚═════╝░╚═╝░╚════╝░");
            //Welcome Message :)
            int hora = DateTime.Now.Hour;

            Console.WriteLine(((hora >= 00 && hora <= 12) ? "\tBuenos días \n" : (hora >= 13 && hora <= 18) ? "\tBuenas tardes \n" : "\tBuenas noches\n"));

            //Menu
            Console.WriteLine("1.Crear una cita \n2.Crear una tarea \n3.Ver agenda del día \n4.Finalizar una tarea \n5.Salir");

            int optionMenu = int.Parse(Console.ReadLine());

            switch (optionMenu)
            {
                case 1:
                    Appointment appointment = new Appointment();
                    appointmentsList.Add(appointment);
                    Console.WriteLine("¡Cita ingresada exitosamente!");
                    Program.Main(args);
                    break;
                case 2:
                    MyTask personalTask = new MyTask();
                    taskList.Add(personalTask);
                    //Console.WriteLine(personalTask.info());
                    Console.WriteLine("¡Tarea ingresada exitosamente!");
                    Program.Main(args);
                    break;
                case 3:
                    if(appointmentsList.Count == 0 && taskList.Count == 0)
                    {
                        Console.WriteLine("No hay tareas ni citas asiganadas");
                        Program.Main(args);
                    }
                    Console.WriteLine("Ver agenda \nSeleccione fecha \n1.Hoy \n2.Ayer\n3.Mañana \n4.Ingrese fecha en especifico \n5.Salir");

                    int optionFecha = int.Parse( Console.ReadLine());

                   switch (optionFecha)
                    {
                        case 1:
                            imprimirHoy();
                            Program.Main(args);
                            break;
                        case 2:
                            imprimirAyer();
                            Program.Main(args);
                            break;
                        case 3:
                            imprimirTomorrow();
                            Program.Main(args);
                            break;
                        case 4:
                            Console.WriteLine("Ingrese dia");
                            int dia = int.Parse(Console.ReadLine());
                            Console.WriteLine("Ingrese mes");
                            int mes = int.Parse(Console.ReadLine());
                            Console.WriteLine("Ingrese año");
                            int year = int.Parse(Console.ReadLine());
                            //Citas

                            foreach (Appointment item in appointmentsList.FindAll(item => item.fecha == new DateTime(year, mes, dia)))
                            {


                                Console.WriteLine("Citas encontradas");
                                Console.WriteLine(item.info());

                            }

                            //Tareas


                            foreach (MyTask item in taskList.FindAll(item=>item.fecha == new DateTime(year, mes, dia)))
                            {
                                
                   
                                    Console.WriteLine("Tareas encontradas");
                                    Console.WriteLine(item.info());
                                
                            }
                            Program.Main(args);
                            break;
                       case 5: Program.Main(args); break;
                      
                    }

                    break;
                case 4:
                    
                    if(taskList.Count== 0)
                    {
                        Console.WriteLine("No hay tareas agendadas");
                        Program.Main(args);
                    }

                    showAllTask();

                    Console.WriteLine("¿Que tarea desea finalizar?");

                    int indexBorrar = int.Parse(Console.ReadLine()) ;

                    Console.WriteLine("¿Esta seguro de su operacion S/N?");

                    char answer = Char.Parse(Console.ReadLine().ToLower());
                    switch (answer)
                    {
                        case 's':
                            try
                            {
                                taskList.RemoveAt(indexBorrar);
                                Console.WriteLine($"¡Tarea # {indexBorrar} ha sido eliminada correctamente!");
                                if (taskList.Count == 0) Console.WriteLine("******* NO HAY TAREAS DISPONIBLES ***********");
                                foreach (MyTask x in taskList)
                                {                                   
                                 Console.WriteLine("Tareas restantes --->\n");
                                 Console.WriteLine(x.info());                                 
                                }
                                Program.Main(args);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                Program.Main(args);

                            }
                            break;
                        case 'n':
                            Console.WriteLine("Tarea declinada");
                            Program.Main(args);
                            break;
                        default:
                            Console.WriteLine("Error");
                            Program.Main(args);
                            break;
                    }

                    break;
                case 5:
                    Environment.Exit(0);
                    break;

            }
            Console.ReadLine();
        }
        static void imprimirHoy()
        {

            if(taskList.Count == 0 && appointmentsList.Count ==0 ) Console.WriteLine("No hay citas ni tareas para hoy");
            if(appointmentsList.Count== 0) Console.WriteLine("No hay citas para el día de hoy");
            if (taskList.Count == 0) Console.WriteLine("No hay tareas agendadas para el día de hoy");


            foreach (Appointment x in appointmentsList.FindAll(x => x.fecha.Day == DateTime.Now.Day))
            {
                Console.WriteLine("******** La cita de hoy   *******");
                Console.WriteLine(x.info());
            }

            foreach (MyTask x in taskList.FindAll(x => x.fecha.Day == DateTime.Now.Day))
            {
                Console.WriteLine("******** La tareas de hoy  *******");
                Console.WriteLine(x.info());
            }
        }
        static void imprimirAyer()
        {
            if (taskList.Count == 0 && appointmentsList.Count == 0) Console.WriteLine("No había citas ni tareas para ayer");
            if (appointmentsList.Count == 0) Console.WriteLine("No había citas para ayer");
            if (taskList.Count == 0) Console.WriteLine("No había tareas para ayer");

            foreach (Appointment x in appointmentsList.FindAll(x => x.fecha.Day == DateTime.Now.Day-1 && x.fecha.Month == DateTime.Now.Month && x.fecha.Year == DateTime.Now.Year ))
            {
                Console.WriteLine("******** La cita del día de ayer   *******");
                Console.WriteLine(x.info());
            }

            foreach (MyTask x in taskList.FindAll(x => x.fecha.Day == DateTime.Now.Day - 1 && x.fecha.Month == DateTime.Now.Month && x.fecha.Year == DateTime.Now.Year))
            {
                Console.WriteLine("******** La tarea del día de ayer  *******");
                Console.WriteLine(x.info());
            }
        }

        static void imprimirTomorrow()
        {
            if (taskList.Count == 0 && appointmentsList.Count == 0) Console.WriteLine("No hay citas ni tareas para mañana");
            if (appointmentsList.Count == 0) Console.WriteLine("No hay citas para mañana");
            if (taskList.Count == 0) Console.WriteLine("No hay tareas agendadas para mañana");


            foreach (Appointment x in appointmentsList.FindAll(x => x.fecha.Day == DateTime.Now.Day + 1 && x.fecha.Month == DateTime.Now.Month && x.fecha.Year == DateTime.Now.Year))
            {
                Console.WriteLine("******** La cita del día de mañana   *******");
                Console.WriteLine(x.info());
            }

            foreach (MyTask x in taskList.FindAll(x => x.fecha.Day == DateTime.Now.Day + 1 && x.fecha.Month == DateTime.Now.Month && x.fecha.Year == DateTime.Now.Year))
            {


                Console.WriteLine("******** La tarea del día de mañana   *******");
                Console.WriteLine(x.info());
            }
        }

        static void showAllTask()
        {
            // *** Lista de tareas ***
            foreach (MyTask x in taskList)
            {
                if(x.estado == "Pendiente") Console.WriteLine($" Tarea pendiente-->  {taskList.IndexOf(x)}.{x.summary()}");
                else Console.WriteLine($" Tarea Activa-->  {taskList.IndexOf(x)}.{x.summary()}");
            }           
        }

        
    }
}3

