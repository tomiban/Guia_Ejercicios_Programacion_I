
class Alumno
{
    public string Nombre { get; set; } = string.Empty;
    public int Nota { get; set; }
}

class Curso
{
    public string Nombre { get; set; } = string.Empty;
    public int CantidadAlumnos { get; set; }
    public List<Alumno> Alumnos { get; } = new List<Alumno>();

    public Curso(string nombre, int cantidadAlumnos)
    {
        Nombre = nombre;
        CantidadAlumnos = cantidadAlumnos;
    }

    public void AgregarAlumno(Alumno alumno)
    {
        if (Alumnos.Count == CantidadAlumnos)
        {
            Console.WriteLine("Curso lleno");
            return;
        }
        Alumnos.Add(alumno);
    }

    public double CalcularPromedio()
    {
        /*  int total = 0;
           foreach(Alumno alumno in Alumnos)
           {
               total += alumno.Nota;
           }
           Console.WriteLine($"Promedio: {total / Alumnos.Count}"); */
        double totalNotas = Alumnos.Sum(alumno => alumno.Nota);
        double promedioCurso = totalNotas / Alumnos.Count;
        Console.WriteLine($"El promedio del curso es: {promedioCurso}");
        return promedioCurso;
    }

    public Alumno CalificacionMasAlta()
    {

        var alumno =  Alumnos.OrderByDescending(alumno => alumno.Nota).First();
        Console.WriteLine($"La calificación mas alta es {alumno.Nota} de {alumno.Nombre}");
        return alumno;
    }


}