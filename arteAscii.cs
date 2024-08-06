using System.Linq;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using Personajes;
using System.Security.Cryptography.X509Certificates;
using NAudio.Wave;

namespace Pantallas;


public class Ventana
{
    public int Ancho { get; set; }
    public int Altura { get; set; }

    public Ventana(int ancho, int altura)
    {
        Ancho = ancho;
        Altura = altura;
        Init();
    }
    private void Init()
    {
        Console.SetWindowSize(Ancho, Altura);
        Console.Title = "El Guerrero Universitario";
        Console.Clear();
    }
}
public class pantallaPrincipal
{

    public static void mostrarMenu()
    {
                string[] titulos = new string[]
        {
            "▄███▄   █          ▄▀    ▄   ▄███▄   █▄▄▄▄ █▄▄▄▄ ▄███▄   █▄▄▄▄ ████▄",
            "█▀   ▀  █        ▄▀       █  █▀   ▀  █  ▄▀ █  ▄▀ █▀   ▀  █  ▄▀ █   █",
            "██▄▄    █        █ ▀▄  █   █ ██▄▄    █▀▀▌  █▀▀▌  ██▄▄    █▀▀▌  █   █",
            "█▄   ▄▀ ███▄     █   █ █   █ █▄   ▄▀ █  █  █  █  █▄   ▄▀ █  █  ▀████",
            "▀███▀       ▀     ███  █▄ ▄█ ▀███▀     █     █   ▀███▀     █        ",
            "                                        ▀▀▀           ▀     ▀       ",
            "",
            "",
            "                                                                          ▀     ",
            "  ▄      ▄   ▄█     ▄   ▄███▄   █▄▄▄▄    ▄▄▄▄▄   ▄█    ▄▄▄▄▀ ██   █▄▄▄▄ ▄█ ████▄",
            "   █      █  ██      █  █▀   ▀  █  ▄▀   █     ▀▄ ██ ▀▀▀ █    █ █  █  ▄▀ ██ █   █",
            "█   █ ██   █ ██ █     █ ██▄▄    █▀▀▌  ▄  ▀▀▀▀▄   ██     █    █▄▄█ █▀▀▌  ██ █   █",
            "█   █ █ █  █ ▐█  █    █ █▄   ▄▀ █  █   ▀▄▄▄▄▀    ▐█    █     █  █ █  █  ▐█ ▀████",
            "█▄ ▄█ █  █ █  ▐   █  █  ▀███▀     █               ▐   ▀         █   █    ▐      ",
            " ▀▀▀  █   ██       █▐            ▀                             █   ▀            ",
            "                   ▐                                          ▀                 "
        };

        for (int i = 0; i < titulos.Length; i++)
                {
                    Escribir.centrarCadena(titulos[i], i + 4);
                }
        
        Escribir.centrarCadena("1.Nueva Partida", 23);
        Escribir.centrarCadena("2.Cargar Partida", 24);
        Escribir.centrarCadena("3.Records", 25);
        Escribir.centrarCadena("4.Salir", 26);
    }

}

public class pantallaDialogos
{
 
    private static string[] msjGanador = new string[]
    {
        
    " ██████╗  █████╗ ███╗   ██╗ █████╗ ███████╗████████╗███████╗██╗",
    "██╔════╝ ██╔══██╗████╗  ██║██╔══██╗██╔════╝╚══██╔══╝██╔════╝██║",
    "██║  ███╗███████║██╔██╗ ██║███████║███████╗   ██║   █████╗  ██║",
    "██║   ██║██╔══██║██║╚██╗██║██╔══██║╚════██║   ██║   ██╔══╝  ╚═╝",
    "╚██████╔╝██║  ██║██║ ╚████║██║  ██║███████║   ██║   ███████╗██╗",
    " ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═══╝╚═╝  ╚═╝╚══════╝   ╚═╝   ╚══════╝╚═╝"
    };

