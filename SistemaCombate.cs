
using Personajes;

public class Ataques
{
    private string nombre;
    private int dano;
    private int costoEnergía;
    private int aumentoEstres;

    public Ataques(string nombre, int dano, int costoEnergía, int aumentoEstres)
    {
        Nombre = nombre;
        Dano = dano;
        CostoEnergía = costoEnergía;
        AumentoEstres = aumentoEstres;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public int Dano { get => dano; set => dano = value; }
    public int CostoEnergía { get => costoEnergía; set => costoEnergía = value; }
    public int AumentoEstres { get => aumentoEstres; set => aumentoEstres = value; }
}

public static class AtaquesBasicos
{
    public static readonly Ataques[] BasicosEstudiante = new Ataques[]
    {
        new Ataques("Noche de Estudio", 5, 10, 10),
        new Ataques("Siesta Recuperadora", 0, -50, -10),
        new Ataques("Cascada de monster", 0, -10, 5),
        new Ataques("Entrega de Proyecto", 8, 15, 15),
        new Ataques("Grupo de estudio", 10, 12, 12),
        new Ataques("Consulta con el Profesor", 5, 10, 0),
        new Ataques("Charla Motivacional", 3, 5, -10),
        new Ataques("Apuntes prestados", 9, 5, 5),
        new Ataques("Papas y cerveza",0,10,-20),
        new Ataques("Gira con los pibes", 0, -40, -50)
    };

    public static readonly Ataques[] BasicosProfesor = new Ataques[]
    {
        new Ataques("Pregunta Capciosa", 8, 0, 0),
        new Ataques("Corrección Estricta", 15, 0, 0),
        new Ataques("Evaluativo semanal", 10, 0, 0),
        new Ataques("Pregunta Trampa", 8, 0, 0),
        new Ataques("Tema no dado", 20, 0, 0),
        new Ataques("Practico imposible", 7, 0, 0),
        new Ataques("Semana de parciales", 10, 0, 0),
        new Ataques("Teoria aburrida", 9, 0, 0),
        new Ataques("Cancelacion de clase", 5, 0, 0),
        new Ataques("Cancelacion de consulta", 4, 0, 0),
        new Ataques("Problema imposible", 17, 0, 0)
    };
}

public static class AtaquesEspeciales
{
    public static readonly Ataques[] UltiEstudiante = new Ataques[]
    {
        new Ataques("Aprobada epica", 250, -100, 0),
        new Ataques("Trabajo Práctico Impecable", 250, -100, 0),
        new Ataques("Maratón de Tutoriales", 250, -100, 0),
        new Ataques("Llevar la materia al dia", 500, -100, 0)
    };
    public static readonly Ataques[] UltiProfesor = new Ataques[]
    {
        new Ataques("Derivada Mortal",50,0,0),
        new Ataques("Campo Electromagnético",50,0,0),
        new Ataques("Reacción Explosiva",50,0,0),
        new Ataques("Trazo Perfecto",50,0,0),
        new Ataques("Número Complejo",50,0,0),
        new Ataques("Recursión Infinita",50,0,0),
        new Ataques("Bootstrap Colapso",50,0,0),
        new Ataques("Tormenta de Punteros",50,0,0),
        new Ataques("Tabla de Verdad",50,0,0),
        new Ataques("Pérdida de Referencia",50,0,0)
    };
};

public class Combate
{
    const double probCritico = 0.15; 
    public static int calculoDano(int danoBase,int nivel, int estres){
        //Calculamos el porcentaje de estres ya que este hace que demos menos daño
        double porcentajeEstres = estres/100;
        //Disminuimos el daño realizado en base a nuestro estres 
        double danoAjustado = danoBase * (1-porcentajeEstres);
        //Calculamos el daño final teniendo en cuenta un bufeo al avanzar de nivel
        double danoReal = danoAjustado * (1 + (nivel * 0.1));
        
        // creamos un numero aleatorio si es menor a la probabilidad es un golpe critico
        bool esGolpeCritico = new Random().NextDouble() < Combate.probCritico;
        if (esGolpeCritico)
        {
            danoReal *= 2; // Doble daño en caso de golpe crítico
        }
        // retorno el daño calculado pasandolo a entero
        return (int)danoReal;
    }

    public static void realizarAtaque(Ataques ataque,Estudiante estudiante, JefeCatedra boss, int nivel){
        estudiante.Energia -= ataque.CostoEnergía;
        boss.Salud -= calculoDano(ataque.Dano,nivel,estudiante.Estres);
        estudiante.Estres += ataque.AumentoEstres;
    }

    public static void recibirAtaque(Ataques ataque,Estudiante estudiante, JefeCatedra boss, int nivel){
        estudiante.Salud -= calculoDano(ataque.Dano,nivel,0);
    }

    public static List<Ataques> basicosDelTurno(){
        List<Ataques> ataques = new List<Ataques>();
        int[] indices  = FabricaDePersonajes.indicesAleatorios(4,10);
        int nroAtaque;
        for (int i = 0; i < 4; i++)
        {   
            nroAtaque = indices[i];
            string Nombre = AtaquesBasicos.BasicosEstudiante[nroAtaque].Nombre;
            int Dano = AtaquesBasicos.BasicosEstudiante[nroAtaque].Dano;
            int CostoEnergía = AtaquesBasicos.BasicosEstudiante[nroAtaque].CostoEnergía;
            int AumentoEstres = AtaquesBasicos.BasicosEstudiante[nroAtaque].AumentoEstres;
            ataques.Add(new Ataques(Nombre,Dano,CostoEnergía,AumentoEstres));
        }
        return ataques;
    }
}
