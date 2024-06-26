
namespace Personajes;

public class DatosEstudiante
{
    private string nombre;
    private int edad;

    public DatosEstudiante(string nombre, int edad)
    {
        this.Nombre = nombre;
        this.Edad = edad;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public int Edad { get => edad; set => edad = value; }
}
public class Estudiante
{
    private DatosEstudiante datos;
    private int estres; //entero de valor 0-100 inicialmente 0
    private int motivacion; //entero de valor 0-100 inicialmente 100
    private int conocimiento; //entero de valor 0-100 inicialmente un valor aleatorio entre 0-30
    private int energia; //entero de valor 0-100 inicialmente 100
    private int salud; //entero de valor 0-100 inicialmente 100 y se reinicia a 100 en cada batalla
    private int vidas; //entero de valor 0-3 inicialmente 3 y no se recuperan

    public Estudiante(DatosEstudiante datos,int estres, int motivacion,int conocimiento,
                        int energia,int salud,int vidas)
    {
        this.Datos = datos;
        this.Estres = estres;
        this.Motivacion = motivacion;
        this.Conocimiento = conocimiento;
        this.Energia = energia;
        this.Salud = salud;
        this.Vidas = vidas;
    }


    public int Estres { get => estres; set => estres = value; }
    public int Motivacion { get => motivacion; set => motivacion = value; }
    public int Conocimiento { get => conocimiento; set => conocimiento = value; }
    public int Energia { get => energia; set => energia = value; }
    public int Salud { get => salud; set => salud = value; }
    public int Vidas { get => vidas; set => vidas = value; }
    public DatosEstudiante Datos { get => datos; set => datos = value; }
}

public class Materia
{
    private string nombre;

    private string ataqueEspecial;

    public string Nombre { get => nombre; set => nombre = value; }
    public string AtaqueEspecial { get => ataqueEspecial; set => ataqueEspecial = value; }
    public Materia(string nombre, string ataqueEspecial)
    {
        this.nombre = nombre;
        this.ataqueEspecial = ataqueEspecial;
    }
}

public class JefeCatedra
{
    private string nombre; //generado aleatoriamente
    private int edad; //generado aleatoriamente entre 25 y 70 años
    private Materia materia; // generado aleatoriamente seleccionado de posiblemente un arreglo
    private int energia; //valor entre 0-100 valor incial 0 aumenta segun los golpes criticos;
    private int salud; //valor entre 0- 300 valor inicial aleatorio entre 100 y 300;

    public JefeCatedra(string nombre, int edad, Materia materia, int energia, int salud)
    {
        this.Nombre = nombre;
        this.Edad = edad;
        this.Materia = materia;
        this.Energia = energia;
        this.Salud = salud;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public int Edad { get => edad; set => edad = value; }
    public Materia Materia { get => materia; set => materia = value; }
    public int Energia { get => energia; set => energia = value; }
    public int Salud { get => salud; set => salud = value; }
}

public class infoPartida{
    private int danioRealizado;
    private int danioRecibido;

    private int cantCriticosRealizados;

    public infoPartida(int danReal, int danRecib, int cantCrit)
    {
        this.DanioRealizado = danReal;
        this.DanioRecibido = danRecib;
        this.CantCriticosRealizados = cantCrit;
    }

    public int DanioRealizado { get => danioRealizado; set => danioRealizado = value; }
    public int DanioRecibido { get => danioRecibido; set => danioRecibido = value; }
    public int CantCriticosRealizados { get => cantCriticosRealizados; set => cantCriticosRealizados = value; }
}