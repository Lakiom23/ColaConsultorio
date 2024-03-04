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

        //ColaPacientes
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
                Tamanio = 10;
                Contador = 0;
            }
            public bool vacia()
            {
                return Inicio == null;
            }
            public bool llena()
            {

                return Contador >= Tamanio;
            }

            //ingresar paciente nuevo 
            public void Push(Paciente paciente)
            {

                NodoPaciente nuevoPaciente = new NodoPaciente(paciente);
                if (llena())
                {
                    Console.WriteLine("Cola Llena, de momento no se puede ingresar mas pacientes en colsultorio");
                    return;
                }
                if (vacia())
                {
                    Inicio = nuevoPaciente;
                    Fin = nuevoPaciente;

                    Console.WriteLine("Paciente agregado a la Cola");
                    return;

                }
                else
                {
                    Fin.Siguiente = nuevoPaciente;
                    Fin = nuevoPaciente;
                }

                Contador++;
            }
            //metodo para atender al paciente 
            public Paciente Pop()
            {
                if (vacia())
                {
                    Console.WriteLine("La Cola esta vacia no hay nadie aquien atender ");
                    return null;
                }
                // verificar si hace falata eliminar ya que no estoy seguro si se trabaja igual que con punteros

                Paciente Atender = Inicio.Paciente;
                Reorganizar();

                Contador--;
                return Atender;
            }

            //reorganiza la cola una vez atendido un paciente 
            public void Reorganizar()
            {
                Inicio = Inicio.Siguiente;
                if (vacia()) fin = null;
            }

            public void Mostrar()
            {
                NodoPaciente nuevo = inicio;
                if (vacia())
                {
                    Console.WriteLine("Actualmente no hay pacientes en esta cola");
                }
                else
                {
                    while (nuevo != null)
                    {
                        Console.WriteLine("Pacientes en cola ");
                        Console.WriteLine($"Nombre : {nuevo.Paciente.Nombre} ");
                        Console.WriteLine($"Apellido : {nuevo.Paciente.Apellido} ");
                        Console.WriteLine($"Edad : {nuevo.Paciente.Edad} ");
                        Console.WriteLine($"C.I : {nuevo.Paciente.Cedula} ");
                        nuevo = nuevo.Siguiente;
                    }
                }


            }



        }}