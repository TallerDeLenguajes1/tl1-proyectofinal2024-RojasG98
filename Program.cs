
using Personajes;
using Pantallas;

//inicio del juego
//mostramos la pantalla principal
Ventana ventana = new Ventana(150, 30);
Console.Clear();
//leemos la tecla de las opciones del menu
char tecla;
int bandera = 0;
pantallaPrincipal.mostrarMenu();
do
{
    tecla = Console.ReadKey().KeyChar;
    Console.Clear();
    if (tecla == '1' || tecla == '2' || tecla == '3')
    {
        bandera = 1;
    }
    else
    {
        Console.Clear();
        Console.SetCursorPosition(60, 35); // Establecer la posición del cursor para el mensaje
        Console.WriteLine("Ingrese una opcion valida!");
        Thread.Sleep(2000);
    }
} while (bandera != 1);
//Vemos si existe el archivo de los personajes si no existe lo creamos sino los leemos
var archivos = new PersonajesJson();
string archivoJefes = "./json/jefes.json";
string archivoJugador = "./json/jugador.json";
Estudiante jugador = null;
List<JefeCatedra> jefes = null;

switch (tecla)
{
    case '1':
        if (!archivos.Existe(archivoJefes) && !archivos.Existe(archivoJugador))
        {
            jefes = FabricaDePersonajes.crearBosses();
            archivos.GuardarJefes(jefes, archivoJefes); 
            jugador = FabricaDePersonajes.leerDatosJugador();
            archivos.GuardarJugador(jugador, archivoJugador);
        }
        else
        {
            //ya existia una partida por lo que borramos ese json y creamos uno nuevo.
            try
            {
                File.Delete(archivoJugador);
                File.Delete(archivoJefes);
                //Volvemos a crear los bosses y pedimos datos nuevamente
                jefes = FabricaDePersonajes.crearBosses();
                archivos.GuardarJefes(jefes, archivoJefes); 
                jugador = FabricaDePersonajes.leerDatosJugador();
                archivos.GuardarJugador(jugador, archivoJugador);
            }
            catch (Exception error)
            {
                Console.WriteLine($"Error al crear nueva partida{error.Message}");
            }
        }
        break;
    case '2':
        jefes = archivos.LeerJefes(archivoJefes);
        jugador = archivos.LeerJugador(archivoJugador);
        break;
    case '3':
        break;
}
Console.Clear();
if (jugador != null)
{
    pantallaDialogos.mostrarDialogos1(jugador);
}

