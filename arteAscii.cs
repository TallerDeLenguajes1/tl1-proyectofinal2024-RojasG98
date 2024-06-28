
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using Personajes;

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
    private static string menuPrincipal = @"
        
                                ▄███▄   █          ▄▀    ▄   ▄███▄   █▄▄▄▄ █▄▄▄▄ ▄███▄   █▄▄▄▄ ████▄ 
                                █▀   ▀  █        ▄▀       █  █▀   ▀  █  ▄▀ █  ▄▀ █▀   ▀  █  ▄▀ █   █ 
                                ██▄▄    █        █ ▀▄  █   █ ██▄▄    █▀▀▌  █▀▀▌  ██▄▄    █▀▀▌  █   █ 
                                █▄   ▄▀ ███▄     █   █ █   █ █▄   ▄▀ █  █  █  █  █▄   ▄▀ █  █  ▀████ 
                                ▀███▀       ▀     ███  █▄ ▄█ ▀███▀     █     █   ▀███▀     █         
                                                                        ▀▀▀           ▀     ▀             ▀          
                                                
                                  ▄      ▄   ▄█     ▄   ▄███▄   █▄▄▄▄    ▄▄▄▄▄   ▄█    ▄▄▄▄▀ ██   █▄▄▄▄ ▄█ ████▄ 
                                   █      █  ██      █  █▀   ▀  █  ▄▀   █     ▀▄ ██ ▀▀▀ █    █ █  █  ▄▀ ██ █   █ 
                                █   █ ██   █ ██ █     █ ██▄▄    █▀▀▌  ▄  ▀▀▀▀▄   ██     █    █▄▄█ █▀▀▌  ██ █   █ 
                                █   █ █ █  █ ▐█  █    █ █▄   ▄▀ █  █   ▀▄▄▄▄▀    ▐█    █     █  █ █  █  ▐█ ▀████ 
                                █▄ ▄█ █  █ █  ▐   █  █  ▀███▀     █               ▐   ▀         █   █    ▐       
                                 ▀▀▀  █   ██       █▐            ▀                             █   ▀             
                                                   ▐                                          ▀                  
                     


                                                            1.Nuevo Juego
                                                            2.Cargar Juego
                                                            3.Records
               
    ";
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

        mensaje="1.Nueva Partida";
        Escribir.centrarCadena(mensaje, 25);
        mensaje="2.Cargar Partida";
        Escribir.centrarCadena(mensaje, 26);
        mensaje="3.Records";
        Escribir.centrarCadena(mensaje, 27);

    }

}

public class pantallaDialogos
{
    public static void escribiryborrar(string mensaje)
    {

        for (int i = 0; i <= mensaje.Length; i++)
        {
            Console.SetCursorPosition(60, 23);
            Console.Write(mensaje.Substring(0, i)); // Mostrar el string progresivamente
            Thread.Sleep(100);
        }
        Thread.Sleep(2000);
        for (int i = 0; i <= mensaje.Length; i++)
        {
            Console.SetCursorPosition(60, 23);
            Console.Write(new string(' ', mensaje.Length)); // Mostrar el string progresivamente
        }
    }
    public static void borrar(string mensaje)
    {


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
    private static string niveles = @"
                                                                                                                                                     
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

    public static void mostrarDialogos1(Estudiante jugador)
    {
        string mensaje;
        Console.Clear();
        Console.SetCursorPosition(0,0);
        Console.Write(cielo1);
        Console.SetCursorPosition(70, 18);
        Console.Write(persona);

        mensaje = $"Bienvenido {jugador.Datos.Nombre}!";
        escribiryborrar(mensaje);

        mensaje = "Soy Ruperto es mi segundo año aqui";
        escribiryborrar(mensaje);

        mensaje = "Tengo 27 y tu?";
        escribiryborrar(mensaje);

        mensaje = $"Que? que tienes {jugador.Datos.Edad}?";
        escribiryborrar(mensaje);

        mensaje = "Vaya... no me lo esperaba";
        escribiryborrar(mensaje);

        mensaje = "Por cierto elegiste una carrera dificil?";
        escribiryborrar(mensaje);

        mensaje = "Tienes un largo y dificil camino este año";
        escribiryborrar(mensaje);

        mensaje = "Deberas enfrentarte a 10 jefes de catedra";
        escribiryborrar(mensaje);

        mensaje = "Te desaprueban 5 veces antes que rindas un parcial";
        escribiryborrar(mensaje);

        mensaje = "Ten cuidado y no te confies";
        escribiryborrar(mensaje);

        mensaje = "Si necesitas apuntes estoy vendiendo unos casi 0km";
        escribiryborrar(mensaje);

        mensaje = "oh okay... bueno si los necesitas avisame";
        escribiryborrar(mensaje);
        Console.Clear();
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