
using Pantallas;
using Personajes;

public class Ataques
{
    private string nombre;
    private int dano;
    private int costoEnergía;
    private int aumentoEstres;
    private string dialogo;

    public Ataques(string nombre, int dano, int costoEnergía, int aumentoEstres, string dialogo)
    {
        this.Nombre = nombre;
        this.Danio = dano;
        this.CostoEnergía = costoEnergía;
        this.AumentoEstres = aumentoEstres;
        this.Dialogo = dialogo;

    }

    public string Nombre { get => nombre; set => nombre = value; }
    public int Danio { get => dano; set => dano = value; }
    public int CostoEnergía { get => costoEnergía; set => costoEnergía = value; }
    public int AumentoEstres { get => aumentoEstres; set => aumentoEstres = value; }
    public string Dialogo { get => dialogo; set => dialogo = value; }
}

public static class AtaquesBasicos
{
    public static readonly Ataques[] BasicosEstudiante = new Ataques[]
    {
        new Ataques("Noche de Estudio", 15, 10, 20, "¡Me quedaré despierto toda la noche hasta entender todo!"),
        new Ataques("Siesta Recuperadora", -10, -50, -20, "¡Un pequeño descanso y estaré como nuevo!"),
        new Ataques("Machete", 20, 5, 0, "¡Con este machete, ningún examen se me resistirá!"),
        new Ataques("Entrega de Proyecto", 20, 10, 30, "¡Este proyecto será mi obra maestra!"),
        new Ataques("Grupo de estudio", 10, 8, 25, "¡Juntos somos más fuertes y aprenderemos más rápido!"),
        new Ataques("Consulta con el Profesor", 15, 10, 15, "¡Nada como resolver dudas directamente con el profesor!"),
        new Ataques("Charla Motivacional", 5, 5, -15, "¡Un poco de motivación y estaré listo para cualquier desafío!"),
        new Ataques("Apuntes prestados", 15, 5, 10, "¡Estos apuntes me salvarán el semestre!"),
        new Ataques("Papas y cerveza", -20, -20, -30, "¡A veces, un poco de diversión es justo lo que necesito para relajarme!"),
        new Ataques("Gira con los pibes", -20, 30, -40, "¡Una noche de fiesta con los amigos para despejar la mente!")
    };

    public static readonly Ataques[] BasicosProfesor = new Ataques[]
    {
        new Ataques("Pregunta Capciosa", 8, 0, 5, "Explícame este concepto de manera sencilla... si es que puedes."),
        new Ataques("Corrección Estricta", 18, 0, 10, "Entender no es suficiente, debes dominarlo completamente."),
        new Ataques("Evaluativo semanal", 12, 0, 10, "Espero que hayas estudiado, porque viene una evaluación sorpresa."),
        new Ataques("Pregunta Trampa", 10, 0, 5, "¿Qué harás si el resultado es negativo? ¡Responde!"),
        new Ataques("Tema no dado", 22, 0, 20, "Esto no está en tus apuntes, pero es crucial. Buena suerte."),
        new Ataques("Practico imposible", 7, 0, 15, "Resuelve este problema. Aunque probablemente te tomará más de una hora."),
        new Ataques("Semana de parciales", 14, 0, 15, "Prepárate para tres exámenes parciales esta semana. No hay escapatoria."),
        new Ataques("Teoria aburrida", 9, 0, 5, "Hoy te torturaré con una larga sesión de teoría."),
        new Ataques("Cancelacion de clase", 5, 0, 0, "La clase de hoy se cancela. Disfruta de tu decepción."),
        new Ataques("Cancelacion de consulta", 4, 0, 5, "La consulta se cancela. Tus dudas tendrán que esperar."),
        new Ataques("Problema imposible", 20, 0, 15, "Aquí tienes un problema que nadie ha resuelto. Veamos si eres diferente.")
    };
}

public static class AtaquesEspeciales
{
    public static readonly Ataques[] UltiEstudiante = new Ataques[]
    {
        new Ataques("Aprobada épica", 50, 50, 0, "¡He logrado una calificación perfecta en el examen más difícil!"),
        new Ataques("Trabajo Práctico Impecable", 50, 50, 0, "Mi trabajo práctico es impecable, no hay ningún error."),
        new Ataques("Maratón de Tutoriales", 75, 50, 0, "Después de una maratón de tutoriales, estoy listo para cualquier cosa."),
        new Ataques("Llevar la materia al día", 75, 50, 0, "He llevado la materia al día y estoy totalmente preparado.")
    };
    public static readonly Ataques[] UltiProfesor = new Ataques[]
    {
        new Ataques("Derivada Mortal",50,0,0, "¡Prepárate para enfrentar el límite de tu existencia!"),
        new Ataques("Campo Electromagnético",50,0,0, "¡Siente la fuerza invisible que te atrae a tu destino!"),
        new Ataques("Reacción Explosiva",50,0,0, "¡Esta reacción te dejará sin aliento... literalmente!"),
        new Ataques("Trazo Perfecto",50,0,0, "¡Un solo trazo y todo tu mundo se desmorona con precisión milimétrica!"),
        new Ataques("Número Complejo",50,0,0, "¡Entrarás en un mundo de números irreales y soluciones inimaginables!"),
        new Ataques("Recursión Infinita",50,0,0, "¡Caerás en un bucle sin fin del que no podrás escapar!"),
        new Ataques("CSS Maldito",50,0,0, "¡Tus estilos se romperán y todo se verá horriblemente desalineado!"),
        new Ataques("Tormenta de Punteros",50,0,0, "¡Te perderás en un mar de referencias y punteros errantes!"),
        new Ataques("Tabla de Verdad",50,0,0, "¡La verdad absoluta será tu condena!"),
        new Ataques("Pérdida de Referencia",50,0,0, "¡Tu existencia se desvanecerá como una variable fuera de alcance!")
    };
};

