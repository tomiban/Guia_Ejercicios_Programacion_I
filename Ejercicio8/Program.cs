Alumno alumno = new Alumno("Tomas", "Banchio", "40645068", new DateOnly(1997, 12, 22), "Soltero", 9, 9);
Docente docente = new Docente("Francisco", "Yackel", "346345435", new DateOnly(1991, 06, 13), "Soltero", new DateOnly(2024, 01, 01));

alumno.MeritoAcademico();
Console.WriteLine(alumno.Edad(new DateOnly(2024, 12, 22)));
docente.Antiguedad(new DateOnly(2024, 06, 30));

abstract class Persona
{
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string DNI { get; set; } = string.Empty;
    public DateOnly FechaNacimiento { get; set; }
    public string EstadoCivil { get; set; } = string.Empty;

    public Persona(string nombre, string apellido, string dni, DateOnly fechaNacimiento, string estadoCivil)
    {
        Nombre = nombre;
        Apellido = apellido;
        DNI = dni;
        FechaNacimiento = fechaNacimiento;
        EstadoCivil = estadoCivil;
    }

    public int Edad(DateOnly fechaActual)
    {
        if (FechaNacimiento.Month > fechaActual.Month ||
      (fechaActual.Month == FechaNacimiento.Month && FechaNacimiento.Day > fechaActual.Day))
        {
            return fechaActual.Year - FechaNacimiento.Year - 1;
        }
        return fechaActual.Year - FechaNacimiento.Year;
    }
}

class Alumno : Persona
{
    public double Promedio { get; set; }
    public int CantidadMateriasAprobadas { get; set; }

    public Alumno(string nombre, string apellido, string dni, DateOnly fechaNacimiento, string estadoCivil, double promedio, int cantidadMateriasAprobadas) : base(nombre, apellido, dni, fechaNacimiento, estadoCivil)
    {
        Promedio = promedio;
        CantidadMateriasAprobadas = cantidadMateriasAprobadas;
    }

    public double MeritoAcademico()
    {
        Console.WriteLine($"El merito academico del alumno es: {Promedio * CantidadMateriasAprobadas}");
        return Promedio * CantidadMateriasAprobadas;
    }
}

class Docente : Persona
{
    public Docente(string nombre, string apellido, string dni, DateOnly fechaNacimiento, string estadoCivil, DateOnly fechaIngreso) : base(nombre, apellido, dni, fechaNacimiento, estadoCivil)
    {
        this.FechaIngreso = fechaIngreso;
    }

    public DateOnly FechaIngreso { get; set; }

    public int Antiguedad(DateOnly fechaActual)
    {
        var antiguedad = fechaActual.DayNumber - FechaIngreso.DayNumber;
        Console.WriteLine($"EL docente tiene una antiguedad de {antiguedad} dias");
        return antiguedad;
    }
}