abstract class Vehiculo
{
    public string Color { get; set; }
    public string Marca { get; set; }
    public Rueda Ruedas { get; set; }
    abstract public void Marchar();
}

 class Rueda
{
    public string Marca { get; set; }
    public int CantidadPulgadas { get; set; }

    public void EstoyRodando()
    {
        Console.WriteLine("Estoy rodando");
    }
}


 class Auto : Vehiculo
{
    public Puerta Puerta { get; set; }

    public override void Marchar()
    {
        Console.WriteLine("Voy en auto");
    }

    public void CargarBaul()
    {
        Console.WriteLine("Cargando baul");
    }
}

 class Moto : Vehiculo
{
    public int Cilindrada { get; set; }
    public int CantidadCambios { get; set; }

    public override void Marchar()
    {
        Console.WriteLine("Voy en moto");
    }
    public bool TieneBaul()
    {
        return false;
    }
}

 abstract class Bicicleta : Vehiculo
{
    public int TamañoCuadro { get; set; }
    public string TipoOrquilla { get; set; }

    public override void Marchar()
    {
        Console.WriteLine("Voy en bicicleta");
    }
    public abstract void MovimientoAlFrenar();
}

class Playera : Bicicleta
{
    public override void MovimientoAlFrenar()
    {
        Console.WriteLine("Frena la rueda de atras");
    }
}

class Mountain : Bicicleta
{
    public override void MovimientoAlFrenar()
    {
        Console.WriteLine("Frena con las dos ruedas");
    }
}

 class Puerta
{
    public string Color { get; set; }
    public void EstoyAbierta()
    {
        Console.WriteLine("Estoy abierta");
    }
}