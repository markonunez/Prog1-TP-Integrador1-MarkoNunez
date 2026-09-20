public abstract class Producto : IVendible
{
    public string Nombre { get; private set; }
    public decimal PrecioBase { get; private set; }

    public Producto(string nombre, decimal precioBase)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new ArgumentException("El nombre del producto no puede estar vacío", nameof(nombre));
        }

        Nombre = nombre;

        if (precioBase <= 0)
        {
            throw new ArgumentException("El precio base debe ser mayor a 0", nameof(precioBase));
        }

        PrecioBase = precioBase;
    }

    public abstract decimal CalcularPrecioFinal();
}
