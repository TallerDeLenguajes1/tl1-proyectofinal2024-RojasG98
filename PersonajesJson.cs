

using System.Runtime.CompilerServices;
using Personajes;
using System.Text.Json;

public class PersonajesJson{
    public void GuardarJefes(List<JefeCatedra> jefes,string nombreArchivo){
        string jsonJefes = JsonSerializer.Serialize(jefes);
        File.WriteAllText(nombreArchivo, jsonJefes);
    }
    public void GuardarJugador(Estudiante jugador,string nombreArchivo){
        string jsonJugador = JsonSerializer.Serialize(jugador);
        File.WriteAllText(nombreArchivo, jsonJugador);
    }
    public List<JefeCatedra> LeerJefes(string nombreArchivo){
        if (!Existe(nombreArchivo))
        {
            throw new FileNotFoundException($"ERROR: {nombreArchivo} no existe o está vacío.");
        }

        string jsonString = File.ReadAllText(nombreArchivo);
        return JsonSerializer.Deserialize<List<JefeCatedra>>(jsonString);
    }
    public Estudiante LeerJugador(string nombreArchivo){
        if (!Existe(nombreArchivo))
        {
                throw new FileNotFoundException($"ERROR: {nombreArchivo} no existe o está vacío.");
        }

        string jsonString = File.ReadAllText(nombreArchivo);
        return JsonSerializer.Deserialize<Estudiante>(jsonString);
    }
    public bool Existe(string nombreArchivo){
        return File.Exists(nombreArchivo) && new FileInfo(nombreArchivo).Length > 0;
    }
}

public class HistorialJson{
    public void GuardarGanador(Estudiante ganador,infoPartida informacion,string nombreArchivo){
        List<Ganadores> historial = new List<Ganadores>();

        if (Existe(nombreArchivo))
        {
            historial = LeerGanadores(nombreArchivo);
        }

        Ganadores nuevaEntrada = new Ganadores(ganador, informacion, DateTime.Now);

        historial.Add(nuevaEntrada);

        string jsonHistorial = JsonSerializer.Serialize(historial);
        File.WriteAllText(nombreArchivo, jsonHistorial);
    }
    public List<Ganadores> LeerGanadores(string nombreArchivo){
        if (!Existe(nombreArchivo))
        {
            throw new FileNotFoundException($"El archivo {nombreArchivo} no existe o está vacío.");
        }

        string jsonString = File.ReadAllText(nombreArchivo);
        return JsonSerializer.Deserialize<List<Ganadores>>(jsonString);
    }
    public bool Existe(string nombreArchivo){
        return File.Exists(nombreArchivo) && new FileInfo(nombreArchivo).Length > 0;
    }
}

public class Ganadores{
    private Estudiante ganador;
    private infoPartida informacion;
    private DateTime fecha;

    public Ganadores(Estudiante ganador, infoPartida informacion,DateTime fecha)
    {
        this.Ganador = ganador;
        this.Informacion = informacion;
        this.Fecha = fecha;
    }

    public Estudiante Ganador { get => ganador; set => ganador = value; }
    public infoPartida Informacion { get => informacion; set => informacion = value; }
    public DateTime Fecha { get => fecha; set => fecha = value; }
}