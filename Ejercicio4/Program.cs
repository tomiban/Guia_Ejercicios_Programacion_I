
List<Alumno> Alumnos = new List<Alumno>()
{
    new Alumno("Tomi",100, 100, 100, 0, 0),
    new Alumno("Luis", 90, 90, 0, 0, 80),
    new Alumno("Gustavo", 10, 100, 100, 0, 0),
    new Alumno("Pablo", 60, 0, 0, 100, 90)
};

IngresarAlumnos();
MostrarAlumnos();

Alumno ObtenerDatosAlumno()
{
    Console.WriteLine("Ingresa el nombre del alumno / presiona ENTER para terminar :");
    string nombre = Console.ReadLine()!.ToLower();
    if (string.IsNullOrEmpty(nombre))
    {
        return null;
    }

    Console.WriteLine("Ingresa el porcentaje de asistencia:");
    int porcentajeAsistencia = int.Parse(Console.ReadLine()!);
    Console.WriteLine("Ingresa la nota del primer examen:");
    int notaPrimerExamen = int.Parse(Console.ReadLine()!);
    Console.WriteLine("Ingresa la nota del segundo examen:");
    int notaSegundoExamen = int.Parse(Console.ReadLine()!);

    int? notaRecuperatorioPrimerExamen = null;
    int? notaRecuperatorioSegundoExamen = null;
    if (notaPrimerExamen < 50 || notaSegundoExamen < 50)
    {
        Console.WriteLine("Ingresa la nota del recuperatorio del primer examen:");
        notaRecuperatorioPrimerExamen = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Ingresa la nota del recuperatorio del segundo examen:");
        notaRecuperatorioSegundoExamen = int.Parse(Console.ReadLine()!);
    }

    return new Alumno(nombre, porcentajeAsistencia, notaPrimerExamen, notaSegundoExamen, notaRecuperatorioPrimerExamen, notaRecuperatorioSegundoExamen);
}

void IngresarAlumnos()
{
    while (true)
    {
        var alumno = ObtenerDatosAlumno();
        if (alumno == null)
        {
            break;
        }

        Alumnos.Add(alumno);
    }
}

void MostrarAlumnos()
{
    int PROMOCIONADOS = 0;
    int REGULARES = 0;
    int LIBRES = 0;

    foreach (Alumno alumno in Alumnos)
    {
        Console.WriteLine($"ALUMNO: {alumno.Nombre}   -  CONDICION: {alumno.CalcularCondicion()}");

        switch (alumno.CalcularCondicion())
        {
            case "Promocionado":
                PROMOCIONADOS++;
                break;
            case "Regular":
                REGULARES++;
                break;
            case "Libre":
                LIBRES++;
                break;
        }
    }

    Console.WriteLine($"CANTIDAD DE ALUMNOS: {Alumnos.Count}  //   PROMOCIONADOS: {PROMOCIONADOS}   -   REGULARES: {REGULARES}   -   LIBRES: {LIBRES}");
}

class Alumno
{
    public string Nombre { get; set; }
    public int PorcentajeAsistencia { get; set; }
    public int NotaPrimerExamen { get; set; }
    public int NotaSegundoExamen { get; set; }
    public int? NotaRecuperatorioPrimerExamen { get; set; }
    public int? NotaRecuperatorioSegundoExamen { get; set; }

    public Alumno(string nombre, int porcentajeAsistencia, int notaPrimerExamen, int notaSegundoExamen)
    {
        Nombre = nombre;
        PorcentajeAsistencia = porcentajeAsistencia;
        NotaPrimerExamen = notaPrimerExamen;
        NotaSegundoExamen = notaSegundoExamen;
    }
    public Alumno(string nombre, int porcentajeAsistencia, int notaPrimerExamen, int notaSegundoExamen, int? notaRecuperatorioPrimerExamen, int? notaRecuperatorioSegundoExamen)
    {
        Nombre = nombre;
        PorcentajeAsistencia = porcentajeAsistencia;
        NotaPrimerExamen = notaPrimerExamen;
        NotaSegundoExamen = notaSegundoExamen;
        NotaRecuperatorioPrimerExamen = notaRecuperatorioPrimerExamen;
        NotaRecuperatorioSegundoExamen = notaRecuperatorioSegundoExamen;
    }

    public string CalcularCondicion()
    {
        if (
            PorcentajeAsistencia >= 80 &&
            (NotaPrimerExamen >= 80 || NotaRecuperatorioPrimerExamen >= 80) &&
            (NotaSegundoExamen >= 80 || NotaRecuperatorioSegundoExamen >= 80))
        {
            return "Promocionado";
        }
        else if (
            PorcentajeAsistencia >= 60 &&
            (NotaPrimerExamen >= 50 || NotaRecuperatorioPrimerExamen >= 50) &&
            (NotaSegundoExamen >= 50 || NotaRecuperatorioSegundoExamen >= 50))
        {
            return "Regular";
        }
        else
        {
            return "Libre";
        }
    }
}


