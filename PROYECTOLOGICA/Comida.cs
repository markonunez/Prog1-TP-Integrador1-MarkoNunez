public class Comida:Producto{

    public bool EsVegana{get;private set;}

    public Comida(string nombre,decimal precioBase,bool esVegana):base( nombre, precioBase)
    {
        EsVegana=esVegana;
    }

    public override decimal CalcularPrecioFinal()
    {
        if (EsVegana == true)
        {
            return PrecioBase*(decimal)1.105;
        }
        else
        {
            return PrecioBase*(decimal)1.21;
        }
    }

}