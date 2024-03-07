using System.Reflection;

namespace ColaConsultorio
{
    //Class Hospital
    public class Hospital
    {
        private ColaPacientes[,] colaPacientes;
        private Medico[] medico;

        //Constructor
        public Hospital()
        {
            colaPacientes = new ColaPacientes[2, 5];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    colaPacientes[i, j] = new ColaPacientes();

                }

            }

            medico = new Medico[2];
            medico[0] = new Medico("Lenin", "Figeroa", 23, 23215546, "General");
            medico[1] = new Medico("Maikol", "Penia", 23, 27275746, "Pediatria");

        }

        internal Medico[] Medico { get => medico; set => medico = value; }
        internal ColaPacientes[,] ColaPacientes { get => colaPacientes; set => colaPacientes = value; }

        public void InsertarPaciente()
        {
            Console.WriteLine("Ingrese los datos del Paciente ");

            Console.WriteLine("Nombre: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("Apellido: ");
            string apellido = Console.ReadLine();

            int cedula;
            bool cedulaValida = false;
            do
            {
                Console.WriteLine("Cedula: ");
                if (int.TryParse(Console.ReadLine(), out cedula))
                {
                    cedulaValida = true;
                }
                else
                {
                    Console.WriteLine("Por favor ingrese un número válido para la cédula.");
                }
            } while (!cedulaValida);

            int edad;
            bool edadValida = false;
            do
            {
                Console.WriteLine("Edad: ");
                if (int.TryParse(Console.ReadLine(), out edad))
                {
                    edadValida = true;
                }
                else
                {
                    Console.WriteLine("Por favor ingrese un número válido para la edad.");
                }
            } while (!edadValida);

            Paciente pacienteNuevo = new Paciente(nombre, apellido, edad, cedula);

            Console.WriteLine($"El paciente Necesita ir a Cola de {Caso(pacienteNuevo.Prioridad)}");

            if (pacienteNuevo.Edad <= 15)
            {
                colaPacientes[0, pacienteNuevo.Prioridad].Push(pacienteNuevo);
            }
            else
            {
                colaPacientes[1, pacienteNuevo.Prioridad].Push(pacienteNuevo);
            }
        }


        public void AtenderPaciente()
        {
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(CasoMedicos(i));

                medico[i].PacienteAtendido();
                Console.WriteLine("\n --------------------------------------\n ");
                for (int j = 0; medico[i].Paciente == null && j < 5; j++)
                {
                    if (!colaPacientes[i, j].Vacia()) {
                        
                        medico[i].AtenderPaciente(colaPacientes[i, j].Pop());
                        Console.WriteLine($"Paciente entro a consulta por {Caso(j)}");
                        Console.WriteLine("\n --------------------------------------\n ");

                    }
                 
                }
             }   
                

           
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

         public string CasoMedicos(int tipoDeMedico)
        {
            switch (tipoDeMedico)
            {
                case 0:
                    return "MEDICO DE PEDIATRIA \n";
                case 1:
                    return "MEDICO GENERAL \n";
                default:
                    return "Medico no encontrado";
            }

        }

        public void GenerarReporte()
        {
            Console.WriteLine("REPORTE MEDICO ACTUAL");
            Console.WriteLine("|||||||||||||||||||||||||||||||||||||||\n");
            for (int i = 0; i < 2; i++)
            {    
               Console.WriteLine(CasoMedicos(i)) ;
                medico[i].MostrarPaciente();
                Console.WriteLine("--------------------------------------\n ");
            }
            Console.WriteLine("|||||||||||||||||||||||||||||||||||||| \n");



            ColaPacientes colaAuxiliar = new ColaPacientes();
            Paciente pacienteAuxiliar;

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(CasoMedicos(i));

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
