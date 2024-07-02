abstract class Vehiculo 
{
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int AñoSalida { get; set; }
       public int Cilindraje { get; set; }
    public int VelocidadMaxima { get; set; }

    abstract public void CalcularConsumo();
    
}


class Auto : Vehiculo
{

    public override void CalcularConsumo()
    {
        double consumo = (Cilindraje / 100) * VelocidadMaxima * 2;
        Console.WriteLine($"El consumo del auto es de {consumo} litros");
    }
}

class Moto : Vehiculo
{
    
    public override void CalcularConsumo()
    {
        double consumo = (Cilindraje / 100) * VelocidadMaxima;
        Console.WriteLine($"El consumo de la moto es de {consumo} litros");
    }
}

class Camion : Vehiculo
{
    public override void CalcularConsumo()
    {
        double consumo = (Cilindraje / 100) * VelocidadMaxima * 3;
        Console.WriteLine($"El consumo del camion es de {consumo} litros");
    }
}
