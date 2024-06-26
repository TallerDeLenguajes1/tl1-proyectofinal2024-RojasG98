
using Personajes;
using Pantallas;
Ventana ventana = new Ventana(200,45,ConsoleColor.Blue);
Console.Clear();
pantallaPrincipal.mostrarMenu();
Console.WriteLine("Creando jefes de cátedra...");

        List<JefeCatedra> bosses = FabricaDePersonajes.crearBosses();

        Console.WriteLine("Lista de jefes de cátedra:");
        while (bosses.Count > 0)
        {
            JefeCatedra jefe = bosses[0];
            Console.WriteLine($"Nombre: {jefe.Nombre}, Edad: {jefe.Edad}, Materia: {jefe.Materia.Nombre}, ulti: {jefe.Materia.AtaqueEspecial} Energía: {jefe.Energia}, Salud: {jefe.Salud}");
            bosses.RemoveAt(0);
        }

Console.WriteLine("Creando estudiante...");
        DatosEstudiante datosLeidos;
        string nombre;
        int respuesta,edad;
        bool esNumeroValido;
        do
        {
            Console.WriteLine("Ingrese Su nombre");
            nombre = Console.ReadLine();
            Console.WriteLine("Ingrese Su nombre");
            do
            {
                Console.WriteLine("Ingrese su edad: ");
                esNumeroValido = Int32.TryParse(Console.ReadLine(), out edad);

                if (!esNumeroValido)
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                }
            } while (!esNumeroValido);

            Console.WriteLine("Esta seguro que estos son sus datos?");
            Console.WriteLine("Nombre: "+nombre);
            Console.WriteLine("Edad: "+edad);
            Console.WriteLine("0.SI    1.NO");
            do
            {
                esNumeroValido = Int32.TryParse(Console.ReadLine(),out respuesta);
            } while (!esNumeroValido && respuesta >1 && respuesta < 0);
        } while (respuesta == 1);
        datosLeidos = new DatosEstudiante(nombre,edad);

        Estudiante jugador = FabricaDePersonajes.crearEstudiante(datosLeidos);

        Console.WriteLine($"Nombre: {jugador.Datos.Nombre}\n Edad: {jugador.Datos.Edad}"); 
        Console.WriteLine($"Estres: {jugador.Estres}\n Motivacion: {jugador.Motivacion}\n Conocimiento: {jugador.Conocimiento}\n Energia: {jugador.Energia}\n Salud: {jugador.Salud} \n Vidas: {jugador.Vidas}");
        Console.WriteLine("Proceso completado.");