    private static string[] msjfinal = new string[]{
    "███████╗██╗         ███████╗██╗███╗   ██╗██████╗ ",
    "██╔════╝██║         ██╔════╝██║████╗  ██║╚════██╗",
    "█████╗  ██║         █████╗  ██║██╔██╗ ██║  ▄███╔╝",
    "██╔══╝  ██║         ██╔══╝  ██║██║╚██╗██║  ▀▀══╝ ",
    "███████╗███████╗    ██║     ██║██║ ╚████║  ██╗   ",
    "╚══════╝╚══════╝    ╚═╝     ╚═╝╚═╝  ╚═══╝  ╚═╝   "
    };

    private static string[] msjGameOver = new string[]
    {
        "  ▄████  ▄▄▄       ███▄ ▄███▓▓█████     ▒█████   ██▒   █▓▓█████  ██▀███  ",
        " ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀    ▒██▒  ██▒▓██░   █▒▓█   ▀ ▓██ ▒ ██▒",
        "▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███      ▒██░  ██▒ ▓██  █▒░▒███   ▓██ ░▄█ ▒",
        "░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄    ▒██   ██░  ▒██ █░░▒▓█  ▄ ▒██▀▀█▄  ",
        "░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒   ░ ████▓▒░   ▒▀█░  ░▒████▒░██▓ ▒██▒",
        " ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░   ░ ▒░▒░▒░    ░ ▐░  ░░ ▒░ ░░ ▒▓ ░▒▓░",
        "  ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░     ░ ▒ ▒░    ░ ░░   ░ ░  ░  ░▒ ░ ▒░",
        "░ ░   ░   ░   ▒   ░      ░      ░      ░ ░ ░ ▒       ░░     ░     ░░   ░ ",
        "      ░       ░  ░       ░      ░  ░       ░ ░        ░     ░  ░   ░     ",
        "                                                     ░                   ",
    };
    private static string persona = @"
                                              ////^\\\\
                                              | ^   ^ |
                                             @ (o) (o) @
                                              |   <   |
                                              |  ___  |
                                               \_____/
                                             ____|  |____
                                            /    \__/    \
                                           /              \
                                          /\_/|        |\_/\
                                         / /  |        |  \ \
                                        ( <   |        |   > )
                                         \ \  |        |  / /
                                          \ \ |________| / /";

    private static string cielo1 = @"
              .
               					
