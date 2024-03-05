namespace ColaConsultorio
{
public class Medico : Persona
{
    private string especialidad;
    private Paciente? paciente;

    public Medico(string nombre, string apellido, int edad, int cedula, string especialidad) : base(nombre, apellido, edad, cedula)
    {
        this.especialidad = especialidad;
        this.paciente = null;
    }

    public string Especialidad
    {
        get { return especialidad; }
        set { especialidad = value; }
    }

    internal Paciente Paciente
    {
        get { return paciente; }
        set { paciente = value; }
    }

    public void AtenderPaciente(Paciente paciente)
    {
        if (this.paciente == null)
        {
            this.paciente = paciente;
            Console.WriteLine("Paciente ha entrado al consultorio");
        }
        else
        {
            Console.WriteLine("El medico se encuentra ocupado con otro paciente");
        }
    }

    public void PacienteAtendido()
    {
        if (this.paciente != null)
        {
            this.paciente = null;
            Console.WriteLine("Paciente ha sido atendido, medico disponible");
        }
        else
        {
            Console.WriteLine("No hay paciente siendo atendido, el medico se encuentra disponible");
        }
    }

    public void MostrarPaciente()
    {
        if (Paciente != null)   Paciente.MostrarDatos();
       
        else
        {
            Console.WriteLine("No hay paciente siendo atendido, el medico se encuentra disponible");
        }
    }
}}