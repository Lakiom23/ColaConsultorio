namespace ColaConsultorio
{
    //Clase Paciente
    public class Paciente : Persona
    {
        private int prioridad;

        public Paciente(string nombre, string apellido, int edad, int cedula) : base(nombre, apellido, edad, cedula)
        {
            Random random = new Random();
            this.prioridad = random.Next(0, 5);
        }

        public int Prioridad
        {
            get { return prioridad; }
            set { prioridad = value; }
        }

        public void MostrarDatos()
        {
            Console.WriteLine($"--------------------------------------");
            Console.WriteLine($"   *Nombre : {Nombre} ");
            Console.WriteLine($"    Apellido : {Apellido} ");
            Console.WriteLine($"    Edad : {Edad} ");
            Console.WriteLine($"    Cedula : {Cedula} ");
            Console.WriteLine($"--------------------------------------");

        }


    }
}