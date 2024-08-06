
using Personajes;
using Pantallas;
using System;
using System.Reflection.PortableExecutable;
using NAudio.Wave;
using System.Net.WebSockets;
using System.Text.Json;
using System.Globalization;
using System.Text.Json.Nodes;
using System.Runtime.InteropServices;


//creamos una ventana de consola con el tamaño que deseamos para el juego
Ventana ventana = new Ventana(150, 30);
Console.Clear();
//creo las variables para el historial
int danioRealizado = 0;
int cantGolpesCriticos = 0;
int danioRecibido = 0;
int nivelesSuperados = 0;
char tecla;
int bandera;
//inicializacion de objetos personaje, jefes y direcciones de los json
var archivos = new PersonajesJson();
var archivoHistorial = new HistorialJson();
string rutaJefes = "./json/jefes.json";
string rutaJugador = "./json/jugador.json";
string rutaHistorial = "./json/historial.json";
Estudiante jugador = null;
List<JefeCatedra> jefes = null;
//creamos el objeto reproductor y el objeto que contiene la cancion de menu
var menuMusic = new AudioFileReader(@"C:\Users\rojas\TallerLenguaje1\tl1-proyectofinal2024-RojasG98\audio\menuMusic.wav");
var playMenuMusic = new WaveOutEvent();

//creamos el objeto reproductor y el objeto que contiene la cancion cuando se selecciona una opcion
var selectSound = new AudioFileReader(@"C:\Users\rojas\TallerLenguaje1\tl1-proyectofinal2024-RojasG98\audio\selectionSound.wav");
var playSelectSound = new WaveOutEvent();
//dentro de este while esta todo el menu para poder volver en caso de entrar a los records
bool salir = false;
while (!salir)
{
    bandera = 0;
    //iniciamos el reproductor con la cancion
    playMenuMusic.Init(menuMusic);
    //play en la musica
    playMenuMusic.Play();


    //creamos un lazo do while para volver a pedir una tecla hasta que sea la valida
    do
    {
        //muestro el menu
        Console.Clear();
        pantallaPrincipal.mostrarMenu();
        tecla = Console.ReadKey().KeyChar;
        Console.Clear();
        if (tecla == '1' || tecla == '2' || tecla == '3' || tecla == '4')
        {
            playSelectSound.Init(selectSound);
            //este metodo hace que la musica comience desde 0
            selectSound.CurrentTime = TimeSpan.FromSeconds(0);
            playSelectSound.Play();
            //bandera = 1 para salir del bucle ya que se selecciono una opcion valida
            bandera = 1;
            playMenuMusic.Stop();
            //metodo para cerrar el reproductor
            playMenuMusic.Dispose();
            Thread.Sleep(500);
        }
        else
        {
            Console.Clear();
            Console.SetCursorPosition(62, 15); // Establecer la posición del cursor en el medio
            Console.WriteLine("Ingrese una opcion valida!");
            Thread.Sleep(2000);//2 segundos para continuar con la ejecucion
        }
    } while (bandera != 1);

    switch (tecla)
    {
        case '1':
            //verificacmos si no existen los archivos json
            //en caso de existir los borramos y creamos uno nuevo
            if (!archivos.Existe(rutaJefes) && !archivos.Existe(rutaJugador))
            {
                NombresGenerados nombresBosses = await obtenerNombres();
                jefes = FabricaDePersonajes.crearBosses(nombresBosses);
                archivos.GuardarJefes(jefes, rutaJefes);
                jugador = FabricaDePersonajes.leerDatosJugador();
                archivos.GuardarJugador(jugador, rutaJugador);
            }
            else
            {
                try
                {
                    File.Delete(rutaJugador);
                    File.Delete(rutaJefes);
                    //Volvemos a crear los bosses y pedimos datos nuevamente
                    NombresGenerados nombresBosses = await obtenerNombres();
                    jefes = FabricaDePersonajes.crearBosses(nombresBosses);
                    archivos.GuardarJefes(jefes, rutaJefes);
                    jugador = FabricaDePersonajes.leerDatosJugador();
                    archivos.GuardarJugador(jugador, rutaJugador);
                }
                catch (Exception error)
                {
                    Console.WriteLine($"Error al crear nueva partida{error.Message}");
                }
            }
            salir = true;
            break;
        case '2':
            //en esta opcion leemos los json ya guardados
            if (archivos.Existe(rutaJefes) && archivos.Existe(rutaJugador))
            {
                jefes = archivos.LeerJefes(rutaJefes);
                jugador = archivos.LeerJugador(rutaJugador);
            }
            else
            {
                //no existen los archivos damos error y cerramos la consola
                Console.SetCursorPosition(58, 15); // Establecer la posición del cursor en el medio
                Console.WriteLine("ERROR no hay una partida guardada");
                Thread.Sleep(2000);
                Environment.Exit(0);

            }
            salir = true;
            break;
        case '3':
            //leemos el json de historial
            var historial = archivoHistorial.LeerGanadores(rutaHistorial);
            var aux = historial.ToArray();
            int altura = 0;
            for (int i = 0; i < aux.Length; i++)
            {
                DateTime dateTime = aux[i].Fecha;
                Escribir.escribir("Nombre: " + aux[i].Nombre, altura);
                Escribir.escribir("Daño Realizado: " + aux[i].Informacion.DanioRealizado, altura + 1);
                Escribir.escribir("Daño Recibido: " + aux[i].Informacion.DanioRecibido, altura + 2);
                Escribir.escribir("Golpes Criticos Realizados: " + aux[i].Informacion.CantCriticosRealizados, altura + 3);
                Escribir.escribir("Fecha:" + dateTime.ToString("dd '/' MM '/' yy", CultureInfo.CreateSpecificCulture("es-AR")), altura + 4);
                altura += 7;
            }
            Escribir.centrarCadena("Presiona Cualquier tecla para salir",altura);
            Console.ReadKey(intercept: true);//intercept: true hace que no se vea lo si presiono la tecla
            break;
        case '4':
            //cerramos la consola
            Environment.Exit(0);
            break;
    }
}
var prologueMusic = new AudioFileReader(@"C:\Users\rojas\TallerLenguaje1\tl1-proyectofinal2024-RojasG98\audio\prologue.wav");
var playPrologueMusic = new WaveOutEvent();
var cinematicMusic = new AudioFileReader(@"C:\Users\rojas\TallerLenguaje1\tl1-proyectofinal2024-RojasG98\audio\cinematicMusic.wav");
var playCinematicMusic = new WaveOutEvent();
Console.Clear();
if (jugador != null)
{
    playPrologueMusic.Init(prologueMusic);
    playPrologueMusic.Play();

    pantallaDialogos.mostrarDialogos1(jugador);
    playPrologueMusic.Stop();
    playPrologueMusic.Dispose();


    playCinematicMusic.Init(cinematicMusic);
    playCinematicMusic.Play();
    pantallaDialogos.presentarNiveles(jefes);
    playCinematicMusic.Stop();
    playCinematicMusic.Dispose();
}
//creamos un arreglo auxiliar para poder recorrer los niveles
JefeCatedra[] niveles = jefes.ToArray();
//inicializamos la bandera en 0
bandera = 0;
var hitAudio = new AudioFileReader(@"C:\Users\rojas\TallerLenguaje1\tl1-proyectofinal2024-RojasG98\audio\hitSound.wav");
var playHitSound = new WaveOutEvent();
playHitSound.Init(hitAudio);

