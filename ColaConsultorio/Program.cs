using System;

namespace ColaConsultorio
{

    class Program
    {

 
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

             public void InsertarPaciente()
            {
                Paciente nuevo;
                Random random = new Random();
                int prioridad = random.Next(0, 6);
                int Edad = random.Next(1, 150);


                Console.WriteLine("Ingrese los datos del Paciente ");
                Console.WriteLine("Nombre : "); 
                Console.WriteLine("Apellido : "); 
                Console.WriteLine("C.I : "); 
                Console.WriteLine("Edad : "); 
                Console.Write("Prioridad : ");

            }
            public void AtenderPaciente()
            {

            }

            public void GenerarReporte()
            {

            }


            public void Menu()
            {
                int opc = 0;

                do
                {

                    Console.WriteLine("Consultorio medico ");
                    Console.WriteLine("1.Nuevo Paciente");
                    Console.WriteLine("2.Atender Pacientes");
                    Console.WriteLine("3.Generar reporte ");
                    Console.WriteLine("4.Cambio de doctor");
                    Console.WriteLine("5.CERRAR SISTEMA ");
                    opc = Convert.ToByte(Console.ReadLine());



                    switch (opc)
                    {
                        case 1 :
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




                } while (opc != 4);

            
            
            
            
            
            
            }



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
