abstract class Empleado
{
    public abstract double CalcularSalario();
}


class Gerente : Empleado
{
    public override double CalcularSalario()
    {
        return 3000;
    }
}

class Desarrollador : Empleado
{
    public override double CalcularSalario()
    {
        return 2000;
    }
}

class Contador : Empleado
{
    public override double CalcularSalario()
    {
        return 1500;
    }
}