// recorreremos los niveles en orden
for (int i = 0; i < 10; i++)
{
    var battleMusic = new AudioFileReader(@"C:\Users\rojas\TallerLenguaje1\tl1-proyectofinal2024-RojasG98\audio\BattleMusic.wav");
    var playBattleMusic = new WaveOutEvent();
    bool esBienvenida = true;
    playBattleMusic.Init(battleMusic);
    battleMusic.CurrentTime = TimeSpan.FromSeconds(0);
    playBattleMusic.Play();
    int nroNivel = i + 1;
    Escribir.escribiryborrarCentrado("NIVEL " + nroNivel, 15);
    Thread.Sleep(1000);
    Console.Clear();
    do
    {
        List<Ataques> ataques = Combate.ataquesDelTurno(jugador);
        Ataques[] ataquesAux = ataques.ToArray();
        // si no tienes suficiente energia para atacar pierdes una vida
        bool tieneEnergia = true;
        for (int j = 0; j < ataquesAux.Length; j++)
        {
            if (ataquesAux[j].CostoEnergía > jugador.Energia)
            {
                tieneEnergia = false;
            }
        }
        if (!tieneEnergia)
        {
            pantallaDialogos.mostrarAtaques(jugador, ataques);
            pantallaDialogos.mostrarStatsJugador(jugador, nroNivel, niveles[i].Materia.Nombre);
            pantallaDialogos.mostrarVidaBoss(niveles[i]);
            Escribir.escribiryborrarCentrado("No tienes energia suficiente para atacar", 14);
            Escribir.escribiryborrarCentrado("Pierdes una vida!", 14);
            jugador.Vidas--;
        }
        else
        {
            do
            {
                //mostramos pantalla de combate y las estadisticas
                pantallaDialogos.mostrarAtaques(jugador, ataques);
                if (esBienvenida)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Escribir.escribiryborrarCentrado(niveles[i].Materia.DialogoBienvenida[j], 2);
                    }
                    esBienvenida = false;
                }



                pantallaDialogos.mostrarStatsJugador(jugador, nroNivel, niveles[i].Materia.Nombre);
                pantallaDialogos.mostrarVidaBoss(niveles[i]);

                //pedimos una opcion hasta que ingrese una valida
                do
                {
                    Escribir.escribir("Elige un ataque", 14);
                    Console.SetCursorPosition(0, 0);
                    tecla = Console.ReadKey(intercept: true).KeyChar;
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
                        Console.SetCursorPosition(60, 14); // Establecer la posición del cursor para el mensaje
                        Escribir.escribiryborrarCentrado("Ingrese una opcion valida!", 14);
                        bandera = 0;
                        Thread.Sleep(1000);
                    }
                } while (bandera != 1);
                bandera = 0;
                //verificamos que la energia es sificiente para realizar el ataque
                if (jugador.Energia >= ataquesAux[int.Parse(tecla.ToString())].CostoEnergía)
                {
                    bandera = 1;
                }
                else
                {
                    Escribir.escribiryborrarCentrado("No tenes suficiente energia", 14);
                    Console.Clear();
                }
            } while (bandera != 1);
            //Invocamos al metodo realizar ataque
            Combate.realizarAtaque(ataquesAux[int.Parse(tecla.ToString())], jugador, niveles[i], jugador.Conocimiento, ref danioRealizado, ref cantGolpesCriticos);
            //reproducimos sonido de golpe
            hitAudio.CurrentTime = TimeSpan.FromSeconds(0);
            playHitSound.Play();
            Thread.Sleep(1000);
            // si nuestra energia queda en 0 perdemos una vida
            if (jugador.Energia == 0)
            {
                jugador.Vidas--;
                jugador.Energia = 100;
            }
            //borramos la barra de vida del boss y escribimos la actualizada
            Console.Clear();
            pantallaDialogos.mostrarAtaques(jugador, ataques);
            pantallaDialogos.mostrarStatsJugador(jugador, nroNivel, niveles[i].Materia.Nombre);
            pantallaDialogos.mostrarVidaBoss(niveles[i]);
            //revisamos que el boss este vivo en caso afirmativo procede a atacar
            if (niveles[i].Salud > 0)
            {

                Escribir.escribir(niveles[i].Nombre + " te Atacará", 14);
                Combate.recibirAtaque(jugador, niveles[i], i + 1, ref danioRecibido);
                hitAudio.CurrentTime = TimeSpan.FromSeconds(0);
                playHitSound.Play();
                Thread.Sleep(1000);
            }
        }
        // si el boss no tiene vida o el jugador perdio todas sus vidas salimos del bucle
    } while (niveles[i].Salud > 0 && jugador.Vidas != 0);
    Console.Clear();
    playBattleMusic.Stop();
    if (jugador.Vidas == 0)
    {
        var gameOverMusic = new AudioFileReader(@"C:\Users\rojas\TallerLenguaje1\tl1-proyectofinal2024-RojasG98\audio\GameOver.wav");
        var playgameOverMusic = new WaveOutEvent();
        //volver al menu principal
        playgameOverMusic.Init(gameOverMusic);
        playgameOverMusic.Play();
        pantallaDialogos.gameOver();
        Thread.Sleep(8000);
        playgameOverMusic.Stop();
        playgameOverMusic.Dispose();
        break;
    }
    else
    {
        if (niveles[i].Salud == 0)
        {
            var victoryMusic = new AudioFileReader(@"C:\Users\rojas\TallerLenguaje1\tl1-proyectofinal2024-RojasG98\audio\levelComplete.wav");
            var playvictoryMusic = new WaveOutEvent();
            playvictoryMusic.Init(victoryMusic);
            playvictoryMusic.Play();
            Escribir.escribiryborrarCentrado("Nivel superado", 15);
            Thread.Sleep(1000);
            //finalizado el nivel el jugador aumenta su nivel de conomiento
            int conocimiento = FabricaDePersonajes.numeroAleatorio(0, 10);
            if (jugador.Conocimiento + conocimiento > 100)
            {
                jugador.Conocimiento = 100;
            }
            else
            {
                jugador.Conocimiento += conocimiento;
            }
            Escribir.escribiryborrarCentrado("Ahora eres mas sabio tu conomiento es de : " + jugador.Conocimiento, 15);
            //reiniciamos a 50 la energia, a 0 el estres y 3 vidas
            jugador.Salud = 100;
            jugador.Energia = 100;
            jugador.Estres = 0;
            jugador.Vidas = 2;
            //cuento el nivel superado
            nivelesSuperados++;
            playvictoryMusic.Stop();
            playvictoryMusic.Dispose();
        }
    }
}

if (nivelesSuperados == 10)
{
    var estadisticas = new infoPartida(danioRealizado, danioRecibido, cantGolpesCriticos);
    archivoHistorial.GuardarGanador(jugador.Datos.Nombre, estadisticas, rutaHistorial);
    pantallaDialogos.pantallaGanador();
}




static async Task<NombresGenerados> obtenerNombres()
{
    //Obtengo los nombres para los bosses de la api
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
        //si no puedo leer de la api uso el archivo json backup
        Console.WriteLine("Problemas de conexion. Obteniendo nombres offline");
        Thread.Sleep(1500);
        Console.WriteLine("Message :{0} ", e.Message);
        try
        {
            string json = await File.ReadAllTextAsync("json/nombresOffline.json");
            var nombresOffline = JsonSerializer.Deserialize<NombresGenerados>(json);
            return nombresOffline;
        }
        catch (Exception fileEx)
        {
            Console.WriteLine("Problemas al leer el archivo local");
            Console.WriteLine("Message :{0} ", fileEx.Message);
            return null;
        }
    }

}