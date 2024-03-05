using System.Runtime.ConstrainedExecution;

namespace ColaConsultorio
{
    //Nodo Paciente
    public class NodoPaciente
    {
        private Paciente? paciente;
        private NodoPaciente? siguiente;

        public NodoPaciente(Paciente paciente)
        {
            this.paciente = paciente;
            this.siguiente = null;
        }

        internal Paciente Paciente { get => paciente; set => paciente = value; }
        internal NodoPaciente Siguiente { get => siguiente; set => siguiente = value; }
    }

    //Cola Pacientes
    public class ColaPacientes
    {
        private NodoPaciente? inicio;
        private NodoPaciente? fin;
        private int contador;
        private int tamanio;

        internal NodoPaciente Fin { get => fin; set => fin = value; }
        internal NodoPaciente Inicio { get => inicio; set => inicio = value; }
        public int Contador { get => contador; set => contador = value; }
        public int Tamanio { get => tamanio; set => tamanio = value; }

        public ColaPacientes()
        {
            inicio = null;
            fin = null;
            tamanio = 10;
            contador = 0;
        }

        public bool Vacia()
        {
            return inicio == null;
        }

        public bool Llena()
        {
            return contador >= tamanio;
        }

        //ingresar paciente nuevo 
        public void Push(Paciente paciente)
        {
            NodoPaciente nuevoPaciente = new NodoPaciente(paciente);
            if (Llena())
            {
                Console.WriteLine("Cola Llena, de momento no se puede ingresar mas pacientes en consultorio");
                return;
            }
            if (Vacia())
            {
                inicio = nuevoPaciente;
                fin = nuevoPaciente;
                Console.WriteLine("Paciente agregado a la Cola");
                return;
            }
            else
            {
                fin.Siguiente = nuevoPaciente;
                fin = nuevoPaciente;
            }
            contador++;
        }

        //reorganiza la cola una vez atendido un paciente 
        public void Reorganizar()
        {
            inicio = inicio.Siguiente;
            if (Vacia()) fin = null;
        }

        //Metodo para atender al paciente 
        public Paciente Pop()
        {
            if (Vacia())
            {
                Console.WriteLine("La Cola esta vacia no hay nadie aquien atender ");
                return null;
            }
            // verificar si hace falata eliminar ya que no estoy seguro si se trabaja igual que con punteros

            Paciente paciente = Inicio.Paciente;
            Reorganizar();

            Contador--;
            return paciente;
        }

        public void Mostrar()
        {
            NodoPaciente nuevo = inicio;
           /* if (Vacia())
            {
                Console.WriteLine("Actualmente no hay pacientes en esta cola");
            }
            else
            {
                Console.WriteLine("Pacientes en cola ");
                while (nuevo != null)
                {*/
                    Console.WriteLine($"--------------------------------------");
                    Console.WriteLine($"Nombre : {nuevo.Paciente.Nombre} ");
                    Console.WriteLine($"Apellido : {nuevo.Paciente.Apellido} ");
                    Console.WriteLine($"Edad : {nuevo.Paciente.Edad} ");
                    Console.WriteLine($"Cedula : {nuevo.Paciente.Cedula} ");
                    Console.WriteLine($"--------------------------------------");
                    nuevo = nuevo.Siguiente;
                //}
            //}
        }
    }
}
