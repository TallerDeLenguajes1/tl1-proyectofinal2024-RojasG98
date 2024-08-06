
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
    private int conocimiento; //entero de valor 0-100 inicialmente un valor aleatorio entre 0-30
    private int energia; //entero de valor 0-100 inicialmente 100
    private int salud; //entero de valor 0-100 inicialmente 100 y se reinicia a 100 en cada batalla
    private int vidas; //entero de valor 0-2 inicialmente 2 y no se recuperan

    public Estudiante(DatosEstudiante datos,int estres,int conocimiento,
                        int energia,int salud,int vidas)
    {
        this.Datos = datos;
        this.Estres = estres;
        this.Conocimiento = conocimiento;
        this.Energia = energia;
        this.Salud = salud;
        this.Vidas = vidas;
    }


    public int Estres { get => estres; set => estres = value; }
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
    private string[] dialogoBienvenida;
    public string Nombre { get => nombre; set => nombre = value; }
    public string AtaqueEspecial { get => ataqueEspecial; set => ataqueEspecial = value; }
    public string[] DialogoBienvenida { get => dialogoBienvenida; set => dialogoBienvenida = value; }

    public Materia(string nombre, string ataqueEspecial, string[] dialogoBienvenida)
    {
        this.Nombre = nombre;
        this.AtaqueEspecial = ataqueEspecial;
        this.DialogoBienvenida = dialogoBienvenida;
    }
}

public class JefeCatedra
{
    private string nombre; //Obtenido de la API
    private int edad; //Obtenido de la API
    private Materia materia; //Obtenido aleatoriamiente de una arreglo de materias
    private int salud; //valor entre 520 y 110 segun el nivel;

    public JefeCatedra(string nombre, int edad, Materia materia, int salud)
    {
        this.Nombre = nombre;
        this.Edad = edad;
        this.Materia = materia;
        this.Salud = salud;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public int Edad { get => edad; set => edad = value; }
    public Materia Materia { get => materia; set => materia = value; }
    public int Salud { get => salud; set => salud = value; }
}

public class infoPartida{
    private int danioRealizado;
    private int danioRecibido;

    private int cantCriticosRealizados;

    public infoPartida() {}
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