public class Combate
{
    const double probCritico = 0.25;
    public static int calculoDanio(int danoBase, int conocimiento, int estres, ref int cantCrit)
    {
        //Calculamos el porcentaje de estres ya que este hace que demos menos daño
        double porcentajeEstres = (double)estres / 100;
        double porcentajeConocimiento = (double)conocimiento / 100;
        //Disminuimos el daño realizado en base a nuestro estres 
        double danoAjustado = danoBase * (1 - porcentajeEstres);
        //Calculamos el daño final teniendo en cuenta un bufeo al avanzar de nivel
        double danoReal = danoAjustado + (danoAjustado * porcentajeConocimiento);

        // creamos un numero aleatorio si es menor a la probabilidad es un golpe critico
        bool esGolpeCritico = new Random().NextDouble() < Combate.probCritico;
        if (esGolpeCritico)
        {
            cantCrit++;
            Escribir.escribiryborrarCentrado("ES GOLPE CRITICO!", 7);
            danoReal *= 2; // Doble daño en caso de golpe crítico
        }
        // retorno el daño calculado pasandolo a entero
        return (int)danoReal;
    }
    public static int calculoDanoBoss(int danoBase, int nivel)
    {
        //Calculamos el daño final teniendo en cuenta un bufeo al avanzar de nivel
        double danoReal = danoBase * (1 + (nivel * 0.1));

        // creamos un numero aleatorio si es menor a la probabilidad es un golpe critico
        bool esGolpeCritico = new Random().NextDouble() < Combate.probCritico;
        if (esGolpeCritico)
        {
            Escribir.escribiryborrarCentrado("ES GOLPE CRITICO!", 7);
            danoReal *= 2; // Doble daño en caso de golpe crítico
        }
        // retorno el daño calculado pasandolo a entero
        return (int)danoReal;
    }

    public static void realizarAtaque(Ataques ataque, Estudiante estudiante, JefeCatedra boss, int nivel, ref int danioRealizado, ref int cantCriticos)
    {
        Escribir.escribiryborrarCentrado(estudiante.Datos.Nombre + " uso " + ataque.Nombre, 14);
        Escribir.escribiryborrarCentrado(estudiante.Datos.Nombre + ": " + ataque.Dialogo, 14);

        if (estudiante.Energia - ataque.CostoEnergía <= 0)
        {
            estudiante.Energia = 0;
        }
        else
        {
            if (estudiante.Energia - ataque.CostoEnergía > 100)
            {
                estudiante.Energia = 100;

            }
            else
            {
                estudiante.Energia -= ataque.CostoEnergía;

            }

        }
        int danioReal = 0;
        if (ataque.Danio < 0)
        {
            danioRealizado = 0;
            Escribir.escribiryborrarCentrado(estudiante.Datos.Nombre + " recuperó" + -ataque.Danio + " de salud", 14);
            if (estudiante.Salud - ataque.Danio > 100)
            {
                estudiante.Salud = 100;
            }
            else
            {
                estudiante.Salud -= ataque.Danio;
            }
        }
        else
        {
            danioReal = calculoDanio(ataque.Danio, nivel, estudiante.Estres, ref cantCriticos);
            danioRealizado += danioReal;
            Escribir.escribiryborrarCentrado(boss.Nombre + " recibio " + danioReal + " de daño", 14);

        }
        if (boss.Salud - danioReal < 0)
        {
            boss.Salud = 0;
        }
        else
        {
            boss.Salud -= danioReal;
        }

        if (estudiante.Estres + ataque.AumentoEstres > 100)
        {
            estudiante.Estres = 100;
        }
        else
        {
            if (estudiante.Estres + ataque.AumentoEstres < 0)
            {
                estudiante.Estres = 0;
            }
            else
            {
                estudiante.Estres += ataque.AumentoEstres;
            }
        }
    }

