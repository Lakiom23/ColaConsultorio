namespace ColaConsultorio
{

    //Class Hospital
    public class Hospital
    {
        private ColaPacientes[] adultos;
        private ColaPacientes[] ninios;
        private Medico? general;
        private Medico? pediatra;

        //Constructor
        public Hospital()
        {
            for (int i = 0; i < 5; i++)
            {
                adultos[i] = new ColaPacientes();
                ninios[i] = new ColaPacientes();
                
            }
               general= new Medico("Lenin","Figeroa",23, 23215546, "General" );
               pediatra = new Medico("Maikol", "Penia", 23, 27275746, "Pediatria");
        }

        //Getters y Setters
        internal Medico General { get => General; set => General = value; }
        internal Medico Pediatra { get => Pediatra; set => Pediatra = value; }
        internal ColaPacientes[] Adultos { get => adultos; set => adultos = value; }
        internal ColaPacientes[] Ninios { get => Ninios; set => Ninios = value; }


        public void InsertarPaciente()
        {
            Random random = new Random();
            int prioridad = random.Next(0, 5);
            int edad = random.Next(1, 100);

            Console.WriteLine("Ingrese los datos del Paciente ");

            Console.WriteLine("Nombre: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("Apellido: ");
            string apellido = Console.ReadLine();

            Console.WriteLine("C.I : ");
            int cedula = Convert.ToInt32(Console.ReadLine());

            Paciente pacienteNuevo = new Paciente(nombre, apellido, cedula, edad, prioridad);

            if (pacienteNuevo.Edad < 15){
                ninios[prioridad].Push(pacienteNuevo);
            }else{
                adultos[prioridad].Push(pacienteNuevo);
            }
        }


        public void AtenderPaciente()
        {
             general.PacienteAtendido();
             pediatra.PacienteAtendido();
             
               for( int i = 0; general.Paciente==null || i < 5; i++)
                {
                    general.AtenderPaciente(Adultos[i].Pop());
                }

                for (int i = 0; pediatra.Paciente == null|| i < 5; i++)
                {
                    pediatra.AtenderPaciente(Ninios[i].Pop());
                }

        }

        public void GenerarReporte()
        {
            
                Console.WriteLine("Reporte Medico actual ");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Medicos General");
                general.MostrarPaciente();
                Console.WriteLine("Medicos Pediatra");
                pediatra.MostrarPaciente();
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Adultos ");


                for(int i = 0;i < 5;i++)
                {
                    if (i == 0) Console.WriteLine(" Consulta general  ");
                    if (i == 1) Console.WriteLine(" Accidentes Aparatosos ");
                    if (i == 2) Console.WriteLine(" Infartos ");
                    if (i == 3) Console.WriteLine(" Afeccion Respiratoria ");
                    if (i == 4) Console.WriteLine(" Partos  ");
                    Adultos[i].Mostrar();
                
                }
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Ninios ");
                for (int i = 0; i < 5; i++)
                {
                    if (i == 0) Console.WriteLine(" Consulta general  ");
                    if (i == 1) Console.WriteLine(" Accidentes Aparatosos ");
                    if (i == 2) Console.WriteLine(" Infartos ");
                    if (i == 3) Console.WriteLine(" Afeccion Respiratoria ");
                    if (i == 4) Console.WriteLine(" Partos  ");
                   Ninios[i].Mostrar();

                }

                Console.WriteLine("-------------------------------------");

        }


        public void Menu()
        {
            int opcion = 0;

            do
            {
                Console.WriteLine("Consultorio medico ");
                Console.WriteLine("1.Nuevo Paciente");
                Console.WriteLine("2.Atender Pacientes");
                Console.WriteLine("3.Generar reporte ");
                Console.WriteLine("4.CERRAR SISTEMA ");

                opcion = Convert.ToByte(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        InsertarPaciente();
                        Console.ReadKey();
                        break;

                    case 2:
                        AtenderPaciente();
                        Console.ReadKey();
                        break;

                    case 3:
                        GenerarReporte();
                        Console.ReadKey();
                        break;
                }

            } while (opcion != 4);

        }

    }
}
