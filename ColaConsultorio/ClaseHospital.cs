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
            for (int i = 0; i > 5; i++)
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
            int prioridad = random.Next(0, 6);
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
            

        }

        public void GenerarReporte()
        {

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
                Console.WriteLine("5.CERRAR SISTEMA ");

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
