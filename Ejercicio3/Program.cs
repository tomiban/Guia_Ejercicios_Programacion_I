HashSet<double> SalarioEmpleados = new HashSet<double>();

for (var i = 0; i < 3; i++)
{
    Console.WriteLine("Ingresa el costo por hora:");
    double costoPorHora = double.Parse(Console.ReadLine()!);

    Console.WriteLine("Ingresa la cantidad de horas:");
    int cantidadHorasTrabajadas = int.Parse(Console.ReadLine()!);

    double salario = CalcularSalario(costoPorHora, cantidadHorasTrabajadas);

    SalarioEmpleados.Add(salario);
    Console.WriteLine($"El salario del empleado {i + 1} es {salario}");
}

Console.WriteLine($"El salario mas alto es ${SalarioEmpleados.Max()}");
Console.WriteLine($"El salario mas bajo es ${SalarioEmpleados.Min()}");
Console.WriteLine($"El promedio de los salarios es: ${SalarioEmpleados.Average()}");
Console.WriteLine($"La empresa pago un monto de ${SalarioEmpleados.Sum()}");


double CalcularSalario(double costoPorHora, int cantidadHorasTrabajadas)
{
    double salario = 0;
    if (cantidadHorasTrabajadas > 40) 
    {
        salario = (costoPorHora * 40) + (cantidadHorasTrabajadas - 40) * (costoPorHora * 1.5);
    }
    else if (cantidadHorasTrabajadas > 0 && cantidadHorasTrabajadas <= 40)
    {
        salario = costoPorHora * cantidadHorasTrabajadas;
    }

    return salario;
}

/* 
double CalcularSalario(double costoPorHora, int cantidadHorasTrabajadas)
{
    
    double SalarioBase = costoPorHora * Math.Min(cantidadHorasTrabajadas, 40);
    double SalarioExtra = (costoPorHora * 1.5) * Math.Max(cantidadHorasTrabajadas - 40, 0);

    return SalarioBase + SalarioExtra;
}
 */