
using Personajes;
using Pantallas;
using System;
using System.Reflection.PortableExecutable;
using NAudio.Wave;
using System.Net.WebSockets;
using System.Text.Json;
using System.Globalization;
using System.Text.Json.Nodes;


//inicio del juego
//mostramos la pantalla principal
Ventana ventana = new Ventana(150, 30);
Console.Clear();
//leemos la tecla de las opciones del menu
char tecla;
int bandera = 0;
var menuMusic = new AudioFileReader(@"C:\Users\rojas\TallerLenguaje1\tl1-proyectofinal2024-RojasG98\audio\menuMusic.wav");
var playMenuMusic = new WaveOutEvent();
playMenuMusic.Init(menuMusic);
playMenuMusic.Play();
pantallaPrincipal.mostrarMenu();
var selectSound = new AudioFileReader(@"C:\Users\rojas\TallerLenguaje1\tl1-proyectofinal2024-RojasG98\audio\selectionSound.wav");
var playSelectSound = new WaveOutEvent();
do
{
    tecla = Console.ReadKey().KeyChar;
    Console.Clear();
    if (tecla == '1' || tecla == '2' || tecla == '3')
    {
        playSelectSound.Init(selectSound);
        selectSound.CurrentTime = TimeSpan.FromSeconds(0);
        playSelectSound.Play();
        bandera = 1;
        playMenuMusic.Stop();
        playMenuMusic.Dispose();
        Thread.Sleep(500);
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
            NombresGenerados nombresBosses = await obtenerNombres();
            jefes = FabricaDePersonajes.crearBosses(nombresBosses);
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
                NombresGenerados nombresBosses = await obtenerNombres();
                jefes = FabricaDePersonajes.crearBosses(nombresBosses);
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
var prologueMusic = new AudioFileReader(@"C:\Users\rojas\TallerLenguaje1\tl1-proyectofinal2024-RojasG98\audio\prologue.wav");
var playPrologueMusic = new WaveOutEvent();
var cinematicMusic = new AudioFileReader(@"C:\Users\rojas\TallerLenguaje1\tl1-proyectofinal2024-RojasG98\audio\cinematicMusic.wav");
var playCinematicMusic = new WaveOutEvent();
Console.Clear();

if (jugador != null)
{/*
    playPrologueMusic.Init(prologueMusic);
    playPrologueMusic.Play();
    
    pantallaDialogos.mostrarDialogos1(jugador);
    playPrologueMusic.Stop();
    playPrologueMusic.Dispose();
   */ 
    
    playCinematicMusic.Init(cinematicMusic);
    playCinematicMusic.Play(); 
    pantallaDialogos.presentarNiveles(jefes);
    playCinematicMusic.Stop();
    playCinematicMusic.Dispose();
}

JefeCatedra[] niveles = jefes.ToArray();
bandera = 0;
var hitAudio = new AudioFileReader(@"C:\Users\rojas\TallerLenguaje1\tl1-proyectofinal2024-RojasG98\audio\hitSound.wav");
var playHitSound = new WaveOutEvent();
playHitSound.Init(hitAudio);


for (int i = 0; i < 10; i++)
{
    var battleMusic = new AudioFileReader(@"C:\Users\rojas\TallerLenguaje1\tl1-proyectofinal2024-RojasG98\audio\BattleMusic.wav");
    var playBattleMusic = new WaveOutEvent();

    playBattleMusic.Init(battleMusic);
    battleMusic.CurrentTime = TimeSpan.FromSeconds(0);
    playBattleMusic.Play();
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
                    playSelectSound.Init(selectSound);
                    selectSound.CurrentTime = TimeSpan.FromSeconds(0);
                    playSelectSound.Play();
                    bandera = 1;
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.SetCursorPosition(60, 15); // Establecer la posición del cursor para el mensaje
                    pantallaDialogos.escribiryborrar("Ingrese una opcion valida!", 15);
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
                pantallaDialogos.escribiryborrar("No tenes suficiente energia", 15);
                Thread.Sleep(1000);
                Console.Clear();
            }
        } while (bandera != 1);
        Combate.realizarAtaque(ataquesAux[int.Parse(tecla.ToString())], jugador, niveles[i], i + 1);
        hitAudio.CurrentTime = TimeSpan.FromSeconds(0);
        playHitSound.Play();
        Thread.Sleep(1000);
        Escribir.borrar(35, 11, 105);
        pantallaDialogos.mostrarVidaBoss(niveles[i]);
        Escribir.borrar(21, 17, 45);
        Console.SetCursorPosition(45, 17);
        Console.Write(niveles[i].Nombre + " te atacará");
        if (niveles[i].Salud > 0)
        {
            Combate.recibirAtaque(jugador, niveles[i], i + 1);
            hitAudio.CurrentTime = TimeSpan.FromSeconds(0);
            playHitSound.Play();
            Thread.Sleep(1000);
        }

    } while (niveles[i].Salud > 0 && jugador.Vidas != 0);
    Console.Clear();
    playBattleMusic.Stop();
    pantallaDialogos.escribiryborrar("Nivel superado :)", 15);
}




static async Task<NombresGenerados> obtenerNombres()
{
    var url = "https://randomuser.me/api/?results=10&nat=es&inc=name,dob";
    try
    {
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        var nombres = JsonSerializer.Deserialize<NombresGenerados>(responseBody);
        return nombres;
    }
    catch (HttpRequestException e)
    {
        Console.WriteLine("Problemas de acceso a la API");
        Console.WriteLine("Message :{0} ", e.Message);
        return null;
    }

}