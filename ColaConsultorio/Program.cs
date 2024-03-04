using System;

namespace ColaConsultorio
{
    class Program
    {
        static void Main(string[] args)
        {
<<<<<<< HEAD
            Hospital hospital = new Hospital();
            hospital.Menu();

            /*
            ColaPacientes cola = new ColaPacientes();

            Medico medico = new Medico("Juan",
                                        "Lopez",
                                        34,
                                        336345,
                                        "pediatria"
                                    );


            Paciente paciente = new Paciente("Pedro",
                                            "Sanchez",
                                            3,
                                            336345,
                                            1
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
        */
        
=======
                Hospital consultorio = new Hospital();
consultorio.Menu();
Console.ReadKey();
>>>>>>> d2903c374903769cf5e0c0ef4aaa923b64c49c65
        }
    }
}