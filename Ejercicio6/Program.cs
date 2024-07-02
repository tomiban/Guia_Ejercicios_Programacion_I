/* 
Diseñe una clase ​Cilindro que modele un cilindro con el objetivo de calcular el volumen del cuerpo conociendo el radio de su base y la altura del mismo.
a. Cree los métodos ​AsignarDatos(...) y ​ObtenerVolumen(...) 
para asignar los datos del problema y obtener el volumen del cuerpo.
b. Escriba un programa cliente que utilice dicha clase. Defina 2 instancias de Cilindro llamadas ​c1 y ​c2.​ El objeto ​c1 debe utilizar datos ingresados por el usuario, mientras que para ​c2 utilice 5.3 cm y 10.2 cm para el radio y la altura respectivamente.
c. Agregue un constructor a la clase ​Cilindro que reciba 2 parámetros para inicializar el radio y la altura.
 */

Console.WriteLine("Ingresa el radio del cilindro:");
double radio = double.Parse(Console.ReadLine()!);
Console.WriteLine("Ingresa la altura del cilindro:");
double altura = double.Parse(Console.ReadLine()!);

Cilindro c1 = new Cilindro();
c1.AsignarDatos(radio, altura);
Cilindro c2 = new Cilindro(5.3, 10.2);


c1.ObtenerVolumen();
c2.ObtenerVolumen();

class Cilindro 
{
    public double Radio { get; set; }
    public double Altura { get; set; }

    public Cilindro()
    {
        
    }

    public Cilindro(double radio, double altura)
    {
        this.Radio = radio;
        this.Altura = altura;
    }

    public void AsignarDatos(double radio, double altura)
    {
        this.Radio = radio;
        this.Altura = altura;
    }

    public void ObtenerVolumen()
    {
        double volumen = Math.PI * Math.Pow(this.Radio, 2) * this.Altura;
        Console.WriteLine($"El volumen del cilindro es: {volumen}");
    }
}