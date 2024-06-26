
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using Personajes;

public class FabricaDePersonajes
{
    private static readonly string[] nombres = {
            "Juan", "María", "Pedro", "Ana", "Luis", "Sofía", "Carlos",
            "Laura", "Miguel", "Valentina", "Diego", "Isabella", "Javier",
            "Camila", "Alejandro", "Valeria", "José", "Emma", "Andrés", "Lucía"
        };
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
    public static int[] indicesAleatorios()
    {
        var random = new Random();
        int[] indices = new int[10];
        List<int> numerosDisponibles = new List<int>();
        for (int i = 0; i < 10; i++)
        {
            numerosDisponibles.Add(i);
        }

        for (int i = 0; i < 10; i++)
        {
            int index = random.Next(numerosDisponibles.Count);
            indices[i] = numerosDisponibles[index];
            numerosDisponibles.RemoveAt(index);
        }

        return indices;
    }
    public static List<JefeCatedra> crearBosses()
    {
        List<JefeCatedra> niveles = new List<JefeCatedra>();
        int[] indices = indicesAleatorios();

        for (int i = 0; i < 10; i++)
        {
            string nombre = nombres[numeroAleatorio(0, 20)];
            int edad = numeroAleatorio(25, 71);
            Materia materia = materias[indices[i]];
            int energia = 0;
            int salud = numeroAleatorio(100, 301);
            niveles.Add(new JefeCatedra(nombre, edad, materia, energia, salud));
        }
        return niveles;
    }
    public static Estudiante crearEstudiante(DatosEstudiante datosLeidos){
        DatosEstudiante datosJugador = datosLeidos;
        int estres = 0;
        int motivacion = 100;
        int conocimiento = numeroAleatorio(0,31);
        int energia = 100;
        int salud = 100;
        int vidas  = 3;
        return new Estudiante(datosJugador,estres,motivacion,conocimiento,energia,salud,vidas);
    }
}