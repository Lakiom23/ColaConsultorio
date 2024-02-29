using System;

namespace ColaConsultorio
{

    //Datos a guardar
    public struct Datos
    {
        public string Nombre;
        public string Apellido;
        public int edad ;
    }

    // clase persona
    public class Persona
    {
        private Datos datos { get; set; }

        
    public Persona(Datos dato)
        {
            datos = dato;
        }
    }

    //clase Paciente

      class Paciente : Persona
      {
        private int prioridad{ get; set; }

        public Paciente(Datos dato,int priori) : base(dato)
        {
            prioridad = priori;
        }
      
       }
    //class medico;

    class Medico : Persona
    {
        private string Especialidad {get;set;};

        public Medico(Datos dato, string especiali) : base(dato)
        {
            Especialidad = especiali;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
           
        }
    }
}
// lenin estuvo aqui