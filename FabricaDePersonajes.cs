
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using Personajes;

public class FabricaDePersonajes
{
    //creo un arreglo de clase materia que contiene el nombre de la materia y su ultimate
    private static readonly Materia[] materias = new[] {new Materia("Calculo","Derivada Mortal"),
                                                        new Materia("Fisica","Campo Electromagnético"),
                                                        new Materia("Quimica","Reacción Explosiva"),
                                                        new Materia("Dibujo Tecnico","Trazo Perfecto"),
                                                        new Materia("Algebra","Número Complejo"),
                                                        new Materia("Algoritmos","Recursión Infinita"),
                                                        new Materia("Laboratario de Software","Bootstrap Colapso"),
                                                        new Materia("Taller de Lenguaje","Tormenta de Punteros"),
                                                        new Materia("Elementos de logica","Tabla de Verdad"),
                                                        new Materia("Programacion","Pérdida de Referencia")};

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
        int[] indices = new int[cantNumeros];
        List<int> numerosDisponibles = new List<int>();
        for (int i = 0; i < totalOpciones; i++)
        {
            numerosDisponibles.Add(i);
        }

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
        int maximo = 201;
        int minimo = 100;
        for (int i = 0; i < 10; i++)
        {
            string nombre = aux[i].Name.First;
            int edad = aux[i].Dob.Age;
            Materia materia = materias[indices[i]];
            int energia = 0;
            int salud = numeroAleatorio(minimo, maximo);
            niveles.Add(new JefeCatedra(nombre, edad, materia, energia, salud));
            minimo += 15;
            maximo += 15;
        }
        return niveles;
    }
    public static Estudiante crearEstudiante(DatosEstudiante datosLeidos){
        DatosEstudiante datosJugador = datosLeidos;
        int estres = 0;
        int motivacion = 100;
        int conocimiento = numeroAleatorio(0,31);
        int energia = 50;
        int salud = 100;
        int vidas  = 3;
        return new Estudiante(datosJugador,estres,motivacion,conocimiento,energia,salud,vidas);
    }

    public static Estudiante leerDatosJugador(){
            Estudiante jugador;
            DatosEstudiante datosLeidos;
            string nombre;
            int respuesta, edad;
            bool esNumeroValido;
            do
            {
                Console.Clear();
                Console.WriteLine("Ingrese Su nombre");
                nombre = Console.ReadLine();
                do
                {
                    Console.WriteLine("Ingrese su edad: ");
                    esNumeroValido = Int32.TryParse(Console.ReadLine(), out edad);

                    if (!esNumeroValido)
                    {
                        Console.WriteLine("Por favor, ingrese un número válido.");
                    }
                } while (!esNumeroValido);
                Console.Clear();
                Console.WriteLine("Esta seguro que estos son sus datos?");
                Console.WriteLine("Nombre: " + nombre);
                Console.WriteLine("Edad: " + edad);
                Console.WriteLine("0.SI    1.NO");
                do
                {
                    esNumeroValido = Int32.TryParse(Console.ReadLine(), out respuesta);
                } while (!esNumeroValido && respuesta > 1 && respuesta < 0);
            } while (respuesta == 1);
            datosLeidos = new DatosEstudiante(nombre, edad);
            jugador = FabricaDePersonajes.crearEstudiante(datosLeidos);
            return jugador;
    }

}