using System.Reflection;

namespace ColaConsultorio
{
    //Class Hospital
    public class Hospital
    {
               /* private ColaPacientes[]? adultos;
        private ColaPacientes[]? ninios;
        private Medico? general;
        private Medico? pediatra;*/

        private ColaPacientes[,] colaPacientes;
        private Medico[] medico;

        //Constructor
        public Hospital()
        {
            colaPacientes = new ColaPacientes[2, 5];
            for(int i = 0 ; i< 2; i++){
                for (int j = 0; j < 5; j++)
                {
                    colaPacientes[i,j] = new ColaPacientes();

                }

            }


            medico = new Medico[2];
            medico[0] = new Medico("Lenin", "Figeroa", 23, 23215546, "General");
            medico[1] = new Medico("Maikol", "Penia", 23, 27275746, "Pediatria");

            /* general = new Medico("Lenin", "Figueroa", 23, 23215546, "General");
             pediatra = new Medico("Maikol", "Penia", 23, 27275746, "Pediatria");
             adultos = new ColaPacientes[5];
             ninios = new ColaPacientes[5];

             for (int i = 0; i < 5; i++)
             {
                 adultos[i] = new ColaPacientes();
                 ninios[i] = new ColaPacientes();
             }*/

        }

        //Getters y Setters
        /*internal Medico General { get => general; set => general = value; }
        internal Medico Pediatra { get => pediatra; set => pediatra = value; }
        internal ColaPacientes[] Adultos { get => adultos; set => adultos = value; }
        internal ColaPacientes[] Ninios { get => ninios; set => ninios = value; }*/

        internal Medico[] Medico { get => medico; set => medico = value; }
        internal ColaPacientes[,] ColaPacientes{ get => colaPacientes; set => colaPacientes = value;}





        public void InsertarPaciente()
        {



            Console.WriteLine("Ingrese los datos del Paciente ");

            Console.WriteLine("Nombre: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("Apellido: ");
            string apellido = Console.ReadLine();

            Console.WriteLine("Cedula: ");
            int cedula = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Edad: ");
            int edad = Convert.ToInt32(Console.ReadLine());

            Paciente pacienteNuevo = new Paciente(nombre, apellido, edad, cedula);

            Console.WriteLine($"El paciente Necesita ir a Cola de {Caso(pacienteNuevo.Prioridad)}");

            if (pacienteNuevo.Edad <= 15)
            {
                //ninios[pacienteNuevo.Prioridad].Push(pacienteNuevo);
                colaPacientes[0, pacienteNuevo.Prioridad].Push(pacienteNuevo);
            }
            else
            {
                //adultos[pacienteNuevo.Prioridad].Push(pacienteNuevo);
                colaPacientes[1, pacienteNuevo.Prioridad].Push(pacienteNuevo);
            }
        }


        public void AtenderPaciente()
        {
            medico[0].PacienteAtendido();
            medico[1].PacienteAtendido();


            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; medico[i].Paciente == null || j < 5; j++) {
                    medico[i].AtenderPaciente(colaPacientes[i, j].Pop()); }

            }

            /*
            general.PacienteAtendido();
            pediatra.PacienteAtendido();


            for (int i = 0; general.Paciente == null || i < 5; i++)
            {
                general.AtenderPaciente(Adultos[i].Pop());
            }

            for (int i = 0; pediatra.Paciente == null || i < 5; i++)
            {
                pediatra.AtenderPaciente(Ninios[i].Pop());
            }
*/
        }


        public string Caso(int prioridad)
        {
            switch (prioridad)
            {
                case 0:
                    return "Accidentes Aparatosos";
                case 1:
                    return "Infartos";
                case 2:
                    return "Afeccion Respiratoria";
                case 3:
                    return "Partos";
                case 4:
                    return "Consulta general";
                default:
                    return "Prioridad no válida";
            }
        }

