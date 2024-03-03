namespace ColaConsultorio
{
// Clase Persona
public class Persona
{
    private string nombre;
    private string apellido;
    private int edad;
    private int cedula;


    public Persona(string nombre, string apellido, int edad, int cedula)
    {
        this.nombre = nombre;
        this.apellido = apellido;
        this.edad = edad;
        this.cedula = cedula;
    }


    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public string Apellido
    {
        get { return apellido; }
        set { apellido = value; }
    }

    public int Edad
    {
        get { return edad; }
        set { edad = value; }
    }

    public int Cedula
    {
        get { return cedula; }
        set { cedula = value; }
    }

}}
