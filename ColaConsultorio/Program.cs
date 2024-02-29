using System;

namespace ColaConsultorio
{

    //Datos a guardar
    public struct Datos
    {
         string Nombre;
         string Apellido;
         int edad ;
         int Ci;
        
    }

    // clase persona
    public class Persona
    {
        private Datos datos { get; set; };

        
    public Persona(Datos dato)
        {
            datos = dato;
        }
    }

    //clase Paciente

      class Paciente : Persona
      {
        private int prioridad { get; set; };

        public Paciente(Datos dato,int priori) : base(dato)
        {
            prioridad = priori;
        }
      
       }
    //class medico;

    class Medico : Persona
    {
        private string Especialidad { get; set; };
        private Paciente paciente { get; set; };

        public Medico(Datos dato, string especiali) : base(dato)
        {
            Especialidad = especiali;
        }
    }
     
    //NODO PERSONA
    public class NodoP
    {
        private Paciente paciente { get; set; };
        private NodoP siguiente { get; set; };

        public NodoP(Paciente pacient)
        {
            paciente = pacient;
            siguiente = null;
        }
    }
// class colas

    public class Cola
    {
        private NodoP inicio { get; set; };
        private NodoP fin { get; set; };
        private int contador;
        private int tamanio ;

        public Cola()
        {
            tamanio = 30;
            contador = 0;
        }
        public bool vacia()
        {
            return inicio == null;
        }
        public bool llena()
        {     

            return contador >= tamanio;
        }

    }

    public class ColaNormal : Cola
    {

        public ColaNormal()
        {
        }

        public void Push(Paciente paciente)
        {

            NodoP nuevoPaciente = new NodoP(paciente)
            if (llena())
            {
                Console.WriteLine("Cola Llena, de momento no se puede ingresar mas pacientes en colsultorio");
                return;
            }
            if else (vacia()){
                inicio = nuevoPaciente;
                fin = nuevoPaciente;

                Console.WriteLine("Paciente agregado a la Cola");
                return;

            }
            else
            {
                fin.siguiente = nuevoPaciente;
                fin = nuevoPaciente;
            }

            contador++;
        }



    }

    public class ColaPrioridad : Cola
    {
       
        
    }


    class Program
    {
        static void Main(string[] args)
        {
           
        }
    }
}
// lenin estuvo aqui