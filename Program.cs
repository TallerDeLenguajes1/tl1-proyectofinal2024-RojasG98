
using Personajes;
using Pantallas;
using System.Reflection.PortableExecutable;

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
    pantallaDialogos.presentarNiveles(jefes);
}
JefeCatedra[] niveles = jefes.ToArray();
bandera = 0;

for (int i = 0; i < 10; i++)
{
    Console.Clear();
    int nroNivel = i + 1;
    pantallaDialogos.escribiryborrar("NIVEL " + nroNivel, 15);
    Thread.Sleep(1000);
    Console.Clear();
    do
    {
        List<Ataques> ataques = Combate.basicosDelTurno(jugador);
        Ataques[] ataquesAux = ataques.ToArray();
        do
        {
            pantallaDialogos.mostrarAtaques(jugador, ataques);
            pantallaDialogos.mostrarStatsJugador(jugador);
            pantallaDialogos.mostrarVidaBoss(niveles[i]);
            do
            {
                Console.SetCursorPosition(0, 0);
                tecla = Console.ReadKey().KeyChar;
                if (tecla == '1' || tecla == '2' || tecla == '3' || tecla == '0')
                {
                    bandera = 1;
                }
                else
                {
                    Console.SetCursorPosition(60, 15); // Establecer la posición del cursor para el mensaje
                    pantallaDialogos.escribiryborrar("Ingrese una opcion valida!",15);
                    Thread.Sleep(1000);
                }
            } while (bandera != 1);
            bandera = 0;
            if (jugador.Energia >= ataquesAux[int.Parse(tecla.ToString())].CostoEnergía)
            {
                bandera = 1;
            }
            else
            {
                Console.SetCursorPosition(60, 15); // Establecer la posición del cursor para el mensaje
                pantallaDialogos.escribiryborrar("No tenes suficiente energia",15);
                Thread.Sleep(1000);
                Console.Clear();
            }
        } while (bandera != 1);
        Combate.realizarAtaque(ataquesAux[int.Parse(tecla.ToString())], jugador, niveles[i], i + 1);
        pantallaDialogos.escribiryborrar(jugador.Datos.Nombre + " uso " + ataquesAux[int.Parse(tecla.ToString())].Nombre, 15);
        Thread.Sleep(1000);
        Escribir.borrar(35, 11, 105);
        pantallaDialogos.mostrarVidaBoss(niveles[i]);
        if (niveles[i].Salud > 0)
        {
            Combate.recibirAtaque(jugador, niveles[i], i + 1);
            Thread.Sleep(1000);
        }

    } while (niveles[i].Salud > 0 && jugador.Vidas != 0);
    Console.Clear();
    pantallaDialogos.escribiryborrar("Nivel superado :)", 15);
}