              |					
     .               /				
      \       I     				
                  /
        \  ,g88R_                                                 _                                                _
          d888(`  ).                   _                        (`  ).                   _                       (`  ).                   _       
 -  --==  888(     ).=--           .+(`  )`.                   (     ).              .:(`  )`.                  (     ).              .:(`  )`.   
)         Y8P(       '`.          :(   .    )                 _(       '`.          :(   .    )                _(       '`.          :(   .    )  
        .+(`(      .   )     .--  `.  (    ) )           .=(`(      .   )     .--  `.  (    ) )           .=(`(      .   )     .--  `.  (    ) )    
       ((    (..__.:'-'   .=(   )   ` _`  ) )            ((    (..__.:'-'   .+(   )   ` _`  ) )           ((    (..__.:'-'   .+(   )   ` _`  ) )    
`.     `(       ) )       (   .  )     (   )  ._         `(       ) )       (   .  )     (   )  ._        `(       ) )       (   .  )     (   )  ._  
  )      ` __.:'   )     (   (   ))     `-'.:(`  )         ` __.:'   )     (   (   ))     `-'.-(`  )        ` __.:'   )     (   (   ))     `-'.-(`  )
)  )  ( )       --'       `- __.'         :(      ))    ( )       --'       `- __.'         :(      ))   ( )       --'       `- __.'         :(      
.-'  (_.'          .')                    `(    )  )) (_.'          .')                    `(    )  )) (_.'          .')                    `(    )  
                  (_  )                     ` __.:'                (_  )                     ` __.:'                (_  )                     ` __.:'  
                  ";
    private static string combate =
    @" __________________________________________________________________________________________________________________________________________________"+ "\n" +
    @"|                                                                                                                                                  |"+"\n" +
    @"|                                                                                                                                                  |"+"\n" +
    @"|                                                                                                                           /^^^^^^^\              |"+"\n" +
    @"|                                                                                                                           | ~   ~ |              |"+"\n" +
    @"|                                                                                                                           | () () |              |"+"\n" +
    @"|                                                                                                                            \  ^  /               |"+"\n" +
    @"|                                                                                                                             |||||                |"+"\n" +
    @"|                       &&&&&&&                                                                                              / ||| \               |"+"\n" +
    @"|                      &/     \&                                                                                            /  |||  \              |"+"\n" +
    @"|                     <|       |>                                                                                          |   |||   |             |"+"\n" +
    @"|                       \_____/                                                                                             \_______/              |"+"\n" +
    @"|                       /|||||\                                                                                                                    |"+"\n" +
    @"|                      /|||||||\                                                                                                                   |"+"\n" +
    @"|                     / ||||| ||\                                                                                                                  |"+"\n" +
    @"|__________________________________________________________________________________________________________________________________________________|"+"\n" +
    @"|                                                                                                         |                                        |"+"\n" +
    @"|                                                                                                         |                                        |"+"\n" +
    @"|                                                                                                         |                                        |"+"\n" +
    @"|                                                                                                         |                                        |"+"\n" +
    @"|                                                                                                         |                                        |"+"\n" +
    @"|                                                                                                         |                                        |"+"\n" +
    @"|                                                                                                         |                                        |"+"\n" +
    @"|                                                                                                         |                                        |"+"\n" +
    @"|                                                                                                         |                                        |"+"\n" +
    @"|                                                                                                         |                                        |"+"\n" +
    @"|                                                                                                         |                                        |"+"\n" +
    @" __________________________________________________________________________________________________________________________________________________";
    private static string pantallaNivel =
    @"____________________________________________________________________________________________________________________________________________________"+"\n" +
    @"|:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::|"+"\n" +
    @"|:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::|"+"\n" +
    @"|:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::|"+"\n" +
    @"|:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::|"+"\n" +
    @"|:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::|"+"\n" +
    @"|:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::|"+"\n" +
    @"|::::::::::::::::::::::                                                                                                       ::::::::::::::::::::::|"+"\n" +
    @"|::::::::::::::::::::::                                                                                                       ::::::::::::::::::::::|"+"\n" +
    @"|::::::::::::::::::::::                                                                                                       ::::::::::::::::::::::|"+"\n" +
    @"|::::::::::::::::::::::                                                                                                       ::::::::::::::::::::::|"+"\n" +
    @"|::::::::::::::::::::::                                                                                                       ::::::::::::::::::::::|"+"\n" +
    @"|::::::::::::::::::::::                                                                                                       ::::::::::::::::::::::|"+"\n" +
    @"|::::::::::::::::::::::                                                                                                       ::::::::::::::::::::::|"+"\n" +
    @"|::::::::::::::::::::::                                                                                                       ::::::::::::::::::::::|"+"\n" +
    @"|::::::::::::::::::::::                                                                                                       ::::::::::::::::::::::|"+"\n" +
    @"|::::::::::::::::::::::                                                                                                       ::::::::::::::::::::::|"+"\n" +
    @"|::::::::::::::::::::::                                                                                                       ::::::::::::::::::::::|"+"\n" +
    @"|::::::::::::::::::::::                                                                                                       ::::::::::::::::::::::|"+"\n" +
    @"|::::::::::::::::::::::                                                                                                       ::::::::::::::::::::::|"+"\n" +
    @"|::::::::::::::::::::::                                                                                                       ::::::::::::::::::::::|"+"\n" +
    @"|::::::::::::::::::::::                                                                                                       ::::::::::::::::::::::|"+"\n" +
    @"|::::::::::::::::::::::                                                                                                       ::::::::::::::::::::::|"+"\n" +
    @"|:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::|"+"\n" +
    @"|:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::|"+"\n" +
    @"|:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::|"+"\n" +
    @"|:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::|"+"\n" +
    @"|:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::|"+"\n" +
    @"|:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::|"+"\n" +
    @" ___________________________________________________________________________________________________________________________________________________";
    public static void mostrarDialogos1(Estudiante jugador)
    {
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        Console.Write(cielo1);
        Console.SetCursorPosition(20, 18);
        Console.Write(persona);
        Escribir.escribiryborrar($"Bienvenido {jugador.Datos.Nombre}!", 23, 65);
        Escribir.escribiryborrar("Soy Ruperto es mi segundo año aqui", 23, 65);
        Escribir.escribiryborrar("Tengo 27 y tu?", 23,65);
        Escribir.escribiryborrar($"Que? que tienes {jugador.Datos.Edad}?", 23,65);
        Escribir.escribiryborrar("Vaya... no me lo esperaba", 23,65);
        Escribir.escribiryborrar("Por cierto elegiste una carrera dificil", 23,65);
        Escribir.escribiryborrar("Tienes un largo y dificil camino este año", 23,65);
        Escribir.escribiryborrar("Deberas enfrentarte a 10 jefes de catedra", 23,65);
        Escribir.escribiryborrar("Te desaprueban 5 veces antes que rindas un parcial", 23,65);
        Escribir.escribiryborrar("Ten cuidado y no te confies", 23,65);
        Escribir.escribiryborrar("Si necesitas apuntes estoy vendiendo unos casi 0km", 23,65);
        Escribir.escribiryborrar("oh okay... bueno si los necesitas avisame", 23,65);
        Console.Clear();
    }

    public static void presentarNiveles(List<JefeCatedra> jefes)
    {

        int nivel = 1;
        foreach (var boss in jefes)
        {
            Console.Write(pantallaNivel);
            Escribir.escribir("Nivel " + nivel, 11);
            Escribir.escribir(boss.Nombre, 12);
            Escribir.escribir(boss.Edad + " Años", 13);
            Escribir.escribir(boss.Materia.Nombre, 14);
            Escribir.escribir("Ataque especial:" + boss.Materia.AtaqueEspecial, 15);
            Thread.Sleep(1500);
            nivel++;
            Console.Clear();
        }
    }


    public static void mostrarAtaques(Estudiante jugador, List<Ataques> ataques)
    {
        Console.Clear();
        Console.Write(combate);
        Ataques[] opciones = ataques.ToArray();
        Console.SetCursorPosition(16, 18);
        Console.Write("0 - " + opciones[0].Nombre);
        Console.SetCursorPosition(16, 19);
        Console.Write("Daño: " + opciones[0].Danio);
        Console.SetCursorPosition(16, 20);
        Console.Write("Energia: " + -opciones[0].CostoEnergía);
        Console.SetCursorPosition(16, 21);
        Console.Write("Estres: " + opciones[0].AumentoEstres);

        Console.SetCursorPosition(64, 18);
        Console.Write("1 - " + opciones[1].Nombre);
        Console.SetCursorPosition(64, 19);
        Console.Write("Daño: " + opciones[1].Danio);
        Console.SetCursorPosition(64, 20);
        Console.Write("Energia: " + -opciones[1].CostoEnergía);
        Console.SetCursorPosition(64, 21);
        Console.Write("Estres: " + opciones[1].AumentoEstres);

        Console.SetCursorPosition(16, 23);
        Console.Write("2 - " + opciones[2].Nombre);
        Console.SetCursorPosition(16, 24);
        Console.Write("Daño: " + opciones[2].Danio);
        Console.SetCursorPosition(16, 25);
        Console.Write("Energia: " + -opciones[2].CostoEnergía);
        Console.SetCursorPosition(16, 26);
        Console.Write("Estres: " + opciones[2].AumentoEstres);

        Console.SetCursorPosition(64, 23);
        if (opciones[3].Danio >= 50)
        {
            Console.Write("3 - " + opciones[3].Nombre+" ULTIMATE");
        }
        else
        {
            Console.Write("3 - " + opciones[3].Nombre);     
        }
        Console.SetCursorPosition(64, 24);
        Console.Write("Daño: " + opciones[3].Danio);
        Console.SetCursorPosition(64, 25);
        Console.Write("Energia: " + -opciones[3].CostoEnergía);
        Console.SetCursorPosition(64, 26);
        Console.Write("Estres: " + opciones[3].AumentoEstres);

    }

    public static void mostrarStatsJugador(Estudiante Jugador,int nivel, string materia)
    {
        string mostrarNivel = "NIVEL "+ nivel;
        string mostrarMateria = "MATERIA: "+materia;
        int centrar = 107 + (20-(mostrarNivel.Length/2));
        Console.SetCursorPosition(centrar, 17);
        Console.Write(mostrarNivel);
        centrar = 107 + (20-(mostrarMateria.Length/2));
        Console.SetCursorPosition(centrar, 18);
        Console.Write(mostrarMateria);
        Console.SetCursorPosition(115, 20);
        Console.Write("Stats de " + Jugador.Datos.Nombre);
        Console.SetCursorPosition(115, 22);
        Console.Write("Vidas: " + Escribir.vidas(Jugador.Vidas));
        Console.SetCursorPosition(115, 23);
        Console.Write("Salud: " + Escribir.BarraDeStat(Jugador.Salud) + Jugador.Salud);
        Console.SetCursorPosition(115, 24);
        Console.Write("Energia: " + Escribir.BarraDeStat(Jugador.Energia) + Jugador.Energia);
        Console.SetCursorPosition(115, 25);
        Console.Write("Estres: " + Escribir.BarraDeStat(Jugador.Estres) + Jugador.Estres);
        Console.SetCursorPosition(115, 26);
        Console.Write("Conocimiento: " + Escribir.BarraDeStat(Jugador.Conocimiento) + Jugador.Conocimiento);
    }

    public static void mostrarVidaBoss(JefeCatedra jefe)
    {
        string mensaje = jefe.Nombre + ": " + Escribir.BarraDeStat(jefe.Salud) + jefe.Salud;
        int centrarBarra = 128 - (mensaje.Length /2);
        if (centrarBarra + (mensaje.Length /2)>150)
        {
            centrarBarra -= 150 - (centrarBarra + (mensaje.Length /2));
        }
        Console.SetCursorPosition(centrarBarra, 13);
        Console.Write(mensaje);
    }
    public static void gameOver(){
        for (int i = 0; i < msjGameOver.Length; i++)
        {
            Escribir.centrarCadena(msjGameOver[i], i + 4);
        }
    }
    public static void pantallaGanador(){
        var winnerMusic = new AudioFileReader(@"C:\Users\rojas\TallerLenguaje1\tl1-proyectofinal2024-RojasG98\audio\VictoryTheme.wav");
        var playWinnerMusic = new WaveOutEvent();
        playWinnerMusic.Init(winnerMusic);
        playWinnerMusic.Play();
        for(int i=0; i< msjGanador.Length; i++)
        {
            Escribir.centrarCadena(msjGanador[i],i+4);
        }
        Escribir.escribiryborrarCentrado("Y asi luego de un estresante y largo año  se logro pasar de primer año",20);
        Escribir.escribiryborrarCentrado("Éstas épicas peleas serán recordadas por el resto de la eternidad",20);
        Escribir.escribiryborrarCentrado("Solo queda descansar en las vacaciones de verano esperando el próximo año",20);
        Console.SetCursorPosition(20, 18);
        Console.Write(persona);
        Escribir.escribiryborrar($"Bien.. ya cumplí mi mision aquí", 23, 65);
        Escribir.escribiryborrarCentrado("De que mision esta hablando? si no usted no hizo nada", 27);
        Escribir.escribiryborrar($"Ah no?", 23, 65);
        playWinnerMusic.Stop();
        Console.Clear();
        for (int i = 0; i < msjfinal.Length; i++)
        {
            Escribir.centrarCadena(msjfinal[i],i+4);
        }
        Thread.Sleep(1500);
    }
}

public class Escribir
{
    public static void escribiryborrar(string mensaje, int altura, int posX){
        var speakSound = new AudioFileReader(@"C:\Users\rojas\TallerLenguaje1\tl1-proyectofinal2024-RojasG98\audio\speakingSound.wav");
        var playSpeakSound = new WaveOutEvent();
        playSpeakSound.Init(speakSound);
        
        for (int i = 0; i <= mensaje.Length; i++)
        {
            speakSound.CurrentTime = TimeSpan.FromSeconds(0);
            Console.SetCursorPosition(posX, altura);
            Console.Write(mensaje.Substring(0, i)); // Mostrar el string progresivamente
            playSpeakSound.Play();
            Thread.Sleep(20);
        }
        Thread.Sleep(1500);
        for (int i = 0; i <= mensaje.Length; i++)
        {
            Console.SetCursorPosition(posX, altura);
            Console.Write(new string(' ', mensaje.Length));
        }
        playSpeakSound.Dispose();
    }
    public static void escribiryborrarCentrado(string mensaje, int altura)
    {
        var speakSound = new AudioFileReader(@"C:\Users\rojas\TallerLenguaje1\tl1-proyectofinal2024-RojasG98\audio\speakingSound.wav");
        var playSpeakSound = new WaveOutEvent();
        playSpeakSound.Init(speakSound);
        
        for (int i = 0; i <= mensaje.Length; i++)
        {
            speakSound.CurrentTime = TimeSpan.FromSeconds(0);
            Console.SetCursorPosition(74-(mensaje.Length/2), altura);
            Console.Write(mensaje.Substring(0, i)); // Mostrar el string progresivamente
            playSpeakSound.Play();
            Thread.Sleep(20);
        }
        Thread.Sleep(1500);
        for (int i = 0; i <= mensaje.Length; i++)
        {
            Console.SetCursorPosition(74-(mensaje.Length/2), altura);
            Console.Write(new string(' ', mensaje.Length));
        }
        playSpeakSound.Dispose();
    }
    public static void escribir(string mensaje, int altura)
    {
        var speakSound = new AudioFileReader(@"C:\Users\rojas\TallerLenguaje1\tl1-proyectofinal2024-RojasG98\audio\speakingSound.wav");
        var playSpeakSound = new WaveOutEvent();
        playSpeakSound.Init(speakSound);
        for (int i = 0; i <= mensaje.Length; i++)
        {
            speakSound.CurrentTime = TimeSpan.FromSeconds(0);
            Console.SetCursorPosition(74-(mensaje.Length/2), altura);
            Console.Write(mensaje.Substring(0, i)); // Mostrar el string progresivamente
            playSpeakSound.Play();
            Thread.Sleep(20);
        }
    }
    public static void centrarCadena(string mensaje, int altura)
    {
        int left = (Console.WindowWidth - mensaje.Length) / 2;
        Console.SetCursorPosition(left, altura);
        Console.Write(mensaje);
    }
    public static string BarraDeStat(int Stat)
    {
        int unidades = Stat / 10;
        string barra = "";
        for (int i = 0; i < unidades; i++)
        {
            barra += '▄';
        }
        return barra;
    }

    public static string vidas(int vidas)
    {
        string corazones = "";
        for (int i = 0; i < vidas; i++)
        {
            corazones += "♥ ";
        }
        return corazones;
    }
    public static void borrar(int cantEspacios, int altura, int posX)
    {
        for (int i = 0; i <= cantEspacios; i++)
        {
            Console.SetCursorPosition(posX, altura);
            Console.Write(new string(' ', cantEspacios));
        }
    }
}