using System;

namespace ColaConsultorio
{

    class Program
    {

        
        //Clase Paciente
        public class Paciente : Persona
        {
            private int prioridad;

            public Paciente(Datos dato, int priori) : base(dato)
            {
                Prioridad = priori;
            }

            public int Prioridad { get => prioridad; set => prioridad = value; }
        }
        //class medico;

        public class Medico : Persona
        {
            private string Especialidad;
            private Paciente paciente;


            public Medico(Datos dato, string especiali) : base(dato)
            {
                Especialidad1 = especiali;
                Paciente = null;
            }
            public string Especialidad1 { get => Especialidad; set => Especialidad = value; }
            internal Paciente Paciente { get => paciente; set => paciente = value; }

            public void atenderPaciente(Paciente pacient)
            {
                if (Paciente == null)
                {
                    Paciente = pacient;
                    Console.WriteLine("Paciente ha entrado al consultorio");
                }
                else
                {
                    Console.WriteLine("El medico se encuentra ocupado con otro paciente");
                }
            }

            public void PacienteAtendido()
            {
                if (Paciente != null)
                {
                    Paciente = null;
                    Console.WriteLine("Paciente ha sido atendido, mnedico disponible");
                }
                else
                {
                    Console.WriteLine("No hay paciente siendo atendido, El medico se encuentra Disponible ");
                }
            }

            public void MostraPaciente()
            {
                if (Paciente != null)
                {
                    Paciente = null;
                    Console.WriteLine("Paciente siendo atendido ");
                    Console.WriteLine($"Nombre : {Paciente.Datos.Nombre} ");
                    Console.WriteLine($"Apellido : {Paciente.Datos.Apellido} ");
                    Console.WriteLine($"Edad : {Paciente.Datos.edad} ");
                    Console.WriteLine($"C.I : {Paciente.Datos.Ci} ");
                }
                else
                {
                    Console.WriteLine("No hay paciente siendo atendido, El medico se encuentra Disponible ");
                }
            }


        }

        //NODO PERSONA
        public class NodoP
        {
            private Paciente paciente;
            private NodoP siguiente;

            public NodoP(Paciente pacient)
            {
                Paciente = pacient;
                Siguiente = null;
            }

            internal Paciente Paciente { get => paciente; set => paciente = value; }
            internal NodoP Siguiente { get => siguiente; set => siguiente = value; }
        }
        // class colas

        public class Cola
        {
            private NodoP inicio;
            private NodoP fin;
            private int contador;
            private int tamanio;

            internal NodoP Fin { get => fin; set => fin = value; }
            internal NodoP Inicio { get => inicio; set => inicio = value; }
            public int Contador { get => contador; set => contador = value; }
            public int Tamanio { get => tamanio; set => tamanio = value; }

            public Cola()
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

                NodoP nuevoPaciente = new NodoP(paciente);
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
            public Paciente pop()
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
                if (vacia()) Fin = null;
            }

            public void Mostra()
            {
                NodoP nuevo = inicio;
                if (vacia())
                {
                    Console.WriteLine("Actualmente no hay pacientes en esta cola");
                }
                else
                {
                    while (nuevo != null)
                    {
                        Console.WriteLine("Pacientes en cola ");
                        Console.WriteLine($"Nombre : {nuevo.Paciente.Datos.Nombre} ");
                        Console.WriteLine($"Apellido : {nuevo.Paciente.Datos.Apellido} ");
                        Console.WriteLine($"Edad : {nuevo.Paciente.Datos.edad} ");
                        Console.WriteLine($"C.I : {nuevo.Paciente.Datos.Ci} ");
                        nuevo = nuevo.Siguiente;
                    }
                }


            }



        }
        /*
        public class ColaNormal : Cola
        {
            public ColaNormal()
            {
            }


        }

        public class ColaPrioridad : Cola
        {
        }
        */

        public class Hospital
        {
            private Cola[] adultos;
            private Cola[] Ninios;
            private Medico General;
            private Medico Pediatria;

            public Hospital()
            {
                for (int i = 0; i > 5; i++)
                {
                    Adultos[i] = new Cola();
                    Ninios1[i] = new Cola();
                    General = null;
                    Pediatria1 = null;

                }
            }


            internal Medico General1 { get => General; set => General = value; }
            internal Medico Pediatria1 { get => Pediatria; set => Pediatria = value; }
            internal Cola[] Adultos { get => adultos; set => adultos = value; }
            internal Cola[] Ninios1 { get => Ninios; set => Ninios = value; }



        }



        static void Main(string[] args)
        {
            Cola cola = new Cola();
            Datos datomedico = new Datos()
            {
                Nombre = "juan",
                Apellido = "lopez",
                edad = 34,
                Ci = 336345

            };

            Medico medico = new Medico(datomedico, "pediatria");

            Datos datopaciente = new Datos()
            {
                Nombre = "pedro",
                Apellido = "saches",
                edad = 3,
                Ci = 336345
            };


            Paciente paciente = new Paciente(datopaciente, 1);

            medico.PacienteAtendido();
            medico.atenderPaciente(paciente);
            medico.MostraPaciente();
            medico.PacienteAtendido();

            cola.Mostra();
            cola.Push(paciente);
            cola.Mostra();
            cola.pop();
            cola.Mostra();


        }
    }
}
//lenin revisalo gay <3
