using MemoryPack;

using System.Collections.Generic;
using System.IO;
using MemoryPack;

var Frutas = new List<Producto>
{
    new Producto("Manzana", 1500, 4),
    new Producto("Pera", 1200, 5),
    new Producto("Banana", 2150, 7)
};

const string filePath = "Frutas.bin";
var serializedData = MemoryPackSerializer.Serialize(Frutas);

EscribirArchivo(filePath, serializedData);

var frutasDeserializada = LeerArchivo<List<Producto>>(filePath);

ImprimirReporte(frutasDeserializada);

LeerReporte("reporte.txt");



static void EscribirArchivo(string path, byte[] data)
{
    // Abrimos el archivo en modo creación, permitiendo escritura.
    using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
    {
        // Escribimos los datos en el archivo.
        // La posición de inicio es 0, y escribimos toda la cantidad de datos.
        fileStream.Write(data, 0, data.Length);
    }
}

static T LeerArchivo<T>(string path)
{
    // Abrimos el archivo en modo lectura
    using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
    {
        // Creamos un array de bytes del mismo tamaño que el archivo
        var data = new byte[fileStream.Length];

        // Leemos el contenido del archivo en el array de bytes
        fileStream.Read(data, 0, (int)fileStream.Length);

        // Deserializamos el contenido del array de bytes en un objeto del tipo especificado al momento de la invocacion
        return MemoryPackSerializer.Deserialize<T>(data);
    }
}

static void ImprimirReporte(List<Producto> Frutas)
{
    using (var writer = new StreamWriter("reporte.txt"))
    {
        writer.WriteLine("Reporte de frutas");
        writer.WriteLine("Nombre\tImporte\tCantidad");
        foreach (var fruit in Frutas)
        {
            writer.WriteLine($"{fruit.Nombre}\t{fruit.Importe}\t{fruit.Cantidad}");
        }
    }
}


void LeerReporte(string path)
{
    using (var reader = new StreamReader(path))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            Console.WriteLine(line);
        }
    }
}
[MemoryPackable]
public partial class Producto
{
    public Producto(string nombre, double importe, int cantidad)
    {
        Nombre = nombre;
        Importe = importe;
        Cantidad = cantidad;
    }
    public string Nombre { get; set; }
    public double Importe { get; set; }
    public int Cantidad { get; set; }
}
