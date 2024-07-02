
Persona p1 = new Persona("Juan", 25);
Persona p2 = new Persona("Pedro", 30);

if(p1 > p2)
{
    Console.WriteLine($"{p1.Nombre} es mayor que {p2.Nombre}");
} else 
{
    Console.WriteLine($"{p2.Nombre} es mayor que {p1.Nombre}");
}


Persona p3 = p1 + 5;

Console.WriteLine($"{p3.Edad}");

class Persona
{
    public string Nombre { get; set; }
    public int Edad { get; set; }

    public Persona(string nombre, int edad)
    {
        Nombre = nombre;
        Edad = edad;
    }

    public static bool operator <(Persona a, Persona b)
    {
        return a.Edad < b.Edad;
    }

    public static bool operator >(Persona a, Persona b)
    {
        return a.Edad > b.Edad;
    }

    public static Persona operator +(Persona a, int años)
    {

        return new Persona(a.Nombre, a.Edad + años);
    }
}
