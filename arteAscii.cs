
using System.Runtime.CompilerServices;

namespace Pantallas;

public class Ventana{
    public int Ancho {get; set;}
    public int Altura {get;set;}
    public ConsoleColor Color {get;set;}
    
    public Ventana(int ancho, int altura, ConsoleColor color){
        Ancho = ancho;
        Altura = altura;
        Color = color;
        Init();
    }
    private void Init(){
        Console.SetWindowSize(Ancho,Altura);
        Console.Title = "El Guerrero Universitario";
        Console.BackgroundColor = Color;
        Console.Clear();
    }
}
public class pantallaPrincipal{
    private static string mensaje = "Ingrese enter para continuar";
            private static string menuPrincipal = $@"
        
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
                     


                                                        _       _      _           
                                                       (_)___  (_)____(_)___ ______
                                                      / / __ \/ / ___/ / __ `/ ___/
                                                     / / / / / / /__/ / /_/ / /    
                                                    /_/_/ /_/_/\___/_/\__,_/_/     
               
    ";
    public static void mostrarMenu(){
        int top = Console.CursorTop;

        bool continuar = false;
        Console.WriteLine(menuPrincipal);


        while (!continuar)
        {
            int s = mensaje.Length;
            int left  = (Console.WindowWidth/2) - (s/2);
            Console.SetCursorPosition(60, 35); // Establecer la posición del cursor para el mensaje
            Console.Write(new string(' ', mensaje.Length)); // Borrar el mensaje

            Thread.Sleep(500);

            Console.SetCursorPosition(60, 35);

            Console.Write(mensaje); // Mostrar el mensaje

            Thread.Sleep(500);

            if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
            {
                continuar = true;
            }
        }
        Console.Clear();
    }
}