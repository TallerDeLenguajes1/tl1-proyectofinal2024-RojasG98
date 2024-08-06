
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using Pantallas;
using Personajes;

public class FabricaDePersonajes
{
//creo un arreglo de clase materia que contiene el nombre de la materia, su ultimate y su dialogo inicial
private static readonly Materia[] materias = new[] {
    new Materia(
        "Cálculo",
        "Derivada Mortal",
        new string[] {
            "Bienvenido a Cálculo, donde las derivadas y las integrales reinan supremas.",
            "Prepárate para enfrentar la Derivada Mortal y demostrar tu dominio sobre el infinito.",
            "¡Buena suerte, estudiante!"
        }
    ),
    new Materia(
        "Física",
        "Campo Electromagnético",
        new string[] {
            "Bienvenido al fascinante mundo de la Física.",
            "Aquí, los campos electromagnéticos te desafiarán a cada paso.",
            "¿Estás listo para enfrentarlos? ¡Vamos, que la fuerza esté contigo!"
        }
    ),
    new Materia(
        "Química",
        "Reacción Explosiva",
        new string[] {
            "Bienvenido al laboratorio de Química.",
            "Las reacciones aquí pueden ser impredecibles y peligrosas.",
            "Ten cuidado con la Reacción Explosiva y mezcla con sabiduría. ¡Buena suerte!"
        }
    ),
    new Materia(
        "Dibujo Técnico",
        "Trazo Perfecto",
        new string[] {
            "Bienvenido a Dibujo Técnico.",
            "La precisión es clave para superar los retos que se presentan en el papel.",
            "Un Trazo Perfecto será tu mejor aliado. ¡A dibujar se ha dicho!"
        }
    ),
    new Materia(
        "Álgebra",
        "Número Complejo",
        new string[] {
            "Bienvenido a Álgebra, el reino de los números complejos y las ecuaciones.",
            "Enfrentar al Número Complejo será tu desafío.",
            "¡Que tus cálculos sean exactos!"
        }
    ),
    new Materia(
        "Algoritmos",
        "Recursión Infinita",
        new string[] {
            "Bienvenido a la clase de Algoritmos, donde la lógica y la recursión son tu pan de cada día.",
            "Maneja la Recursión Infinita con destreza y sal victorioso.",
            "¡A programar se ha dicho!"
        }
    ),
    new Materia(
        "Laboratorio de Software",
        "CSS Maldito",
        new string[] {
            "Bienvenido al Laboratorio de Software.",
            "Aquí, el CSS Maldito será tu némesis en el desarrollo web.",
            "Mantén la calma y el código limpio. ¡Buena suerte!"
        }
    ),
    new Materia(
        "Taller de Lenguaje",
        "Tormenta de Punteros",
        new string[] {
            "Bienvenido al Taller de Lenguaje.",
            "Los punteros tienen un poder especial aquí.",
            "Enfrenta la Tormenta de Punteros con valor. ¡Adelante, estudiante!"
        }
    ),
    new Materia(
        "Elementos de Lógica",
        "Tabla de Verdad",
        new string[] {
            "Bienvenido a Elementos de Lógica.",
            "Las tablas de verdad y los circuitos lógicos te pondrán a prueba.",
            "Desentraña la Tabla de Verdad y triunfa. ¡Buena suerte!"
        }
    ),
    new Materia(
        "Programación",
        "Pérdida de Referencia",
        new string[] {
            "Bienvenido al mundo de la Programación.",
            "Aquí, una Pérdida de Referencia puede ser fatal.",
            "Mantén tu programa funcionando sin errores y demuestra tu habilidad. ¡Vamos, a programar!"
        }
    )
};

    //funcion para obtener numero aleatorio
    public static int numeroAleatorio(int min, int max)
    {
        var random = new Random();
        int value = random.Next(min, max);
        return value;
    }
    //creo un arreglo con indices aleatorios para poder crear los niveles con una materia en especifico;
    public static int[] indicesAleatorios(int cantNumeros,int totalOpciones)
    {
        var random = new Random();
        //creo un arreglo de int de tamaño de la cantidad de indices aleatorios quiero
        int[] indices = new int[cantNumeros];
        // creo una lista con los numeros disponibles
        List<int> numerosDisponibles = new List<int>();
        //agrego a esa lista numeros del 1 al numero las opciones de indice que tengo por ejemplo solo 4 opciones elegibles
        for (int i = 0; i < totalOpciones; i++)
        {
            numerosDisponibles.Add(i);
        }
        //obtengo un valor aleatorio de la lista y luego lo borro para no repetir
        for (int i = 0; i < cantNumeros; i++)
        {
            int index = random.Next(numerosDisponibles.Count);
            indices[i] = numerosDisponibles[index];
            numerosDisponibles.RemoveAt(index);
        }

        return indices;
    }
    public static List<JefeCatedra> crearBosses(NombresGenerados nombresApi)
    {
        List<JefeCatedra> niveles = new List<JefeCatedra>();
        int[] indices = indicesAleatorios(10,10);
        Result[] aux = nombresApi.Results.ToArray();
        int maximo = 31;
        int minimo = 20;
        for (int i = 0; i < 10; i++)
        {
            string nombre = aux[i].Name.First;
            int edad = aux[i].Dob.Age;
            Materia materia = materias[indices[i]];
            int salud = numeroAleatorio(minimo, maximo);
            niveles.Add(new JefeCatedra(nombre, edad, materia, salud));
            minimo += 10;
            maximo += 10;
        }
        return niveles;
    }
    public static Estudiante crearEstudiante(DatosEstudiante datosLeidos){
        DatosEstudiante datosJugador = datosLeidos;
        int estres = 0;
        int conocimiento = numeroAleatorio(0,31);
        int energia = 100;
        int salud = 100;
        int vidas  = 2;
        return new Estudiante(datosJugador,estres,conocimiento,energia,salud,vidas);
    }

    public static Estudiante leerDatosJugador(){
            Estudiante jugador;
            DatosEstudiante datosLeidos;
            string nombre;
            int respuesta, edad;
            bool esNumeroValido;
            char tecla;
            do
            {
                Console.Clear();
                Escribir.escribir("Ingrese Su nombre: ",10);
                nombre = Console.ReadLine();
                do
                {
                    Escribir.escribir("Ingrese su edad: ",13);
                    esNumeroValido = Int32.TryParse(Console.ReadLine(), out edad);

                    if (!esNumeroValido)
                    {
                        Console.WriteLine("Por favor, ingrese un número válido.");
                    }
                } while (!esNumeroValido);
                Console.Clear();
                Escribir.escribir("Esta seguro que estos son sus datos?",10);
                Escribir.escribir("Nombre: " + nombre,11);
                Escribir.escribir("Edad: " + edad,12);
                Escribir.escribir("0.SI    1.NO",13);
                do
                {
                    tecla = Console.ReadKey(intercept: true).KeyChar;
                    switch (tecla)
                    {
                        case '0':
                            esNumeroValido = true;
                            respuesta = 0;
                            break;
                        case '1':
                            esNumeroValido = true;
                            respuesta = 1;
                            Escribir.escribiryborrarCentrado("VOLVIENDO AL INGRESO DE DATOS...",14);
                            break;
                        default:
                            Escribir.escribiryborrarCentrado("INGRESE NUMERO VALIDO",14);
                            esNumeroValido = false;
                            respuesta = 1;
                            break;
                    }
                } while (!esNumeroValido);
            } while (respuesta == 1);
            datosLeidos = new DatosEstudiante(nombre, edad);
            jugador = FabricaDePersonajes.crearEstudiante(datosLeidos);
            return jugador;
    }

}