        public void GenerarReporte()
        {
            Console.WriteLine("REPORTE MEDICO ACTUAL");
            Console.WriteLine("|||||||||||||||||||||||||||||||||||||||\n");
            Console.WriteLine("Medico Pediatra");
            //general.MostrarPaciente();
            medico[0].MostrarPaciente();
            Console.WriteLine($"--------------------------------------\n ");
            Console.WriteLine("Medico General ");
            //pediatra.MostrarPaciente();
            medico[1].MostrarPaciente();
            Console.WriteLine($"|||||||||||||||||||||||||||||||||||||| \n");
            ColaPacientes colaAuxiliar = new ColaPacientes();
            Paciente pacienteAuxiliar;

            for (int i = 0; i < 2; i++)
            {
                if(i == 0) Console.WriteLine("COLAS DE NIÑOS \n");
                else Console.WriteLine("COLAS DE ADULTOS \n ");

                for (int j = 0; j < 5; j++)
                {
                    if (colaPacientes[i, j].Vacia())
                    {
                        Console.WriteLine($"Vacia la cola de {Caso(j)}");
                    }
                    else
                    {
                        Console.WriteLine($"Pacientes en cola de {Caso(j)}");
                        while (!colaPacientes[i, j].Vacia())
                        {
                            pacienteAuxiliar = colaPacientes[i, j].Pop();
                            pacienteAuxiliar.MostrarDatos();
                            colaAuxiliar.Push(pacienteAuxiliar);
                        }
                        while (!colaAuxiliar.Vacia())
                        {
                            colaPacientes[i, j].Push(colaAuxiliar.Pop());
                        }
                    }

                }
            }



            /*

            Console.WriteLine("COLAS DE NIÑOS");
            for (int i = 0; i < 5; i++)
            {
                if (Ninios[i].Vacia())
                {
                    Console.WriteLine($"Vacia la cola de {Caso(i)}");
                }
                else
                {
                    Console.WriteLine($"Pacientes en cola de {Caso(i)}");
                    while (!Ninios[i].Vacia())
                    {
                        pacienteAuxiliar = Ninios[i].Pop();
                        pacienteAuxiliar.MostrarDatos();
                        colaAuxiliar.Push(pacienteAuxiliar);
                    }
                    while (colaAuxiliar.Vacia())
                    {
                        Ninios[i].Push(colaAuxiliar.Pop());
                    }
                }

            }

            Console.WriteLine($"||||||||||||||||||||||||||||||||||||||");
            Console.WriteLine("COLAS DE ADULTOS");
            for (int i = 0; i < 5; i++)
            {
                if (Adultos[i].Vacia())
                {
                    Console.WriteLine($"Vacia la cola de {Caso(i)}");
                }
                else
                {
                    Console.WriteLine($"Pacientes en cola de {Caso(i)}");
                    while (!Adultos[i].Vacia())
                    {
                        pacienteAuxiliar = Adultos[i].Pop();
                        pacienteAuxiliar.MostrarDatos();
                        colaAuxiliar.Push(pacienteAuxiliar);
                    }
                    while (colaAuxiliar.Vacia())
                    {
                        Adultos[i].Push(colaAuxiliar.Pop());
                    }
                }
            }

            Console.WriteLine($"||||||||||||||||||||||||||||||||||||||");
*/
        }

        public void Menu()
        {
            string opcion = "0";

            do
            {
                Console.WriteLine("Consultorio medico ");
                Console.WriteLine("1.Nuevo Paciente");
                Console.WriteLine("2.Atender Pacientes");
                Console.WriteLine("3.Generar reporte ");
                Console.WriteLine("4.CERRAR SISTEMA ");
                Console.Write("Ingrese una Opcion por favor : ");

                opcion = Console.ReadLine();
                Console.Clear();
                switch (opcion)
                {
                    case "1":
                        InsertarPaciente();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "2":
                        AtenderPaciente();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "3":
                        GenerarReporte();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Por Favor ingrese una Opcion validad");
                        break;
                }

            } while (opcion != "4");

        }

    }
}
