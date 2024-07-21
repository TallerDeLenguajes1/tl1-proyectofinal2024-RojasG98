using System.Linq;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using Personajes;
using System.Security.Cryptography.X509Certificates;

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

        //escribo titulo "el guerrero"
        string mensaje = "▄███▄   █          ▄▀    ▄   ▄███▄   █▄▄▄▄ █▄▄▄▄ ▄███▄   █▄▄▄▄ ████▄";
        Escribir.centrarCadena(mensaje, 5);

        mensaje = "█▀   ▀  █        ▄▀       █  █▀   ▀  █  ▄▀ █  ▄▀ █▀   ▀  █  ▄▀ █   █";
        Escribir.centrarCadena(mensaje, 6);

        mensaje = "██▄▄    █        █ ▀▄  █   █ ██▄▄    █▀▀▌  █▀▀▌  ██▄▄    █▀▀▌  █   █";
        Escribir.centrarCadena(mensaje, 7);

        mensaje = "█▄   ▄▀ ███▄     █   █ █   █ █▄   ▄▀ █  █  █  █  █▄   ▄▀ █  █  ▀████";
        Escribir.centrarCadena(mensaje, 8);

        mensaje = "▀███▀       ▀     ███  █▄ ▄█ ▀███▀     █     █   ▀███▀     █        ";
        Escribir.centrarCadena(mensaje, 9);

        mensaje = "                                        ▀▀▀           ▀     ▀       ";
        Escribir.centrarCadena(mensaje, 10);
        //escribo titulo "Univarsitario centrado"
        mensaje = "                                                                          ▀     ";
        Escribir.centrarCadena(mensaje, 13);

        mensaje = "  ▄      ▄   ▄█     ▄   ▄███▄   █▄▄▄▄    ▄▄▄▄▄   ▄█    ▄▄▄▄▀ ██   █▄▄▄▄ ▄█ ████▄";
        Escribir.centrarCadena(mensaje, 14);

        mensaje = "   █      █  ██      █  █▀   ▀  █  ▄▀   █     ▀▄ ██ ▀▀▀ █    █ █  █  ▄▀ ██ █   █";
        Escribir.centrarCadena(mensaje, 15);

        mensaje = "█   █ ██   █ ██ █     █ ██▄▄    █▀▀▌  ▄  ▀▀▀▀▄   ██     █    █▄▄█ █▀▀▌  ██ █   █";
        Escribir.centrarCadena(mensaje, 16);

        mensaje = "█   █ █ █  █ ▐█  █    █ █▄   ▄▀ █  █   ▀▄▄▄▄▀    ▐█    █     █  █ █  █  ▐█ ▀████";
        Escribir.centrarCadena(mensaje, 17);

        mensaje = "█▄ ▄█ █  █ █  ▐   █  █  ▀███▀     █               ▐   ▀         █   █    ▐      ";
        Escribir.centrarCadena(mensaje, 18);

        mensaje = " ▀▀▀  █   ██       █▐            ▀                             █   ▀            ";
        Escribir.centrarCadena(mensaje, 19);

        mensaje = "                   ▐                                          ▀                 ";
        Escribir.centrarCadena(mensaje, 20);
        //creo menu opciones

        mensaje = "1.Nueva Partida";
        Escribir.centrarCadena(mensaje, 25);
        mensaje = "2.Cargar Partida";
        Escribir.centrarCadena(mensaje, 26);
        mensaje = "3.Records";
        Escribir.centrarCadena(mensaje, 27);

    }

}

public class pantallaDialogos
{
    public static void escribiryborrar(string mensaje,int altura)
    {

        for (int i = 0; i <= mensaje.Length; i++)
        {
            Console.SetCursorPosition(60, altura);
            Console.Write(mensaje.Substring(0, i)); // Mostrar el string progresivamente
            Thread.Sleep(50);
        }
        Thread.Sleep(1500);
        for (int i = 0; i <= mensaje.Length; i++)
        {
            Console.SetCursorPosition(60, altura);
            Console.Write(new string(' ', mensaje.Length));
        }
    }
    public static void escribir(string mensaje,int altura)
    {
        for (int i = 0; i <= mensaje.Length; i++)
        {
            Console.SetCursorPosition(60, altura);
            Console.Write(mensaje.Substring(0, i)); // Mostrar el string progresivamente
            Thread.Sleep(50);
        }
    }
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
                                          \ \ |________| / /
    ";

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
    private static string combate = @"
                                                                                                                                                     
