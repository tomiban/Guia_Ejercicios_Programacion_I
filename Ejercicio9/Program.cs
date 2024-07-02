class Producto
{
    public string Nombre { get; set; }
    public float Precio { get; set; }
}

class ProductoElectronico: Producto
{
    public string TipoElectronico { get; set; }
}

class ProductoAlimenticio: Producto
{
    public bool EsComestible { get; set; }
}

class ProductoRopa: Producto
{
    public string TipoRopa { get; set; }
    public int Tamano { get; set; }
}

