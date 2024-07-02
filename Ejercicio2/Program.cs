List<string> Apellidos = new List<string>();    

while (true)
{
    Console.WriteLine("Ingresa un apellido:");
    string apellido = Console.ReadLine()!.ToLower();
    if (string.IsNullOrEmpty(apellido))
    {
        break;
    }
    Apellidos.Add(apellido);
}

Console.WriteLine("Ingresa un apellido a eliminar:");

string apellidoAEliminar = Console.ReadLine()!.ToLower();

if(EliminarApellido(apellidoAEliminar, Apellidos))
    Console.WriteLine($"El apellido {apellidoAEliminar} se elimino correctamente");
else
    Console.WriteLine($"El apellido {apellidoAEliminar} no se encuentra en la lista");



bool EliminarApellido(string apellido, List<string> listaApellidos)
{
    return listaApellidos.Remove(apellido);
}