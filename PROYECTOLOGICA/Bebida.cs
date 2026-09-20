public class Bebida: Producto
{
    public int VolumenEnMililitros{get;private set;}

    public Bebida(string nombre,decimal precioBase,int volumenEnMililitros):base( nombre, precioBase)
    {
        if (volumenEnMililitros > 1000 || volumenEnMililitros < 100)
        {
            throw new ArgumentException("El volumen en mililitros es mayor a 1000 o menor a 100");
        }
        VolumenEnMililitros=volumenEnMililitros;
    }

    public override decimal CalcularPrecioFinal()
    {
        return PrecioBase*(decimal)1.105;
    }


}