    public static void recibirAtaque(Estudiante estudiante, JefeCatedra boss, int nivel, ref int danioRecibido)
    {
        int ataqueAleatorio;
        int danioBoss = 0;
        double probabilidadUltimate = (double)estudiante.Estres / 100;
        bool esAtaqueEspecial = new Random().NextDouble() < probabilidadUltimate;
        if (!esAtaqueEspecial)
        {
            ataqueAleatorio = FabricaDePersonajes.numeroAleatorio(0, 10);
            Console.SetCursorPosition(0, 0);
            Escribir.escribiryborrarCentrado(boss.Nombre + ": " + AtaquesBasicos.BasicosProfesor[ataqueAleatorio].Dialogo, 2);
            Escribir.escribiryborrarCentrado(boss.Nombre + " uso " + AtaquesBasicos.BasicosProfesor[ataqueAleatorio].Nombre, 3);
            Escribir.escribiryborrarCentrado("Tu estres aumento " + AtaquesBasicos.BasicosProfesor[ataqueAleatorio].AumentoEstres, 3);
            danioBoss = calculoDanoBoss(AtaquesBasicos.BasicosProfesor[ataqueAleatorio].Danio, nivel);
            danioRecibido += danioBoss;
            estudiante.Estres += AtaquesBasicos.BasicosProfesor[ataqueAleatorio].AumentoEstres;

        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (string.Equals(AtaquesEspeciales.UltiProfesor[i].Nombre, boss.Materia.AtaqueEspecial))
                {
                    ataqueAleatorio = i;
                    Escribir.escribiryborrarCentrado(boss.Nombre + ": " + AtaquesEspeciales.UltiProfesor[i].Dialogo, 2);
                    danioBoss = calculoDanoBoss(AtaquesEspeciales.UltiProfesor[ataqueAleatorio].Danio, nivel);
                    danioRecibido += danioBoss;
                }
            }
            Console.SetCursorPosition(0, 0);

            Escribir.escribiryborrarCentrado("Recibiras un ataque especial!", 3);
            Escribir.escribiryborrarCentrado(boss.Nombre + " usara " + boss.Materia.AtaqueEspecial, 3);
            Escribir.escribiryborrarCentrado("Recibiste " + danioBoss + " puntos de daño", 3);
        }

        if (estudiante.Salud - danioBoss <= 0)
        {
            Escribir.escribiryborrarCentrado("Has perdido una vida!", 7);
            estudiante.Salud = 100;
            estudiante.Vidas--;
        }
        else
        {
            estudiante.Salud -= danioBoss;

        }

    }

    public static List<Ataques> ataquesDelTurno(Estudiante estudiante)
    {
        List<Ataques> ataques = new List<Ataques>();
        bool hayAtaqueEspecial = new Random().NextDouble() < 0.3;
        //si hay ataque especial entonces obtengo 3 basicos y un especial
        if (hayAtaqueEspecial)
        {
            int[] indicesBasicos = FabricaDePersonajes.indicesAleatorios(3, 10);
            for (int i = 0; i < 3; i++)
            {
                int nroAtaque = indicesBasicos[i];
                string Nombre = AtaquesBasicos.BasicosEstudiante[nroAtaque].Nombre;
                int Dano = AtaquesBasicos.BasicosEstudiante[nroAtaque].Danio;
                int CostoEnergía = AtaquesBasicos.BasicosEstudiante[nroAtaque].CostoEnergía;
                int AumentoEstres = AtaquesBasicos.BasicosEstudiante[nroAtaque].AumentoEstres;
                string dialogo = AtaquesBasicos.BasicosEstudiante[nroAtaque].Dialogo;
                ataques.Add(new Ataques(Nombre, Dano, CostoEnergía, AumentoEstres, dialogo));
            }
            int indiceUltimate = FabricaDePersonajes.numeroAleatorio(0, 4);
            string NombreUltimate = AtaquesEspeciales.UltiEstudiante[indiceUltimate].Nombre;
            int DanoUltimate = AtaquesEspeciales.UltiEstudiante[indiceUltimate].Danio;
            int CostoEnergíaUltimate = AtaquesEspeciales.UltiEstudiante[indiceUltimate].CostoEnergía;
            int AumentoEstresUltimate = AtaquesEspeciales.UltiEstudiante[indiceUltimate].AumentoEstres;
            string dialogoUltimate = AtaquesEspeciales.UltiEstudiante[indiceUltimate].Dialogo;
            ataques.Add(new Ataques(NombreUltimate, DanoUltimate, CostoEnergíaUltimate, AumentoEstresUltimate, dialogoUltimate));
        }
        else
        {
            int[] indices = FabricaDePersonajes.indicesAleatorios(4, 10);
            int nroAtaque;
            for (int i = 0; i < 4; i++)
            {
                nroAtaque = indices[i];
                string Nombre = AtaquesBasicos.BasicosEstudiante[nroAtaque].Nombre;
                int Dano = AtaquesBasicos.BasicosEstudiante[nroAtaque].Danio;
                int CostoEnergía = AtaquesBasicos.BasicosEstudiante[nroAtaque].CostoEnergía;
                int AumentoEstres = AtaquesBasicos.BasicosEstudiante[nroAtaque].AumentoEstres;
                string dialogo = AtaquesBasicos.BasicosEstudiante[nroAtaque].Dialogo;
                ataques.Add(new Ataques(Nombre, Dano, CostoEnergía, AumentoEstres, dialogo));
            }
        }

        return ataques;
    }
}