        _____________________________________________________________________________________________________________________________________
        |                                                                                                                                    |        
        |                                                                                                                                    |
        |                                                                                                                                    |
        |                                                                                                                                    |
        |                                                                                                                                    |
        |                                                                                                                                    |
        |                                                                                                                                    |
        |                                                                                                                                    |
        |                                                                                                                                    |
        |                                                                                                                                    |
        |                                                                                                                                    |
        |____________________________________________________________________________________________________________________________________|
        |                                                                                               |                                    |
        |                                                                                               |                                    |
        |                                                                                               |                                    |
        |                                                                                               |                                    |
        |                                                                                               |                                    |
        |                                                                                               |                                    |
        |                                                                                               |                                    |
        |                                                                                               |                                    |
        ________________________________________________________________________________________________|____________________________________        ";
    private static string pantallaNivel = @"
                                                                                                                                                     
        _____________________________________________________________________________________________________________________________________
        |::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::|
        |::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::|
        |::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::|
        |::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::|
        |::::::::::::::::::::::                                                                                        ::::::::::::::::::::::|
        |::::::::::::::::::::::                                                                                        ::::::::::::::::::::::|
        |::::::::::::::::::::::                                                                                        ::::::::::::::::::::::|
        |::::::::::::::::::::::                                                                                        ::::::::::::::::::::::|
        |::::::::::::::::::::::                                                                                        ::::::::::::::::::::::|
        |::::::::::::::::::::::                                                                                        ::::::::::::::::::::::|
        |::::::::::::::::::::::                                                                                        ::::::::::::::::::::::|
        |::::::::::::::::::::::                                                                                        ::::::::::::::::::::::|   
        |::::::::::::::::::::::                                                                                        ::::::::::::::::::::::|
        |::::::::::::::::::::::                                                                                        ::::::::::::::::::::::|
        |::::::::::::::::::::::                                                                                        ::::::::::::::::::::::|
        |::::::::::::::::::::::                                                                                        ::::::::::::::::::::::|
        |::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::|
        |::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::|
        |::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::|
        |::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::|
        _____________________________________________________________________________________________________________________________________        ";
    public static void mostrarDialogos1(Estudiante jugador)
    {
        string mensaje;
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        Console.Write(cielo1);
        Console.SetCursorPosition(70, 18);
        Console.Write(persona);

        mensaje = $"Bienvenido {jugador.Datos.Nombre}!";
        escribiryborrar(mensaje,23);

        mensaje = "Soy Ruperto es mi segundo año aqui";
        escribiryborrar(mensaje,23);

        mensaje = "Tengo 27 y tu?";
        escribiryborrar(mensaje,23);

        mensaje = $"Que? que tienes {jugador.Datos.Edad}?";
        escribiryborrar(mensaje,23);

        mensaje = "Vaya... no me lo esperaba";
        escribiryborrar(mensaje,23);

        mensaje = "Por cierto elegiste una carrera dificil";
        escribiryborrar(mensaje,23);

        mensaje = "Tienes un largo y dificil camino este año";
        escribiryborrar(mensaje,23);

        mensaje = "Deberas enfrentarte a 10 jefes de catedra";
        escribiryborrar(mensaje,23);

        mensaje = "Te desaprueban 5 veces antes que rindas un parcial";
        escribiryborrar(mensaje,23);

        mensaje = "Ten cuidado y no te confies";
        escribiryborrar(mensaje,23);

        mensaje = "Si necesitas apuntes estoy vendiendo unos casi 0km";
        escribiryborrar(mensaje,23);

        mensaje = "oh okay... bueno si los necesitas avisame";
        escribiryborrar(mensaje,23);
        Console.Clear();
    }

    public static void presentarNiveles(List<JefeCatedra> jefes){
        
        int nivel = 1;
        foreach (var boss in jefes)
        {
            Console.Write(pantallaNivel);
            escribir("Nivel "+nivel, 11);
            escribir(boss.Nombre,12);
            escribir(boss.Edad+" Años",13);
            escribir(boss.Materia.Nombre,14);
            escribir("Ataque especial:"+boss.Materia.AtaqueEspecial,15);
            Thread.Sleep(1500);
            nivel++;
            Console.Clear();
        }

    }
}

public class Escribir
{
    public static void centrarCadena(string mensaje, int altura)
    {
        int left = (Console.WindowWidth - mensaje.Length) / 2;
        Console.SetCursorPosition(left, altura);
        Console.Write(mensaje);
    }
}