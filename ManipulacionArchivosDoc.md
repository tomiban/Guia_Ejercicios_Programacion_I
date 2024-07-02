### Documentación para Manipulación de Archivos Binarios y de Texto en C#

### Manipulación de Archivos de Texto

#### Crear y Escribir en un Archivo de Texto

Para crear y escribir en un archivo de texto, puedes usar `FileStream` junto con `StreamWriter`.

```csharp
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "example.txt";

        // Crear y escribir en el archivo de texto usando FileStream y StreamWriter
        using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        using (StreamWriter writer = new StreamWriter(fs))
        {
            writer.WriteLine("Hola, este es un archivo de texto.");
            writer.WriteLine("C# es un lenguaje poderoso.");
        }

        Console.WriteLine("Archivo de texto creado y escrito exitosamente.");
    }
}
```

#### Leer desde un Archivo de Texto

Para leer desde un archivo de texto, puedes usar `FileStream` junto con `StreamReader`.

```csharp
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "example.txt";

        // Leer desde el archivo de texto usando FileStream y StreamReader
        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        using (StreamReader reader = new StreamReader(fs))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}
```

### Manipulación de Archivos Binarios

#### Crear y Escribir en un Archivo Binario

Para crear y escribir en un archivo binario, puedes usar `FileStream` junto con `BinaryWriter`.

```csharp
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "example.bin";

        // Crear y escribir en el archivo binario usando FileStream y BinaryWriter
        using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        using (BinaryWriter writer = new BinaryWriter(fs))
        {
            writer.Write(42);          // Escribir un entero
            writer.Write(3.14);        // Escribir un doble
            writer.Write("Hola");      // Escribir una cadena
        }

        Console.WriteLine("Archivo binario creado y escrito exitosamente.");
    }
}
```

#### Leer desde un Archivo Binario

Para leer desde un archivo binario, puedes usar `FileStream` junto con `BinaryReader`.

```csharp
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "example.bin";

        // Leer desde el archivo binario usando FileStream y BinaryReader
        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        using (BinaryReader reader = new BinaryReader(fs))
        {
            int intValue = reader.ReadInt32();
            double doubleValue = reader.ReadDouble();
            string stringValue = reader.ReadString();

            Console.WriteLine($"Int: {intValue}, Double: {doubleValue}, String: {stringValue}");
        }
    }
}
```

### Consideraciones Adicionales

#### Control de Acceso y Modo de Apertura

Al trabajar con `FileStream`, puedes especificar el modo de apertura y el tipo de acceso al archivo mediante los enumeradores `FileMode` y `FileAccess`:

- `FileMode.Create`: Crea un nuevo archivo. Si el archivo ya existe, se sobrescribirá.
- `FileMode.Open`: Abre un archivo existente. Si el archivo no existe, se lanzará una excepción.
- `FileMode.Append`: Abre un archivo existente para escritura y añade datos al final.
- `FileAccess.Read`: Proporciona acceso de solo lectura al archivo.
- `FileAccess.Write`: Proporciona acceso de solo escritura al archivo.
- `FileAccess.ReadWrite`: Proporciona acceso tanto de lectura como de escritura al archivo.


```csharp
using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096))
```

#### Operaciones Asíncronas

Para mejorar la eficiencia y la capacidad de respuesta de las aplicaciones, `FileStream` soporta operaciones asíncronas:

```csharp
using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true))
{
    byte[] buffer = new byte[fs.Length];
    int bytesRead = await fs.ReadAsync(buffer, 0, buffer.Length);
    Console.WriteLine($"Leídos {bytesRead} bytes del archivo.");
}
```

Claro, aquí tienes las funciones mejoradas para la lectura y escritura con `MemoryPack`, incorporando manejo de excepciones (`try-catch`) y soporte para operaciones asíncronas.

### Serialización Asíncrona con Manejo de Excepciones

#### Serializar una Estructura a un Archivo Binario

```csharp
using System;
using System.IO;
using System.Threading.Tasks;
using MemoryPack;

class Program
{
    static async Task SerializarAArchivoAsync<T>(string path, T objeto)
    {
        try
        {
            // Serializamos el objeto a un array de bytes
            var data = MemoryPackSerializer.Serialize(objeto);

            // Escribimos los bytes en el archivo usando FileStream
            using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true))
            {
                await fileStream.WriteAsync(data, 0, data.Length);
            }

            Console.WriteLine("Objeto serializado y escrito en el archivo exitosamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al escribir el archivo: {ex.Message}");
        }
    }

    static async Task Main()
    {
        var producto = new Producto("Manzana", 1.5, 10);
        await SerializarAArchivoAsync("producto.bin", producto);
    }
}
```

#### Deserializar una Estructura desde un Archivo Binario

```csharp
using System;
using System.IO;
using System.Threading.Tasks;
using MemoryPack;

class Program
{
    static async Task<T> DeserializarDeArchivoAsync<T>(string path)
    {
        try
        {
            // Leemos el contenido del archivo en un array de bytes
            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true))
            {
                var data = new byte[fileStream.Length];
                await fileStream.ReadAsync(data, 0, data.Length);

                // Deserializamos el contenido del array de bytes en un objeto del tipo especificado
                return MemoryPackSerializer.Deserialize<T>(data);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al leer el archivo: {ex.Message}");
            return default(T);
        }
    }

    static async Task Main()
    {
        var producto = await DeserializarDeArchivoAsync<Producto>("producto.bin");
        if (producto != null)
        {
            Console.WriteLine($"Nombre: {producto.Nombre}, Importe: {producto.Importe}, Cantidad: {producto.Cantidad}");
        }
    }
}
```
### Ejemplo Completo

```csharp
using System;
using System.IO;
using System.Threading.Tasks;
using MemoryPack;

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

class Program
{
    static async Task Main()
    {
        var producto = new Producto("Manzana", 1.5, 10);
        await SerializarAArchivoAsync("producto.bin", producto);

        var deserializedProducto = await DeserializarDeArchivoAsync<Producto>("producto.bin");
        if (deserializedProducto != null)
        {
            Console.WriteLine($"Nombre: {deserializedProducto.Nombre}, Importe: {deserializedProducto.Importe}, Cantidad: {deserializedProducto.Cantidad}");
        }
    }

    static async Task SerializarAArchivoAsync<T>(string path, T objeto)
    {
        try
        {
            var data = MemoryPackSerializer.Serialize(objeto);

            using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true))
            {
                await fileStream.WriteAsync(data, 0, data.Length);
            }

            Console.WriteLine("Objeto serializado y escrito en el archivo exitosamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al escribir el archivo: {ex.Message}");
        }
    }

    static async Task<T> DeserializarDeArchivoAsync<T>(string path)
    {
        try
        {
            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true))
            {
                var data = new byte[fileStream.Length];
                await fileStream.ReadAsync(data, 0, data.Length);

                return MemoryPackSerializer.Deserialize<T>(data);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al leer el archivo: {ex.Message}");
            return default(T);
        }
    }
}
```
