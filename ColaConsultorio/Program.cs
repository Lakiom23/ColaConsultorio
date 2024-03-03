using System;

namespace ColaConsultorio
{

    class Program
    {


        static void Main(string[] args)
        {
            Cola cola = new Cola();

            Medico medico = new Medico(nombre = "Juan",
                                    apellido = "Lopez",
                                    edad = 34,
                                    Cedula = 336345,
                                    "pediatria"
                                    );


            Paciente paciente = new Paciente(nombre = "Pedro",
                                            apellido = "Sanchez",
                                            edad = 3,
                                            cedula = 336345,
                                            prioridad = 1
                                            );

            medico.PacienteAtendido();
            medico.AtenderPaciente(paciente);
            medico.MostrarPaciente();
            medico.PacienteAtendido();

            cola.Mostrar();
            cola.Push(paciente);
            cola.Mostrar();
            cola.Pop();
            cola.Mostrar();
        }
    }
}
