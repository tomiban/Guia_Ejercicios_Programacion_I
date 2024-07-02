using System;
using System.IO;

const string FILE = "numeros.bin";
GenerarArchivo(FILE);

Console.WriteLine("Ingresar un numero");
int numero = int.Parse(Console.ReadLine()!);

ActualizarArchivo(numero, FILE);
List<int> numeros = LeerArchivo(FILE);
Console.WriteLine(string.Join(",", numeros));

void GenerarArchivo(string fileName)
{
    using (var file = File.Create(fileName))
    {
        using (var writer = new BinaryWriter(file))
        {
            for (int i = 0; i < 100; i++)
            {
                writer.Write(i * 5);
            }
        }
    }
}

List<int> LeerArchivo(string fileName)
{
    List<int> numeros = new List<int>();
    using (var file = File.OpenRead(fileName))
    {
        using (var reader = new BinaryReader(file))
        {
            for (int i = 0; i < 100; i++)
            {
                numeros.Add(reader.ReadInt32());
            }
        }
    }
    return numeros;
}

void ActualizarArchivo(int numero, string fileName)
{
    var numeros = LeerArchivo(fileName);
    numeros.Add(numero);
    numeros.Sort();

    using (var file = File.OpenWrite(fileName))
    {
        using (var writer = new BinaryWriter(file))
        {
            for (int i = 0; i < 100; i++)
            {
                writer.Write(numeros[i]);
            }
        }
    }
}