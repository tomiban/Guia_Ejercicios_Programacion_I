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

Console.WriteLine("Ingresa un apellido a buscar:");

string apellidoABuscar = Console.ReadLine()!.ToLower();

BuscarIndiceApellido(apellidoABuscar);
BuscarIndicesApellido(apellidoABuscar);

 void BuscarIndicesApellido(string apellido)
{
   HashSet<int> indices = new HashSet<int>();
   for(int i = 0; i < Apellidos.Count; i++)
   {
       if(Apellidos[i] == apellido)
       {
           indices.Add(i);
       }
   }
    if(indices.Count > 0)
        Console.WriteLine($"El apellido {apellido} se encuentran en los indices {string.Join("- ", indices)}");
    else
        Console.WriteLine($"El apellido {apellido} no se encuentra en la lista");
}

void BuscarIndiceApellido(string apellido)
{
    int indice = -1;
    for(int i = 0 ; i < Apellidos.Count; i++)
    {
        if (Apellidos[i] == apellido )
        {
            indice = i;
            break;
        }
    }

    if(indice > -1)
        Console.WriteLine($"El apellido {apellido} se encuentra en el indice {indice}");
    else
        Console.WriteLine($"El apellido {apellido} no se encuentra en la lista");
}